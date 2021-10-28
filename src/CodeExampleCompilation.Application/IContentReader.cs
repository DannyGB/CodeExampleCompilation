using System.Collections.Generic;

namespace CodeExampleCompilation.Application
{
    public interface IContentReader
    {
        IEnumerable<ContentMetaData> Read(string root);
    }
}