using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RubiksCubeAlgorithmsWebApi.DAL.Entities
{
    /// <summary>
    /// Entity that represents a method of solving a Rubik's cube
    /// </summary>
    public class Method
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        #region Navigation Properties

        /// <summary>
        /// Links that connect this method and steps that it consists of
        /// (some steps may be mutually exclusive, i.e. only a subset of them may be required to solve a cube)
        /// </summary>
        public ICollection<MethodStep> MethodSteps { get; set; }

        #endregion
    }
}
