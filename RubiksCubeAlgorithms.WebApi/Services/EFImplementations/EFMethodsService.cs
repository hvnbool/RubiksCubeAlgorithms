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
    public class EFMethodsService : IMethodsService
    {
        private readonly RubiksCubeContext _context;

        public EFMethodsService(RubiksCubeContext context)
        {
            _context = context;
        }

        public async Task<ICollection<MethodModel>> GetAllMethodsAsync()
        {
            return await _context.Methods
                .Select(m => new MethodModel() {Id = m.Id, Name = m.Name})
                .ToListAsync();
        }

        public async Task<MethodModel> GetByIdAsync(int id)
        {
            Method method = await _context.Methods.FindAsync(id);
            return method == null
                ? null
                : new MethodModel()
                {
                    Id = method.Id,
                    Name = method.Name,
                    StepsIds = await _context.MethodSteps
                        .Where(ms => ms.MethodId == id)
                        .Select(ms => ms.StepId).ToArrayAsync()
                };
        }

        public async Task<ICollection<StepModel>> GetStepsByMethodAsync(int methodId)
        {
            if (await _context.Methods.FindAsync(methodId) == null)
                return null;

            return await _context.MethodSteps
                .Where(ms => ms.MethodId == methodId)
                .Select(ms => new StepModel
                {
                    Id = ms.StepId,
                    Name = ms.Step.Name
                })
                .ToArrayAsync();
        }
    }
}
