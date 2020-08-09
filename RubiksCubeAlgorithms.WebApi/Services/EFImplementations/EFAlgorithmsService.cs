using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RubiksCubeAlgorithms.Models;
using RubiksCubeAlgorithms.WebApi.DAL;
using RubiksCubeAlgorithms.WebApi.DAL.Entities;
using RubiksCubeAlgorithms.WebApi.Services.Interfaces;

namespace RubiksCubeAlgorithms.WebApi.Services.EFImplementations
{
    public class EFAlgorithmsService : IAlgorithmsService
    {
        private readonly RubiksCubeContext _context;

        public EFAlgorithmsService(RubiksCubeContext context)
        {
            _context = context;
        }

        public async Task<ICollection<AlgorithmModel>> GetAllAsync()
        {
            return await _context.Algorithms
                .Select(a => new AlgorithmModel { Id = a.Id, Moves = a.Moves })
                .ToArrayAsync();
        }

        public async Task<AlgorithmModel> GetByIdAsync(int id)
        {
            Algorithm algorithm = await _context.Algorithms.FindAsync(id);
            if (algorithm == null)
                return null;

            return new AlgorithmModel
            {
                Id = algorithm.Id,
                Moves = algorithm.Moves
            };
        }

        public async Task<ICollection<CaseModel>> GetCasesByAlgorithmAsync(int algorithmId)
        {
            if (await _context.Cases.FindAsync(algorithmId) == null)
                return null;

            return await _context.CaseAlgorithms
                .Where(ca => ca.AlgorithmId == algorithmId)
                .Select(ca => new CaseModel() {Id = ca.CaseId, Name = ca.Case.Name, ImageRelativePath = ca.Case.ImageRelativePath })
                .ToArrayAsync();
        }
    }
}
