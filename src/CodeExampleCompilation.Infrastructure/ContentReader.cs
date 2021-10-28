using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CodeExampleCompilation.Application;
using CodeExampleCompilation.Domain;

namespace CodeExampleCompilation.Infrastructure
{
    public class ContentReader : IContentReader
    {
        public async Task<IEnumerable<ContentMetaData>> Read(string root)
        {
            var tasks = Directory.EnumerateDirectories(root)
                .Select(async x => new ContentMetaData()
                { 
                    ContentItem = JsonSerializer.Deserialize<ContentItem>(await File.ReadAllTextAsync($"{x}/{Constants.ContentFileName}")),
                    FilePath = x
                }).ToList();

            await Task.WhenAll(tasks);
            
            return tasks.Select(x => x.Result);
        }
    }
}