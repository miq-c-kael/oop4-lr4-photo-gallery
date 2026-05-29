# ЛР 4 — Фотогалерея (CRUD + LINQ)

WinForms-приложение на C# (.NET 8): информационная система фотогалереи с CRUD-операциями и LINQ.

Вариант 8 — классы **Photo**, **Photographer**, **Location**.

## Сборка и запуск

```pwsh
dotnet build
dotnet run
```

Требуется **.NET 8 SDK** и **Windows**.

## Что внутри

- `Domain/` — `Photo`, `Photographer`, `Location` с валидацией в конструкторе и методе `Update`.
- `Repositories/` — `PhotoRepository` (in-memory).
- `Services/` — `PhotoService` с LINQ-запросами (фильтр, сортировка, проекция, группировка, агрегация).
- `Forms/` — `MainForm` (DataGridView + кнопки CRUD/Фильтр/Сортировка/Группировка), `PhotoEditForm` (диалог редактирования).

При старте загружаются 6 тестовых фото.
