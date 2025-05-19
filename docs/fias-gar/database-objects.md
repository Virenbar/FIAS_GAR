---
title: Объекты БД
description: "Дополнительные объекты БД"
---

## Таблицы

Таблицы с полными названиями объектов (нас. пункт, улица, дом, квартира)

* `*.[A_IndexRegistry]` – Реестр всех объектов

## Представления

* `[dbo].[V_KLADR]` – Коды КЛАДР
* `[dbo].[V_Parameters]` – Все параметры
* `[dbo].[V_PostIndex]` – Почтовые индексы

## Процедуры

* `[dbo].[UP_FIAS_Statistics]` - Количество активных объектов в БД
* `[dbo].[UP_ObjectParameters]` – Параметры объекта
* `*.[UP_RefreshRegistry]` – Обновление реестра(~30 мин)  
* `*.[UP_RegistryHierarchy]` - Иерархия для объекта
* `*.[UP_RegistrySelect]` - Объект по GUID
* `*.[UP_RegistrySelectChild]` - Дочерние объекты по GUID

### Поиск

* `*.[UP_SearchRegistry]` - Поиск в A_IndexRegistry
* `*.[UP_SearchRegistryByGUID]` - Поиск в A_IndexRegistry по ParentGUID и ObjectGUID

Процедура поиска делит строку на подстроки по пробелам, и выводит объекты содержащие все подстроки. Процедуры используют полнотекстовый поиск.

## Функции

### Табличные функции

Функции с окончанием Full дополнительно выводят полное наименование объекта, начиная с населённого пункта.

* `*.[UF_RegistryAddress]` - Реестр с полными адресами
* `*.[UF_RegistryChild]` - Все дочерние объекты по GUID
* `*.[UF_RegistryHierarchy]` – Иерархия для объекта по GUID
* `*.[UF_SearchOne]` - Поиск в реестре (Выводит всегда 1 строку)
* `*.[UF_SearchRegistry]` - Поиск в реестре
* ~~`[adm].[UF_StreetAggregate]`~~ – все улицы (Устаревшее)
* ~~`[adm].[UF_VillageAggregate]`~~ – все нас. пункты (Устаревшее)

### Скалярные функции

* `*.[SUF_AddressFull]` - Полный адрес объекта по GUID объекта
* `*.[SUF_AddressPart]` - Адрес объекта по GUID от указанного уровня
* `*.[SUF_AreaGUID]` -  GUID района по GUID объекта
* `*.[SUF_AreaName]` - Наименование района по GUID объекта
* `*.[SUF_HouseName]` - Наименование дома по GUID объекта
* `*.[SUF_HouseNameFull]` - Полное наименование дома (Улица+)
* `*.[SUF_ParentGUID]` - GUID родителя по GUID объекта
* `*.[SUF_StreetName]` - Наименование улицы по GUID объекта
* `*.[SUF_VillageGUID]` - GUID населенного пункта по GUID объекта
* `*.[SUF_VillageName]` - Наименование населенного пункта
* `*.[SUF_VillageNameFull]` - Наименование населенного пункта (+Дом)
* `[dbo].[SUF_RemoveSpecialChars]` - Заменяет все лишние символы на пробелы
* `[dbo].[SUF_GUIDToID]` - ID объекта по GUID

#### Выражения

* `[dbo].[SUF_ExpressionAND]` - Создает выражение для полнотекстового поиска используя AND
* `[dbo].[SUF_ExpressionNEAR]` - Создает выражение для полнотекстового поиска используя NEAR  
Строка делится на подстроки по пробелам, и каждой подстроке в конце добавляется `*`, кроме последней.

```sql
SELECT FIAS_GAR.dbo.SUF_ExpressionNEAR('г Екат Уральская 1')
SELECT FIAS_GAR.dbo.SUF_ExpressionAND('г Екат Уральская 1')
```

* `"г*" ~ "Екат*" ~ "Уральская*" ~ "1"`
* `"г*" AND "Екат*" AND "Уральская*" AND "1"`

При использовании `|` для левой части строки `*` не будет добавляться.

```sql
SELECT FIAS_GAR.dbo.SUF_ExpressionNEAR('г Екат | Уральская 1')
SELECT FIAS_GAR.dbo.SUF_ExpressionAND('г Екат | Уральская 1')
```

* `"г" ~ "Екат" ~ "Уральская*" ~ "1"`
* `"г" AND "Екат" AND "Уральская*" AND "1"`
