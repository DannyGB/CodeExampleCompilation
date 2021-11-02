using System.Collections.Generic;

namespace CodeExampleCompilation.Infrastructure.IO
{
    public class Directory : IDirectory
    {
        public IEnumerable<string> EnumerateDirectories(string root) => System.IO.Directory.EnumerateDirectories(root);
    }
}