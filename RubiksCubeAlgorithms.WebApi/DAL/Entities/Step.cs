using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RubiksCubeAlgorithms.WebApi.DAL.Entities
{
    /// <summary>
    /// Entity that represents a step of solving a Rubik's cube in one of methods
    /// </summary>
    public class Step
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        #region Navigation Properties

        /// <summary>
        /// Links that connect this step and cases that it includes
        /// </summary>
        public ICollection<StepCase> StepCases { get; set; }

        /// <summary>
        /// Links that connect this step and methods that include this step
        /// </summary>
        public ICollection<MethodStep> MethodSteps { get; set; }

        #endregion
    }
}
