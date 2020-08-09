using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.WPF.Models;
using RubiksCubeAlgorithms.WPF.ViewModels;
using RubiksCubeAlgorithms.WPF.ViewModelServices.Interfaces;

namespace RubiksCubeAlgorithms.WPF.ViewModelServices.Mock
{
    public class MockMethodService : IMethodService
    {
        private readonly IStepViewModelFactory _stepViewModelFactory;

        public MockMethodService(IStepViewModelFactory stepViewModelFactory)
        {
            _stepViewModelFactory = stepViewModelFactory;
        }

        public async Task<ObservableCollection<StepViewModel>> GetStepsViewModels(int methodId) =>
            await Task.Run(() => methodId switch
                {
                1 => new ObservableCollection<StepViewModel>(Enumerable.Range(1, 3)
                    .Select(i => _stepViewModelFactory.Create(i))),
                2 => new ObservableCollection<StepViewModel>(Enumerable.Range(4, 4)
                    .Select(i => _stepViewModelFactory.Create(i))),
                _ => new ObservableCollection<StepViewModel>()
                });

        public async Task<Method> GetMethod(int methodId) =>
            await Task.Run(() =>
                new Method
                {
                    Id = methodId, Name = GetMethodNameById(methodId), Description = ""
                });

        private static string GetMethodNameById(int methodId) =>
            methodId switch
                {
                1 => "CFOP",
                2 => "Roux",
                _ => "Another method"
                };
    }

    public interface IStepViewModelFactory
    {
        StepViewModel Create(int stepId);
    }
}
