using System.Collections.Generic;

namespace CodeExampleCompilation.Infrastructure.IO
{
    public interface IDirectory
    {
        IEnumerable<string> EnumerateDirectories(string root);
    }
}