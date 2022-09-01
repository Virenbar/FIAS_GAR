---
title: Таблицы из выгрузки
description: "Таблицы из выгрузки ФИАС ГАР"
---

|Таблица                       |Описание|
|------------------------------|-----------------------------------------------------------------|
|`[dbo].[ADDHOUSE_TYPES]`      |Дополнительные типы зданий|
|`[dbo].[ADDR_OBJ]`            |Объекты планировочной структуры (все, что выше домов по иерархии)|
|`[dbo].[ADDR_OBJ_DIVISION]`   |Поделённые/объединенные объекты|
|`[dbo].[ADDR_OBJ_TYPES]`      |Типы объектов планировочной структуры|
|`[dbo].[ADM_HIERARCHY]`       |Административная иерархия|
|`[dbo].[APARTMENT_TYPES]`     |Типы помещений|
|`[dbo].[APARTMENTS]`          |Помещения|
|`[dbo].[CARPLACES]`           |Машино-места|
|`[dbo].[CHANGE_HISTORY]`      |История операций с объектами|
|`[dbo].[HOUSE_TYPES]`         |Типы зданий|
|`[dbo].[HOUSES]`              |Здания (сооружения)|
|`[dbo].[MUN_HIERARCHY]`       |Муниципальная иерархия|
|`[dbo].[NORMATIVE_DOCS]`      |Документы (В основном ничего полезного) |
|`[dbo].[NORMATIVE_DOCS_KINDS]`|Род? документа |
|`[dbo].[NORMATIVE_DOCS_TYPES]`|Типы документов |
|`[dbo].[OBJECT_LEVELS]`       |Уровни объектов|
|`[dbo].[OPERATION_TYPES]`     |Тип операции |
|`[dbo].[PARAM_TYPES]`         |Типы параметров объектов|
|`[dbo].[PARAMS]`              |Параметры объектов|
|`[dbo].[REESTR_OBJECTS]`      |Реестр всех объектов|
|`[dbo].[ROOM_TYPES]`          |Типы помещений в пределах помещения|
|`[dbo].[ROOMS]`               |Помещения в пределах помещения|
|`[dbo].[STEADS]`              |Земельные участки|

`ObjectID : long` и `ObjectGUID : GUID` - уникальные коды объектов. ID используется для связи между таблицами.