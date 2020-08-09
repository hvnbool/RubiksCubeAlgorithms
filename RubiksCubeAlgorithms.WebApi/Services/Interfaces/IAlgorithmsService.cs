using System.Collections.Generic;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.Models;

namespace RubiksCubeAlgorithms.WebApi.Services.Interfaces
{
    public interface IAlgorithmsService
    {
        Task<ICollection<AlgorithmModel>> GetAllAsync();

        Task<AlgorithmModel> GetByIdAsync(int id);

        Task<ICollection<CaseModel>> GetCasesByAlgorithmAsync(int algorithmId);
    }
}
