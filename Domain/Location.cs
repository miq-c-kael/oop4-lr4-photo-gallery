namespace PhotoGallery.Domain;

public sealed class Location
{
    public int Id { get; }
    public string Name { get; }
    public string Country { get; }

    public Location(int id, string name, string country)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название локации не может быть пустым");
        Id = id;
        Name = name;
        Country = country ?? string.Empty;
    }

    public override string ToString() => string.IsNullOrEmpty(Country) ? Name : $"{Name}, {Country}";
}
