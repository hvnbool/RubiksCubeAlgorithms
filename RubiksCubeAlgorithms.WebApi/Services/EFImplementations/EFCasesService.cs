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
    public class EFCasesService : ICasesService
    {
        private readonly RubiksCubeContext _context;

        public EFCasesService(RubiksCubeContext context)
        {
            _context = context;
        }

        public async Task<ICollection<CaseModel>> GetAllAsync()
        {
            return await _context.Cases
                .Select(c => new CaseModel
                {
                    Id = c.Id, 
                    Name = c.Name, 
                    ImageRelativePath = c.ImageRelativePath
                })
                .ToArrayAsync();
        }

        public async Task<CaseModel> GetByIdAsync(int id)
        {
            Case @case = await _context.Cases.FindAsync(id);
            if (@case == null)
                return null;

            return new CaseModel()
            {
                Id = @case.Id,
                Name = @case.Name,
                ImageRelativePath = @case.ImageRelativePath,
                AlgorithmsIds = await _context.CaseAlgorithms
                    .Where(ca => ca.CaseId == id)
                    .Select(ca => ca.AlgorithmId)
                    .ToArrayAsync()
            };
        }

        public async Task<ICollection<StepModel>> GetStepsByCase(int caseId)
        {
            if (await _context.Cases.FindAsync(caseId) == null)
                return null;

            return await _context.StepCases
                .Where(sc => sc.CaseId == caseId)
                .Select(sc => new StepModel() { Id = sc.StepId, Name = sc.Step.Name })
                .ToListAsync();
        }

        public async Task<ICollection<AlgorithmModel>> GetAlgorithmsByCase(int caseId)
        {
            if (await _context.Cases.FindAsync(caseId) == null)
                return null;

            return await _context.CaseAlgorithms
                .Where(ca => ca.CaseId == caseId)
                .Select(ca => new AlgorithmModel() { Id = ca.AlgorithmId, Moves = ca.Algorithm.Moves })
                .ToListAsync();
        }
    }
}
