using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CodeExampleCompilation.Infrastructure
{
    public class ContentReader : IContentReader
    {
        public IEnumerable<ContentMetaData> Read(string root) =>
            Directory.EnumerateDirectories(root)
                .Select(x => new ContentMetaData() { ContentItem = JsonSerializer.Deserialize<ContentItem>(File.ReadAllText($"{x}/{Constants.ContentFileName}")), FilePath = x});
    }
}