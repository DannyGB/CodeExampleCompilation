using System.Threading.Tasks;

namespace CodeExampleCompilation.Infrastructure.IO
{
    public class File : IFile
    {
        public async Task<string> ReadAllTextAsync(string path) => await System.IO.File.ReadAllTextAsync(path);
    }
}