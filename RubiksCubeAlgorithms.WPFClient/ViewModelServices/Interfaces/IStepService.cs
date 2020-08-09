using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.WPF.Models;
using RubiksCubeAlgorithms.WPF.ViewModels;

namespace RubiksCubeAlgorithms.WPF.ViewModelServices.Interfaces
{
    public interface IStepService
    {
        Task<Step> GetStep(int stepId);

        Task<ObservableCollection<CaseViewModel>> GetCases(int stepId);
    }
}
