using System.ComponentModel.DataAnnotations;

namespace RubiksCubeAlgorithmsWebApi.DAL.Entities
{
    /// <summary>
    /// Entity for many-to-many relationships between steps and cases that can be encountered during these steps
    /// </summary>
    public class StepCase
    {
        [Required]
        public int StepId { get; set; }

        [Required]
        public int CaseId { get; set; }

        #region Navigation Properties

        public Step Step { get; set; }

        public Case Case { get; set; }

        #endregion
    }
}
