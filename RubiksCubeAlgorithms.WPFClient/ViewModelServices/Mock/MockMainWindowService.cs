using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.WPF.ViewModels;
using RubiksCubeAlgorithms.WPF.ViewModelServices.Interfaces;

namespace RubiksCubeAlgorithms.WPF.ViewModelServices.Mock
{
    public class MockMainWindowService : IMainWindowService
    {
        private readonly IMethodViewModelFactory _methodViewModelFactory;

        public MockMainWindowService(IMethodViewModelFactory methodViewModelFactory)
        {
            _methodViewModelFactory = methodViewModelFactory;
        }

        public async Task<ObservableCollection<MethodViewModel>> GetMethodsViewModels()
        {
            return await Task.Run(() => new ObservableCollection<MethodViewModel>
            {
                _methodViewModelFactory.Create(1),
                _methodViewModelFactory.Create(2),
                _methodViewModelFactory.Create(3)
            });
        }
    }

    public interface IMethodViewModelFactory
    {
        MethodViewModel Create(int methodId);
    }
}
