using System;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using RubiksCubeAlgorithms.WebApi.Services.Interfaces;

namespace RubiksCubeAlgorithms.WebApi.Services.EFImplementations
{
    public class ImagesService : IImagesService
    {
        private readonly string _rootPath;
        
        public ImagesService(IConfiguration configuration)
        {
            _rootPath = configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
        }
        
        public async Task<byte[]> GetImage(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
                throw new ArgumentNullException(nameof(relativePath));

            relativePath = HttpUtility.UrlDecode(relativePath);

            string imageUri = $"{_rootPath}/Images/{relativePath}";
            if (!System.IO.File.Exists(imageUri))
                return null;

            return await System.IO.File.ReadAllBytesAsync(imageUri);
        }
    }
}