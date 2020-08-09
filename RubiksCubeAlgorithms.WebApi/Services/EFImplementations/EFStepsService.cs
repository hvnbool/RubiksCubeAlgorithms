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
    public class EFStepsService : IStepsService
    {
        private readonly RubiksCubeContext _context;

        public EFStepsService(RubiksCubeContext context)
        {
            _context = context;
        }

        public async Task<ICollection<StepModel>> GetAllAsync() 
            => await _context.Steps
                .Select(s => new StepModel { Id = s.Id, Name = s.Name })
                .ToArrayAsync();

        public async Task<StepModel> GetByIdAsync(int id)
        {
            Step step = await _context.Steps.FindAsync(id);
            if (step == null)
                return null;

            return new StepModel
            {
                Id = step.Id,
                Name = step.Name,
                CasesIds = await _context.StepCases
                    .Where(sc => sc.StepId == id)
                    .Select(sc => sc.CaseId)
                    .ToArrayAsync()
            };
        }

        public async Task<ICollection<MethodModel>> GetMethodsByStepAsync(int stepId)
        {
            if (await _context.Steps.FindAsync(stepId) == null)
                return null;

            return await _context.MethodSteps
                .Where(ms => ms.StepId == stepId)
                .Select(ms => new MethodModel { Id = ms.MethodId, Name = ms.Method.Name })
                .ToArrayAsync();
        }

        public async Task<ICollection<CaseModel>> GetCasesByStepAsync(int stepId)
        {
            if (await _context.Steps.FindAsync(stepId) == null)
                return null;

            return await _context.StepCases
                .Where(sc => sc.StepId == stepId)
                .Select(sc => new CaseModel { Id = sc.CaseId, Name = sc.Case.Name, ImageRelativePath = sc.Case.ImageRelativePath })
                .ToArrayAsync();
        }
    }
}
