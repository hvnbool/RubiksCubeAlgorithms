using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.WPF.ViewModelServices.Interfaces;

namespace RubiksCubeAlgorithms.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IMainWindowService _service;
        public ObservableCollection<MethodViewModel> MethodsViewModels { get; private set; }
        public ViewModelBase CurrentViewModel { get; set; }


        public MainWindowViewModel(IMainWindowService service)
        {
            Task[] initTasks =
            {
                Task.Run(async () =>
                {
                    MethodsViewModels = await service.GetMethodsViewModels();
                    CurrentViewModel = MethodsViewModels.FirstOrDefault();
                })
            };

            _service = service;
            Task.WaitAll(initTasks);
        }
    }
}
