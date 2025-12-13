namespace RubleAtlas.Domain
{
    public class Place
    {
        public string CityKey { get; set; }
        public string LandmarkKey { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        public Place(string name, string landmarkKey, double latitude, double longitude)
        {
            CityKey = name;
            LandmarkKey = landmarkKey;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string GetMapLink()
        {
            return $"https://www.google.com/maps/search/?api=1&query={Latitude},{Longitude}";
        }
    }
}
