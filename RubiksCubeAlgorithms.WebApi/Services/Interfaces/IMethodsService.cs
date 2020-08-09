using System.Collections.Generic;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.Models;

namespace RubiksCubeAlgorithms.WebApi.Services.Interfaces
{
    public interface IMethodsService
    {
        Task<ICollection<MethodModel>> GetAllMethodsAsync();

        Task<MethodModel> GetByIdAsync(int id);

        Task<ICollection<StepModel>> GetStepsByMethodAsync(int methodId);
    }
}
