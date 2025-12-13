using System.Text.Json;
using RubleAtlas.Domain;

namespace RubleAtlas.Infrastructure.Storage.JSON
{
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

            List<Banknote> banknotes = root.Notes.Select(n =>
                new Banknote(
                    name: n.Id, // maps JSON "id" -> your Banknote.Name
                    denomination: n.Denomination,
                    year: n.Year,
                    obversePlace: new Place(
                        name: n.Places.Obverse.CityKey,
                        landmarkKey: n.Places.Obverse.LandmarkKey,
                        latitude: n.Places.Obverse.Lat,
                        longitude: n.Places.Obverse.Lng
                    ),
                    reversePlace: new Place(
                        name: n.Places.Reverse.CityKey,
                        landmarkKey: n.Places.Reverse.LandmarkKey,
                        latitude: n.Places.Reverse.Lat,
                        longitude: n.Places.Reverse.Lng
                    )
                )
            ).ToList();

            return banknotes;
        }
    }
}
