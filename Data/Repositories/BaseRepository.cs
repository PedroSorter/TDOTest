using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }
        public virtual async Task<IEnumerable<T>> FindAll()
        {
            return await _context.Set<T>().Where(a => true).ToListAsync();
        }
    }
}
