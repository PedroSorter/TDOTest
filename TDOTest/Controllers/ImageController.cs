using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace TDOTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> Images()
        {
            var images = await _imageService.GetImages();
            if (images.Any())
            {
                return Ok(images);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        } 
    }
}
