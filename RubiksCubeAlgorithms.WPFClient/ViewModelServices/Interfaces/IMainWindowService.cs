using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.WPF.ViewModels;

namespace RubiksCubeAlgorithms.WPF.ViewModelServices.Interfaces
{
    public interface IMainWindowService
    {
        Task<ObservableCollection<MethodViewModel>> GetMethodsViewModels();
    }
}
