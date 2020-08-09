using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.WPF.Models;
using RubiksCubeAlgorithms.WPF.ViewModels;

namespace RubiksCubeAlgorithms.WPF.ViewModelServices.Interfaces
{
    public interface IMethodService
    {
        Task<ObservableCollection<StepViewModel>> GetStepsViewModels(int methodId);
        Task<Method> GetMethod(int methodId);
    }
}
