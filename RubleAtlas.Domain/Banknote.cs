namespace RubleAtlas.Domain;

public class Banknote
{
    public string Name { get; set; }
    public int Denomination { get; set; }
    public int Year { get; set; }

    public List<Place> ObversePlaces { get; set; }
    public List<Place> ReversePlaces { get; set; }

    public Banknote(
        string name,
        int denomination,
        int year,
        List<Place> obversePlaces,
        List<Place> reversePlaces)
    {
        Name = name;
        Denomination = denomination;
        Year = year;
        ObversePlaces = obversePlaces;
        ReversePlaces = reversePlaces;
    }
}
