using System.ComponentModel.DataAnnotations;

namespace RubiksCubeAlgorithms.WebApi.DAL.Entities
{
    /// <summary>
    /// Entity for many-to-many relationship between methods and steps that these methods include 
    /// </summary>
    public class MethodStep
    {
        [Required]
        public int MethodId { get; set; }

        [Required]
        public int StepId { get; set; }

        #region Navigation Properties

        public Method Method { get; set; }
        
        public Step Step { get; set; }

        #endregion
    }
}
