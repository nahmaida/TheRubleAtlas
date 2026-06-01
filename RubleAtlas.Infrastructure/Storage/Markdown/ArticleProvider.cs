namespace RubleAtlas.Infrastructure.Storage.Markdown
{
    public class ArticleProvider
    {
        private readonly string _basePath;

        public ArticleProvider(string basePath)
        {
            _basePath = basePath;
        }

        public async Task<string> GetArticleAsync(string folder, string id, string culture)
        {
            // /Articles/[Banknotes|Places]/[en|ru]/[id].md
            var path = Path.Combine(_basePath, "Articles", folder, culture, $"{id}.md");
            Console.WriteLine(path);

            if (!File.Exists(path))
            {
                return string.Empty;
            }

            return await File.ReadAllTextAsync(path);
        }
    }
}