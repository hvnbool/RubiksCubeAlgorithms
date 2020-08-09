using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.Models;

namespace RubiksCubeAlgorithmsWebApi.Services.Interfaces
{
    public interface IMethodsService
    {
        Task<ICollection<MethodModel>> GetAllMethodsAsync();

        Task<MethodModel> GetByIdAsync(int id);

        Task<ICollection<StepModel>> GetStepsByMethodAsync(int methodId);
    }
}
