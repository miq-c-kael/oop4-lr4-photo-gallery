namespace PhotoGallery.Domain;

public sealed class Photographer
{
    public int Id { get; }
    public string Name { get; }
    public string Country { get; }

    public Photographer(int id, string name, string country)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Имя фотографа не может быть пустым");
        Id = id;
        Name = name;
        Country = country ?? string.Empty;
    }

    public override string ToString() => string.IsNullOrEmpty(Country) ? Name : $"{Name} ({Country})";
}
