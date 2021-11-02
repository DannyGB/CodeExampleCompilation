using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CodeExampleCompilation.Application;
using CodeExampleCompilation.Domain;

namespace CodeExampleCompilation.Infrastructure.IO
{
    public class ContentReader : IContentReader
    {
        private readonly IDirectory _directory;
        private readonly IFile _file;

        public ContentReader(IDirectory directory, IFile file) 
        {
            _file = file ?? throw new ArgumentException("file cannot be null", nameof(file));
            _directory = directory ?? throw new ArgumentException("directory cannot be null", nameof(directory));
        }
        
        public async Task<IEnumerable<ContentFile>> Read(string root)
        {
            var tasks = _directory.EnumerateDirectories(root)
                .Select(async path 
                    => new ContentFile(path, JsonSerializer.Deserialize<ContentItem>(await _file.ReadAllTextAsync($"{path}/{Constants.ContentFileName}")))
                ).ToList();

            await Task.WhenAll(tasks);
            
            return tasks.Select(x => x.Result);
        }
    }
}