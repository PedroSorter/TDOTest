using Domain.Repository;
using Domain.Services;
using Domain.Utils;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public async Task<IEnumerable<ImageViewModel>> GetImages()
        {
            var images = await _imageRepository.FindAll();
            List<ImageViewModel> imagesViewModelList = new List<ImageViewModel>();
            foreach(var image in images)
            {
                var imageViewModel = new ImageViewModel()
                {
                    ImageId = image.ImageId,
                    ImageDescription = image.ImageDescription,
                };

                if (File.Exists(image.ImagePath))
                {
                    using (var reader = new FileStream(image.ImagePath, FileMode.Open))
                    {

                        byte[] buffer = MediaUtil.ReadToEnd(reader);
                        var base64 = MediaUtil.SafeConvertToBase64(buffer);
                        imageViewModel.ImagePath = base64;
                    }
                }

                imagesViewModelList.Add(imageViewModel);
            }

            return imagesViewModelList;
        }
    }
}
