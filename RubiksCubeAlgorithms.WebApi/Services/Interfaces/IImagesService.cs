using System.Threading.Tasks;

namespace RubiksCubeAlgorithmsWebApi.Services.Interfaces
{
    public interface IImagesService
    {
        Task<byte[]> GetImage(string relativePath);
    }
}