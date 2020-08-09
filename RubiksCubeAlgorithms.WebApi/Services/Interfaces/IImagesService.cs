using System.Threading.Tasks;

namespace RubiksCubeAlgorithms.WebApi.Services.Interfaces
{
    public interface IImagesService
    {
        Task<byte[]> GetImage(string relativePath);
    }
}