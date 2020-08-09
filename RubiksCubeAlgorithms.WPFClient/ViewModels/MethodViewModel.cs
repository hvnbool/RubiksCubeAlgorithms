using RubiksCubeAlgorithms.WPF.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.WPF.ViewModelServices.Interfaces;

namespace RubiksCubeAlgorithms.WPF.ViewModels
{
    public class MethodViewModel : ViewModelBase
    {
        private readonly IMethodService _service;
        private ObservableCollection<StepViewModel> _stepsViewModels;
        
        
        public StepViewModel CurrentViewModel { get; set; }
        public MethodDescriptionViewModel MethodDescriptionViewModel { get; set; }
        public bool IsMenuVisible { get; private set; }
        public string ShowHideMenuButtonText => IsMenuVisible ? "HIDE" : "SHOW";
        public Method Method { get; private set; }
        public ObservableCollection<StepViewModel> StepsViewModels
        {
            get
            {
                if (_stepsViewModels != null) return _stepsViewModels;
                Task.Run(async () => _stepsViewModels = await _service.GetStepsViewModels(Method.Id)).Wait();
                CurrentViewModel = _stepsViewModels.FirstOrDefault();
                return _stepsViewModels;
            }
        }
        public RelayCommand<object> ShowHideMenuCommand { get;  }

        public MethodViewModel(int methodId, IMethodService service)
        {
            Task[] initTasks =
            {
                Task.Run(async () =>
                { Method = await service.GetMethod(methodId) 
                           ?? throw new Exception($"Method with ID {nameof(methodId)} was not found"); })
            };

            _service = service;
            IsMenuVisible = true;
            ShowHideMenuCommand = new RelayCommand<object>(_ => IsMenuVisible = !IsMenuVisible);

            Task.WaitAll(initTasks);
        }
    }
}
