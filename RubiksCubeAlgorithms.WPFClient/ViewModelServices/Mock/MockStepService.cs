using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.WPF.Models;
using RubiksCubeAlgorithms.WPF.ViewModels;
using RubiksCubeAlgorithms.WPF.ViewModelServices.Interfaces;

namespace RubiksCubeAlgorithms.WPF.ViewModelServices.Mock
{
    public class MockStepService : IStepService
    {
        private readonly ICaseViewModelFactory _caseViewModelFactory;

        public MockStepService(ICaseViewModelFactory caseViewModelFactory)
        {
            _caseViewModelFactory = caseViewModelFactory;
        }

        public async Task<Step> GetStep(int stepId) => 
            await Task.Run(() => 
                new Step
                {
                    Id = stepId, 
                    Name = GetStepNameById(stepId), 
                    Description = ""
                });

        public async Task<ObservableCollection<CaseViewModel>> GetCases(int stepId)
        {
            return await Task.Run(() => 
                new ObservableCollection<CaseViewModel>(
                    Enumerable.Range(1, 20).Select(i => 
                        _caseViewModelFactory.Create(i))));
        }

        private static string GetStepNameById(int stepId) =>
            stepId switch
                {
                1 => "F2L",
                2 => "OLL",
                3 => "PLL",
                4 => "SMLL",
                5 => "Last 6 edges: Orientation",
                6 => "Last 6 edges: UL and UR edges",
                7 => "Last 6 edges: Final permutation of M-slice",
                _ => "Another step"
                };
    }

    public interface ICaseViewModelFactory
    {
        CaseViewModel Create(int caseId);
    }
}
