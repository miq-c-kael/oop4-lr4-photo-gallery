using PhotoGallery.Domain;

namespace PhotoGallery.Repositories;

public sealed class PhotoRepository
{
    private readonly List<Photo> _photos = new();
    private int _nextId = 1;

    public void Add(string title, Photographer photographer, Location location,
        DateTime takenAt, double megapixels)
    {
        _photos.Add(new Photo(_nextId++, title, photographer, location, takenAt, megapixels));
    }

    public void Delete(int id) => _photos.RemoveAll(p => p.Id == id);

    public IReadOnlyList<Photo> All() => _photos;
}
