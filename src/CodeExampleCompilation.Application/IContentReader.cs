using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeExampleCompilation.Application
{
    public interface IContentReader
    {
        Task<IEnumerable<ContentMetaData>> Read(string root);
    }
}