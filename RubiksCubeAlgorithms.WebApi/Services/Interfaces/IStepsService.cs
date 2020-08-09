using System.Collections.Generic;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.Models;

namespace RubiksCubeAlgorithms.WebApi.Services.Interfaces
{
    public interface IStepsService
    {
        Task<ICollection<StepModel>> GetAllAsync();

        Task<StepModel> GetByIdAsync(int id);

        Task<ICollection<MethodModel>> GetMethodsByStepAsync(int stepId);

        Task<ICollection<CaseModel>> GetCasesByStepAsync(int stepId);
    }
}
