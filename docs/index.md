---
title: Описание ФИАС ГАР
description: "Проект БД ФИАС ГАР для SQL Server и приложение для её обновления"
---

Проект БД ФИАС ГАР для SQL Server и приложение для её обновления.

## [FIAS_GAR](./fias-gar/index.md)

Проект БД ФИАС ГАР для SQL Server.  
Для открытия проекта необходим [SSDT](https://docs.microsoft.com/en-us/sql/ssdt/download-sql-server-data-tools-ssdt)

## [FIAS.Core](./fias-core.md)

Библиотека для работы с БД FIAS_GAR и API ФИАС.

## [FIASUpdate](./fias-update/index.md)

Приложение для импорта данный из XML в БД.

*P.S. Данное решение предназначено для разработчик работающих с .NET и SQL Server.*  
*P.P.S. Импорт тестировался только с 66 регионом, поэтому при импорте других регионов могут возникнуть ошибки из-за некорректных данных в XML. (В основном из-за NULL вместо значения)*
