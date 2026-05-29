using PhotoGallery.Domain;
using PhotoGallery.Repositories;

namespace PhotoGallery.Services;

/// <summary>
/// Сервисный слой над репозиторием. LINQ-запросы для UI:
/// фильтрация, сортировка, проекция, группировка, агрегация.
/// </summary>
public sealed class PhotoService
{
    private readonly PhotoRepository _repository;

    public PhotoService(PhotoRepository repository) => _repository = repository;

    public void Add(string title, Photographer photographer, Location location,
        DateTime takenAt, double megapixels)
        => _repository.Add(title, photographer, location, takenAt, megapixels);

    public void Delete(int id) => _repository.Delete(id);

    public IEnumerable<Photo> All() => _repository.All();

    // LINQ 

    /// <summary>Поиск по подстроке в названии (case-insensitive).</summary>
    public IEnumerable<Photo> Search(string query) => string.IsNullOrWhiteSpace(query)
        ? All()
        : All().Where(p => p.Title.Contains(query, StringComparison.OrdinalIgnoreCase));

    /// <summary>Фильтрация: фото с разрешением выше заданного.</summary>
    public IEnumerable<Photo> HighResOnly(double minMegapixels)
        => All().Where(p => p.Megapixels >= minMegapixels);

    /// <summary>Сортировка по дате съёмки (по убыванию — свежие выше).</summary>
    public IEnumerable<Photo> SortedByDateDesc()
        => All().OrderByDescending(p => p.TakenAt).ThenBy(p => p.Title);

    /// <summary>Группировка по локации + проекция + агрегация.</summary>
    public IEnumerable<LocationSummary> SummaryByLocation()
        => All()
            .GroupBy(p => p.Location)
            .Select(g => new LocationSummary(
                Location: g.Key,
                Count: g.Count(),
                TotalMegapixels: g.Sum(p => p.Megapixels),
                AverageMegapixels: g.Average(p => p.Megapixels)))
            .OrderByDescending(s => s.Count);

    /// <summary>Группировка по фотографу с агрегацией.</summary>
    public IEnumerable<PhotographerSummary> SummaryByPhotographer()
        => All()
            .GroupBy(p => p.Photographer)
            .Select(g => new PhotographerSummary(
                Photographer: g.Key,
                PhotosCount: g.Count(),
                MaxMegapixels: g.Max(p => p.Megapixels),
                LastShotDate: g.Max(p => p.TakenAt)))
            .OrderByDescending(s => s.PhotosCount);
}

public record LocationSummary(Location Location, int Count, double TotalMegapixels, double AverageMegapixels);
public record PhotographerSummary(Photographer Photographer, int PhotosCount, double MaxMegapixels, DateTime LastShotDate);
