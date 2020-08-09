using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.Models;

namespace RubiksCubeAlgorithmsWebApi.Services.Interfaces
{
    public interface ICasesService
    {
        Task<ICollection<CaseModel>> GetAllAsync();

        Task<CaseModel> GetByIdAsync(int id);

        Task<ICollection<StepModel>> GetStepsByCase(int caseId);

        Task<ICollection<AlgorithmModel>> GetAlgorithmsByCase(int caseId);
    }
}
