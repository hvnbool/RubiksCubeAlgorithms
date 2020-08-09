using System.ComponentModel.DataAnnotations;

namespace RubiksCubeAlgorithms.Models
{
    /// <summary>
    /// Model that describes an algorithm for a Rubik's cube to solve specific case(s)
    /// </summary>
    public class AlgorithmModel
    {
        [Required] public int Id { get; set; }

        [Required] public string Moves { get; set; }
    }
}