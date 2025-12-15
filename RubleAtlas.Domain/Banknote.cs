namespace RubleAtlas.Domain;

public class Banknote
{
    public string Name { get; set; }
    public int Denomination { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }

    public List<Place> ObversePlaces { get; set; }
    public List<Place> ReversePlaces { get; set; }

    public Banknote(
        string name,
        int denomination,
        int year,
        string color,
        List<Place> obversePlaces,
        List<Place> reversePlaces)
    {
        Name = name;
        Denomination = denomination;
        Year = year;
        Color = color;
        ObversePlaces = obversePlaces;
        ReversePlaces = reversePlaces;
    }

    public Place? GetPlaceByCoordinates(double latitude, double longitude)
    {
        foreach (Place place in ObversePlaces)
        {
            if (place.Latitude == latitude && place.Longitude == longitude) return place;
        }

        foreach (Place place in ReversePlaces)
        {
            if (place.Latitude == latitude && place.Longitude == longitude) return place;
        }

        return null;
    }
}
