using System.Collections.Generic;
using System.Threading.Tasks;
using CodeExampleCompilation.Domain;

namespace CodeExampleCompilation.Application
{
    public interface IContentReader
    {
        Task<IEnumerable<ContentFile>> Read(string root);
    }
}