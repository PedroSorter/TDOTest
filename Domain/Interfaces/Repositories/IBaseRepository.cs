using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> FindAll();
    }
}
