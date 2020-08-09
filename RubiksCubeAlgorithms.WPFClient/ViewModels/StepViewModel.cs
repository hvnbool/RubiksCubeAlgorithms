using RubiksCubeAlgorithms.WPF.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.WPF.ViewModelServices.Interfaces;

namespace RubiksCubeAlgorithms.WPF.ViewModels
{
    public class StepViewModel : ViewModelBase
    {
        private readonly IStepService _service;
        public Step Step { get; private set; }
        public ObservableCollection<CaseViewModel> Cases { get; private set; }
        public RelayCommand<object> SelectCaseCommand { get; }
        public CaseViewModel SelectedCaseViewModel { get; private set; }
        public bool CaseViewVisible => SelectedCaseViewModel != null;

        public StepViewModel(int stepId, IStepService service)
        {
            Task[] initTasks = {
                Task.Run(async () => { Cases = await service.GetCases(stepId); }),
                Task.Run(async () => { Step = await service.GetStep(stepId); })
            };

            _service = service;
            SelectCaseCommand = new RelayCommand<object>(SelectCase);
            
            Task.WaitAll(initTasks);
        }

        private void SelectCase(object o)
        {
            SelectedCaseViewModel = o as CaseViewModel;
        }
    }
}
