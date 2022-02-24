using Domain;
using Domain.Repository;

namespace Data.Repositories
{
    public class ImageRepository : BaseRepository<ImageEntity>, IImageRepository
    {
        public ImageRepository(Context dbContext) : base(dbContext)
        {

        }
    }
}
