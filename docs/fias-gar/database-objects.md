---
title: Объекты БД
description: "Дополнительные объекты БД"
---

## Таблицы

Таблицы с полными названиями объектов (нас. пункт, улица, дом, квартира)

* `*.[A_IndexRegistry]` – реестр всех объектов
* `[dbo].[A_IndexApartment]` - квартиры
* `[dbo].[A_IndexHouse]` - дома
* `[dbo].[A_IndexStreet]` - улицы
* `[dbo].[A_IndexVillage]` – нас. пункты

## Представления

* `[dbo].[V_KLADR]` – коды КЛАДР
* `[dbo].[V_Parameters]` – все параметры
* `[dbo].[V_PostIndex]` – почтовые индексы

## Процедуры

* `[dbo].[UP_FIAS_Statistics]` - выводит количество активных объектов в БД
* `[dbo].[UP_ObjectParameters]` – параметры объекта
* `[dbo].[UP_RefreshIndex]` – обновление таблиц `A_Index*`
* `*.[UP_RefreshRegistry]` – обновление реестра(~30 мин)  
* `*.[UP_RegistrySelect]` - объект по ObjectGUID
* `*.[UP_RegistrySelectChild]` - объекты по ParentGUID

Процедура поиска делит строку на подстроки по пробелам, и выводит объекты содержащие все подстроки. Процедуры используют полнотекстовый поиск.

* `[dbo].[UP_SearchApartment]` – поиск в A_IndexApartment
* `[dbo].[UP_SearchHouse]` – поиск в A_IndexHouse
* `[dbo].[UP_SearchStreet]` – поиск в A_IndexStreet
* `*.[UP_GetHierarchy]` - иерархия для объекта
* `*.[UP_SearchRegistry]` - поиск в A_IndexRegistry
* `*.[UP_SearchRegistryByGUID]` - поиск в A_IndexRegistry по ParentGUID и ObjectGUID

## Функции

### Табличные функции

Функции с окончанием Full дополнительно выводят полное наименование объекта, начиная с населённого пункта.

* `[*].[UF_Hierarchy]` – Возвращает иерархию для объекта
* `[*].[UF_Parent]` - Родитель объекта по ObjectGUID
* `[*].[UF_RegistryAddress]` - Возвращает реестр с полными адресами
* `[*].[UF_SearchOne]` - Поиск в реестре (Выводит всегда 1 строку)
* `[*].[UF_SearchRegistry]` - Поиск в реестре
* `[adm].[UF_ApartmentsAggregate]` – все квартиры
* `[adm].[UF_HouseAggregate]` – все дома
* `[adm].[UF_StreetAggregate]` – все улицы
* `[adm].[UF_VillageAggregate]` – все нас. пункты

### Скалярные функции

* `[*].[SUF_AddressFull]` - Полный адрес объекта по ObjectGUID
* `[*].[SUF_AddressPart]` - Адрес объекта по ObjectGUID от указанного уровня
* `[*].[SUF_AreaGUID]` - Получить код района
* `[*].[SUF_AreaName]` - Получить наименование района
* `[*].[SUF_HouseName]` - Получить наименование дома
* `[*].[SUF_HouseNameFull]` - Получить полное наименование дома (Улица+)
* `[*].[SUF_ParentGUID]` - Код родителя по ObjectGUID
* `[*].[SUF_StreetName]` - Получить наименование улицы
* `[*].[SUF_VillageGUID]` -  Получить GUID населенного пункта по GUID объекта
* `[*].[SUF_VillageName]` - Получить наименование населенного пункта
* `[*].[SUF_VillageNameFull]` - Получить наименование населенного пункта (Дом+)
* `[dbo].[SUF_RemoveSpecialChars]` - Заменяет все лишние символы на пробелы
* `[dbo].[SUF_GUIDToID]` - Получить ID объекта по GUID

#### Выражения

* `[dbo].[SUF_ExpressionAND]` - Создает выражение для полнотекстового поиска используя AND
* `[dbo].[SUF_ExpressionNEAR]` - Создает выражение для полнотекстового поиска используя NEAR  
Строка делится на подстроки по пробелам, и добавляется `*` для каждой подстроки. Кроме последней и подстрок перед `|`

```sql
SELECT FIAS_GAR.dbo.SUF_ExpressionNEAR('г Екат Уральская 1')
SELECT FIAS_GAR.dbo.SUF_ExpressionNEAR('г Екат | Уральская 1')
SELECT FIAS_GAR.dbo.SUF_ExpressionAND('г Екат Уральская 1')
SELECT FIAS_GAR.dbo.SUF_ExpressionAND('г Екат | Уральская 1')
```

* `"г*" ~ "Екат*" ~ "Уральская*" ~ "1"`
* `"г" ~ "Екат" ~ "Уральская*" ~ "1"`
* `"г*" AND "Екат*" AND "Уральская*" AND "1"`
* `"г" AND "Екат" AND "Уральская*" AND "1"`
