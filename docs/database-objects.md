---
title: Объекты БД
description: "Дополнительные объекты БД"
---

Объекты в схеме [adm] используют административную иерархию, в [mun] муниципальную иерархию. 
Объекты в схеме dbo не зависят от иерархии(но это не точно ¯\\\_(ツ)\_/¯)
## Таблицы
Таблицы с полными названиями объектов (нас. пункт, улица, дом, квартира)  
* `*.[A_IndexRegistry]` – реестр всех объектов
* `[dbo].[A_IndexApartment]` - квартиры
* `[dbo].[A_IndexHouse]` - дома
* `[dbo].[A_IndexStreet]` - улицы
* `[dbo].[A_IndexVillage]` – нас. пункты
## Представления
* `[dbo].[V_KLADR]` – коды КЛАДР
* `[dbo].[V_PostIndex]` – почтовые индексы
* `[dbo].[V_Parameters]` – все параметры
## Процедуры
* `*.[UP_RefreshRegistry]` – обновление реестра(~30 мин)  
* `*.[UP_RegistrySelect]` - объект по ObjectGUID
* `*.[UP_RegistrySelectChild]` - объекты по ParentGUID
* `[dbo].[UP_FIAS_Statistics]` - выводит количество активных объектов в БД 
* `[dbo].[UP_RefreshIndex]` – обновление таблиц A_Index*

Процедура поиска делит строку на подстроки по пробелам, и выводит объекты содержащие все подстроки. Процедуры используют полнотекстовый поиск. 
* `*.[UP_GetHierarchy]` - Иерархия для объекта
* `*.[UP_SearchRegistry]` - поиск в A_IndexRegistry
* `*.[UP_SearchRegistryByGUID]` - поиск в A_IndexRegistry по ParentGUID и ObjectGUID
* `[dbo].[UP_SearchApartment]` – поиск в A_IndexApartment
* `[dbo].[UP_SearchHouse]` – поиск в A_IndexHouse
* `[dbo].[UP_SearchStreet]` – поиск в A_IndexStreet

## Функции
### Табличные функции
Функции с окончанием Full дополнительно выводят полное наименование объекта, начиная с населённого пункта.
* `[adm].[UF_ApartmentsAggregate]` – все квартиры
* `[adm].[UF_HouseAggregate]` – все дома
* `[adm].[UF_StreetAggregate]` – все улицы
* `[adm].[UF_VillageAggregate]` – все нас. пункты
* `[*].[UF_GetHierarchy]` – Возвращает иерархию для объекта 
* `[*].[UF_GetParent]` - Родитель объекта по ObjectGUID
### Скалярные функции 
* `[*].[SUF_GetFullAddress]` - Полный адрес объекта по ObjectGUID
* `[*].[SUF_GetParentGUID]` - Код родителя по ObjectGUID
* `[*].[UF_SearchOne]` - Поиск в реестре (Выводит всегда 1 строку)
* `[*].[UF_SearchRegistry]` - Поиск в реестре
* `[dbo].[SUF_RemoveSpecialChars]` - Заменяет все лишние символы на пробелы
#### Выражения
* `[dbo].[SUF_ExpressionAND]` - Создает выражение для полнотекстового поиска используя AND
* `[dbo].[SUF_ExpressionNEAR]` - Создает выражение для полнотекстового поиска используя NEAR  
Строка делится на подстроки по пробелам, и добавляется `*` для каждой подстроки. Кроме последней и подстрок перед `|`
```sql
select FIAS_GAR.dbo.SUF_ExpressionNEAR('г Екат Уральская 1')
select FIAS_GAR.dbo.SUF_ExpressionNEAR('г Екат | Уральская 1')
select FIAS_GAR.dbo.SUF_ExpressionAND('г Екат Уральская 1')
select FIAS_GAR.dbo.SUF_ExpressionAND('г Екат | Уральская 1')
```
* `"г*" ~ "Екат*" ~ "Уральская*" ~ "1"`
* `"г" ~ "Екат" ~ "Уральская*" ~ "1"`
* `"г*" AND "Екат*" AND "Уральская*" AND "1"`
* `"г" AND "Екат" AND "Уральская*" AND "1"`
