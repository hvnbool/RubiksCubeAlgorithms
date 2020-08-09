using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RubiksCubeAlgorithms.Models
{
    /// <summary>
    /// Model that represents a step of solving a Rubik's cube
    /// </summary>
    public class StepModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// IDs of cases for this step
        /// </summary>
        public int[] CasesIds { get; set; }

        /// <summary>
        /// IDs of methods that include this step
        /// </summary>
        public int[] MethodsIDs { get; set; }
    }
}
