using RubiksCubeAlgorithms.WPF.Models;

namespace RubiksCubeAlgorithms.WPF.ViewModels
{
    public class MethodDescriptionViewModel
    {
        public Method Method { get; }

        public MethodDescriptionViewModel(Method method)
        {
            Method = method;
        }
    }
}