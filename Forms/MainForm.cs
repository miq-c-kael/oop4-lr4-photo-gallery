using PhotoGallery.Domain;
using PhotoGallery.Repositories;
using PhotoGallery.Services;

namespace PhotoGallery.Forms;

public partial class MainForm : Form
{
    private readonly PhotoService _service;
    private readonly List<Photographer> _photographers;
    private readonly List<Location> _locations;

    public MainForm()
    {
        InitializeComponent();
        _service = new PhotoService(new PhotoRepository());
        _photographers = SeedPhotographers();
        _locations = SeedLocations();
        SeedPhotos();
        RefreshGrid(_service.All());
    }

    private static List<Photographer> SeedPhotographers() =>
    [
        new(1, "Анна Иванова",       "Россия"),
        new(2, "Henri Cartier-Bresson", "Франция"),
        new(3, "Steve McCurry",      "США"),
    ];

    private static List<Location> SeedLocations() =>
    [
        new(1, "Санкт-Петербург", "Россия"),
        new(2, "Париж",           "Франция"),
        new(3, "Кабул",           "Афганистан"),
        new(4, "Токио",           "Япония"),
    ];

    private void SeedPhotos()
    {
        _service.Add("Мосты на закате",         _photographers[0], _locations[0], new(2024, 7, 15), 24.0);
        _service.Add("Уличная сцена",           _photographers[1], _locations[1], new(1952, 6, 3), 12.0);
        _service.Add("Афганская девочка",       _photographers[2], _locations[2], new(1984, 12, 1), 36.0);
        _service.Add("Неонные улицы Сибуи",     _photographers[2], _locations[3], new(2018, 4, 20), 42.0);
        _service.Add("Эрмитаж зимой",           _photographers[0], _locations[0], new(2023, 1, 8), 30.0);
        _service.Add("Каналы Парижа",           _photographers[1], _locations[1], new(1956, 3, 10), 6.0);
    }

    private void RefreshGrid(IEnumerable<Photo> photos)
    {
        // Проецируем в анонимный тип — DataGridView сам разложит колонки.
        // Это пример Select-проекции прямо в UI-слое.
        var rows = photos
            .Select(p => new
            {
                p.Id,
                Название = p.Title,
                Фотограф = p.Photographer.Name,
                Локация = p.Location.Name,
                Страна = p.Location.Country,
                Дата = p.TakenAt.ToString("yyyy-MM-dd"),
                МП = p.Megapixels,
            })
            .ToList();
        grid.DataSource = rows;
        if (grid.Columns["Id"] != null) grid.Columns["Id"]!.Visible = false;
        UpdateRowCountLabel(rows.Count);
    }

    private void UpdateRowCountLabel(int count)
        => labelInfo.Text = $"Записей: {count}";

    private Photo? SelectedPhoto()
    {
        if (grid.SelectedRows.Count == 0) return null;
        var id = (int)grid.SelectedRows[0].Cells["Id"].Value;
        return _service.All().FirstOrDefault(p => p.Id == id);
    }

    private void btnAdd_Click(object? sender, EventArgs e)
    {
        using var form = new PhotoEditForm(null, _photographers, _locations);
        if (form.ShowDialog(this) != DialogResult.OK) return;
        try
        {
            _service.Add(form.TitleValue, form.PhotographerValue, form.LocationValue, form.TakenAtValue, form.MegapixelsValue);
            RefreshGrid(_service.All());
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnEdit_Click(object? sender, EventArgs e)
    {
        var photo = SelectedPhoto();
        if (photo == null) return;
        using var form = new PhotoEditForm(photo, _photographers, _locations);
        if (form.ShowDialog(this) != DialogResult.OK) return;
        try
        {
            photo.Update(form.TitleValue, form.PhotographerValue, form.LocationValue, form.TakenAtValue, form.MegapixelsValue);
            RefreshGrid(_service.All());
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnDelete_Click(object? sender, EventArgs e)
    {
        var photo = SelectedPhoto();
        if (photo == null) return;
        var ok = MessageBox.Show($"Удалить «{photo.Title}»?", "Подтверждение",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (ok != DialogResult.Yes) return;
        _service.Delete(photo.Id);
        RefreshGrid(_service.All());
    }

    private void btnFilter_Click(object? sender, EventArgs e)
        => RefreshGrid(_service.HighResOnly((double)numMinMp.Value));

    private void btnSort_Click(object? sender, EventArgs e)
        => RefreshGrid(_service.SortedByDateDesc());

    private void btnReset_Click(object? sender, EventArgs e)
    {
        txtSearch.Clear();
        RefreshGrid(_service.All());
    }

    private void btnGroupByLocation_Click(object? sender, EventArgs e)
    {
        var rows = _service.SummaryByLocation()
            .Select(s => new
            {
                Локация = s.Location.Name,
                Страна = s.Location.Country,
                Фото = s.Count,
                СуммаМП = Math.Round(s.TotalMegapixels, 1),
                СредняяМП = Math.Round(s.AverageMegapixels, 2),
            })
            .ToList();
        grid.DataSource = rows;
        UpdateRowCountLabel(rows.Count);
    }

    private void btnGroupByPhotographer_Click(object? sender, EventArgs e)
    {
        var rows = _service.SummaryByPhotographer()
            .Select(s => new
            {
                Фотограф = s.Photographer.Name,
                Страна = s.Photographer.Country,
                Фото = s.PhotosCount,
                МаксМП = s.MaxMegapixels,
                ПоследняяСъёмка = s.LastShotDate.ToString("yyyy-MM-dd"),
            })
            .ToList();
        grid.DataSource = rows;
        UpdateRowCountLabel(rows.Count);
    }

    private void txtSearch_TextChanged(object? sender, EventArgs e)
        => RefreshGrid(_service.Search(txtSearch.Text));
}
