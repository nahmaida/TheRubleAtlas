using RubleAtlas.Domain;

namespace RubleAtlas.Infrastructure.Storage.JSON
{
    public class JSONStorage
    {
        private readonly string _filePath;
        private readonly JSONParser _parser;
        private readonly List<Banknote> _banknotes;
        private readonly object _lock = new();

        public JSONStorage(string filePath)
        {
            _filePath = filePath;
            _parser = new JSONParser(_filePath);
            _banknotes = _parser.ParseBanknotes();
        }

        public List<Banknote> GetBanknotes()
        {
            lock (_lock)
            {
                return _banknotes;
            }
        }
    }
}
