using System.Collections.Generic;

namespace CodeExampleCompilation.Infrastructure
{
    public interface IContentReader
    {
        IEnumerable<ContentMetaData> Read(string root);
    }
}