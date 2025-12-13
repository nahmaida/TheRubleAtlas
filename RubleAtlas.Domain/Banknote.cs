namespace RubleAtlas.Domain
{
    public class Banknote
    {
        public string Name { get; set; }
        public int Denomination { get; set; }
        public int Year { get; set; }
        public Place ObversePlace { get; set; }
        public Place ReversePlace { get; set; }

        public Banknote(string name, int denomination, int year, Place obversePlace, Place reversePlace)
        {
            Name = name;
            Denomination = denomination;
            Year = year;
            ObversePlace = obversePlace;
            ReversePlace = reversePlace;
        }
    }
}
