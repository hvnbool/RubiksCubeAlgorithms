using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using RubiksCubeAlgorithmsWebApi.Services.Interfaces;

namespace RubiksCubeAlgorithmsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImagesService _imagesService;
        private readonly string _rootPath;

        public ImagesController(IConfiguration configuration, IImagesService imagesService)
        {
            _imagesService = imagesService;
            _rootPath = configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
        }

        /// <summary>
        /// Get specified image for download
        /// </summary>
        /// <param name="relativePath">Relative path to the image to download</param>
        /// <returns>The image</returns>
        /// <response code="200">Image has been successfully retrieved</response>
        /// <response code="404">Image with specified relative path was not found</response>
        [HttpGet("{*relativePath}")]
        public async Task<ActionResult> Download([FromRoute] string relativePath)
        {
            try
            {
                byte[] fileBytes = await _imagesService.GetImage(relativePath);
                if (fileBytes == null)
                    return NotFound(new { Message = "Image with specified relative path was not found"});
                return File(
                    fileContents: fileBytes,
                    contentType: "image/png", //TODO: Generalize for all file (or at least image) types
                    fileDownloadName: relativePath.Split('/').Last());
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new {Message = "Provided relative path was null or empty"});
            }
        }
    }
}
