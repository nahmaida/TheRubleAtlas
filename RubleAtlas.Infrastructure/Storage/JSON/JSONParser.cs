using System.Text.Json;
using RubleAtlas.Domain;

namespace RubleAtlas.Infrastructure.Storage.JSON;

internal class JSONParser
{
    public string FilePath { get; set; }

    public JSONParser(string filePath)
    {
        FilePath = filePath;
    }

    public List<Banknote> ParseBanknotes()
    {
        var jsonString = File.ReadAllText(FilePath);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var root = JsonSerializer.Deserialize<NotesRootDto>(jsonString, options)
                   ?? new NotesRootDto();

        return root.Notes.Select(n =>
            new Banknote(
                name: n.Id, // JSON "id" -> Banknote.Name
                denomination: n.Denomination,
                year: n.Year,
                obversePlaces: n.Places.Obverse.Select(p =>
                    new Place(
                        name: p.CityKey,
                        landmarkKey: p.LandmarkKey,
                        latitude: p.Lat,
                        longitude: p.Lng
                    )
                ).ToList(),
                reversePlaces: n.Places.Reverse.Select(p =>
                    new Place(
                        name: p.CityKey,
                        landmarkKey: p.LandmarkKey,
                        latitude: p.Lat,
                        longitude: p.Lng
                    )
                ).ToList()
            )
        ).ToList();
    }
}
