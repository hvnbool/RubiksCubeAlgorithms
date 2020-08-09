using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.WPF.Models;
using RubiksCubeAlgorithms.WPF.ViewModelServices.Interfaces;

namespace RubiksCubeAlgorithms.WPF.ViewModels
{
    public class CaseViewModel : ViewModelBase
    {
        private readonly ICaseService _caseService;
        public Case Case { get; private set; }
        public ObservableCollection<Algorithm> Algorithms { get; private set; }

        public CaseViewModel(int caseId, ICaseService caseService)
        {
            Task[] initTasks =
            {
                Task.Run(async () => { Case = await caseService.GetCase(caseId); }),
                Task.Run(async () => { Algorithms = await caseService.GetAlgorithmsByCase(caseId); })
            };

            _caseService = caseService;
            Task.WaitAll(initTasks);
        }
    }
}
