using System.ComponentModel.DataAnnotations;

namespace RubiksCubeAlgorithms.WebApi.DAL.Entities
{
    /// <summary>
    /// Entity for many-to-many relationships between cases and algorithms that solve them
    /// </summary>
    public class CaseAlgorithm
    {
        [Required]
        public int CaseId { get; set; }

        [Required]
        public int AlgorithmId { get; set; }

        #region Navigation Properties

        public Case Case { get; set; }

        public Algorithm Algorithm { get; set; }

        #endregion
    }
}
