using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RubiksCubeAlgorithms.WebApi.DAL.Entities
{
    /// <summary>
    /// Entity that represents a Rubik's cube case
    /// </summary>
    public class Case
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Relative path to the image for this case (in the Images folder)
        /// </summary>
        [Required]
        public string ImageRelativePath { get; set; }

        #region Navigation Properties

        /// <summary>
        /// Links that connect this case and algorithms that solve it
        /// </summary>
        public ICollection<CaseAlgorithm> CaseAlgorithms { get; set; }

        /// <summary>
        /// Links that connect this case to steps that include it
        /// </summary>
        public ICollection<StepCase> StepCases { get; set; }

        #endregion
    }
}
