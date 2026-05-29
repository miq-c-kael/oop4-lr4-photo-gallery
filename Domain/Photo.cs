namespace PhotoGallery.Domain;

public sealed class Photo
{
    public int Id { get; }
    public string Title { get; private set; }
    public Photographer Photographer { get; private set; }
    public Location Location { get; private set; }
    public DateTime TakenAt { get; private set; }
    public double Megapixels { get; private set; }

    public Photo(int id, string title, Photographer photographer, Location location,
        DateTime takenAt, double megapixels)
    {
        Validate(title, photographer, location, takenAt, megapixels);
        Id = id;
        Title = title;
        Photographer = photographer;
        Location = location;
        TakenAt = takenAt;
        Megapixels = megapixels;
    }

    public void Update(string title, Photographer photographer, Location location,
        DateTime takenAt, double megapixels)
    {
        Validate(title, photographer, location, takenAt, megapixels);
        Title = title;
        Photographer = photographer;
        Location = location;
        TakenAt = takenAt;
        Megapixels = megapixels;
    }

    private static void Validate(string title, Photographer photographer, Location location,
        DateTime takenAt, double megapixels)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Название фото не может быть пустым");
        ArgumentNullException.ThrowIfNull(photographer);
        ArgumentNullException.ThrowIfNull(location);
        if (takenAt > DateTime.Now.AddDays(1))
            throw new ArgumentException("Дата съёмки не может быть в будущем");
        if (megapixels <= 0)
            throw new ArgumentException("Разрешение в мегапикселях должно быть положительным");
    }

    public override string ToString() => $"{Title} ({TakenAt:yyyy-MM-dd})";
}
