using Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IImageService
    {
        public Task<IEnumerable<ImageViewModel>> GetImages();
    }
}
