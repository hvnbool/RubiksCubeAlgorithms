using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.Models;

namespace RubiksCubeAlgorithmsWebApi.Services.Interfaces
{
    public interface IStepsService
    {
        Task<ICollection<StepModel>> GetAllAsync();

        Task<StepModel> GetByIdAsync(int id);

        Task<ICollection<MethodModel>> GetMethodsByStepAsync(int stepId);

        Task<ICollection<CaseModel>> GetCasesByStepAsync(int stepId);
    }
}
