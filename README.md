# ФИАС ГАР [![Build artifact](https://img.shields.io/github/actions/workflow/status/Virenbar/FIAS_GAR/build-artifact.yml?label=Build&logo=github)](https://github.com/Virenbar/FIAS_GAR/actions/workflows/build-artifact.yml)

Проект БД ФИАС ГАР для SQL Server и приложение для её обновления.

## FIAS_GAR

Проект БД для SQL Server.  
Изначально таблицы БД были созданы с помощью SMO на основе XSD схем (класс DBCreate в FIASUpdate).
После правки таблиц  структура БД была импортирована в проект.  
Для открытия проекта необходим [SSDT](https://docs.microsoft.com/en-us/sql/ssdt/download-sql-server-data-tools-ssdt)

## FIAS.Core

Библиотека для работы с БД FIAS_GAR и API ФИАС.

## FIASUpdate

Приложение для импорта данный из XML в БД.

## [Документация](https://virenbar.ru/FIAS_GAR/)

![Основная форма](/docs/assets/fias/import.png)
![Настройки импорта](/docs/assets/fias/settings.png)  
![Форма поиска адреса в БД](/docs/assets/fias/search.png)

*P.S. Данное решение предназначено для разработчик работающих с .NET и SQL Server.*  
*P.P.S. Импорт тестировался только с 66 регионом, поэтому при импорте других регионов могут возникнуть ошибки из-за некорректных данных в XML. (В основном из-за NULL вместо значения)*
