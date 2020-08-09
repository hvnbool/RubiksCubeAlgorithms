using System.ComponentModel.DataAnnotations;

namespace RubiksCubeAlgorithms.Models
{
    /// <summary>
    /// Model that represents a Rubik's cube case
    /// </summary>
    public class CaseModel
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string ImageRelativePath { get; set; }

        /// <summary>
        /// IDs of algorithms that solve this case
        /// </summary>
        public int[] AlgorithmsIds { get; set; }

        /// <summary>
        /// IDs of steps which include this case
        /// </summary>
        public int[] StepsIds { get; set; }
    }
}