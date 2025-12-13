using System.Text.Json.Serialization;

namespace RubleAtlas.Infrastructure.Storage.JSON;

public sealed class NotesRootDto
{
    [JsonPropertyName("notes")]
    public List<BanknoteDto> Notes { get; set; } = new();
}

public sealed class BanknoteDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = "";

    [JsonPropertyName("denomination")]
    public int Denomination { get; set; }

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("places")]
    public PlacesDto Places { get; set; } = new();
}

public sealed class PlacesDto
{
    [JsonPropertyName("obverse")]
    public List<PlaceDto> Obverse { get; set; } = new();

    [JsonPropertyName("reverse")]
    public List<PlaceDto> Reverse { get; set; } = new();
}

public sealed class PlaceDto
{
    [JsonPropertyName("cityKey")]
    public string CityKey { get; set; } = "";

    [JsonPropertyName("landmarkKey")]
    public string LandmarkKey { get; set; } = "";

    [JsonPropertyName("lat")]
    public double Lat { get; set; }

    [JsonPropertyName("lng")]
    public double Lng { get; set; }
}
