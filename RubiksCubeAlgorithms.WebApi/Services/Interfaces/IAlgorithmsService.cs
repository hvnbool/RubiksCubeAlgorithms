using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.Models;

namespace RubiksCubeAlgorithmsWebApi.Services.Interfaces
{
    public interface IAlgorithmsService
    {
        Task<ICollection<AlgorithmModel>> GetAllAsync();

        Task<AlgorithmModel> GetByIdAsync(int id);

        Task<ICollection<CaseModel>> GetCasesByAlgorithmAsync(int algorithmId);
    }
}
