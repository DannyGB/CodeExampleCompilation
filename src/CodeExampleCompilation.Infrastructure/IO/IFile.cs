using System.Threading.Tasks;

namespace CodeExampleCompilation.Infrastructure.IO
{
    public interface IFile
    {
        Task<string> ReadAllTextAsync(string filePath);
    }
}