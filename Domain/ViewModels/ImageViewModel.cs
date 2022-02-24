using System;

namespace Domain.ViewModels
{
    public sealed class ImageViewModel
    {
        public Guid ImageId { get; set; }
        public string ImageDescription { get; set; }
        public string ImagePath { get; set; }
    }
}
