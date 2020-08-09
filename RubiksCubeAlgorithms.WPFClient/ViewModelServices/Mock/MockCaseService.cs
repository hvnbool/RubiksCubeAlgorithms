using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using RubiksCubeAlgorithms.WPF.Models;
using RubiksCubeAlgorithms.WPF.ViewModelServices.Interfaces;

namespace RubiksCubeAlgorithms.WPF.ViewModelServices.Mock
{
    public class MockCaseService : ICaseService
    {
        public static readonly BitmapImage MockCaseImage;

        static MockCaseService()
        {
            const string path = @"C:\Users\Egor\source\repos\RubiksCubeAlgorithms.WPF\RubiksCubeAlgorithms.WPF\CubePicture.png";
            var uri = new Uri(path);

            if (!File.Exists(path)) return;
            MockCaseImage = new BitmapImage(uri);
            MockCaseImage.Freeze();
        }

        public async Task<Case> GetCase(int caseId) =>
            await Task.Run(() => new Case()
            {
                Id = caseId,
                Name = GetCaseNameById(caseId),
                BitmapImage = MockCaseImage
            });

        public async Task<ObservableCollection<Algorithm>> GetAlgorithmsByCase(int caseId)
        {
            return await Task.Run(() => new ObservableCollection<Algorithm>(
                Enumerable.Range(1, 6).Select(i => 
                    new Algorithm
                    {
                        Id = i, 
                        Moves = "(R U R' U')6"
                    })));
        }

        private static string GetCaseNameById(int caseId) =>
            caseId switch
                {
                1 => "First case",
                2 => "Second case",
                3 => "Third case",
                4 => "Fourth case",
                5 => "Fifth case",
                6 => "Sixth case",
                _ => "Another case"
                };
    }
}
