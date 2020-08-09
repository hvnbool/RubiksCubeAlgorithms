using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RubiksCubeAlgorithms.WPF.Models;

namespace RubiksCubeAlgorithms.WPF.ViewModelServices.Interfaces
{
    public interface ICaseService
    {
        Task<Case> GetCase(int caseId);

        Task<ObservableCollection<Algorithm>> GetAlgorithmsByCase(int caseId);
    }
}
