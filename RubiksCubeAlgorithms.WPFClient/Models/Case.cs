using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace RubiksCubeAlgorithms.WPF.Models
{
    public class Case
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BitmapImage BitmapImage { get; set; }
    }
}
