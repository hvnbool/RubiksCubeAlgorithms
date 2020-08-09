using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RubiksCubeAlgorithms.Models
{
    /// <summary>
    /// Model that represents a method of solving a Rubik's cube
    /// </summary>
    public class MethodModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// IDs of Steps that the method includes
        /// </summary>
        public int[] StepsIds { get; set; }
    }
}
