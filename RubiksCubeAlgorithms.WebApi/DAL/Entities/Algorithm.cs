using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RubiksCubeAlgorithms.WebApi.DAL.Entities
{
    /// <summary>
    /// Entity that represents an algorithm for a Rubik's cube to solve specific case(s)
    /// </summary>
    public class Algorithm
    {
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// String with Rubik's cube moves for this algorithm
        /// </summary>
        [Required]
        [RegularExpression(@"^\(?([UDLRFB][23]?|[udlrfbyxz]2?)'?( \(?([UDLRFB][23]?|[udlrfbyxz]2?)'?\)?[23]?)*$")]
        [HasBalancedBrackets]
        public string Moves { get; set; }

        #region Navigation Properties

        /// <summary>
        /// Collection of links that connect this algorithm and cases that it solves
        /// </summary>
        public ICollection<CaseAlgorithm> CaseAlgorithms { get; set; }
        
        #endregion
    }

    /// <summary>
    /// Validates that a string has balanced brackets (round, curly, square or angle).
    /// Validation succeeds if the attribute is applied to a property of type "string" whose value has balanced brackets.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class HasBalancedBrackets : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (!(value is string str))
                return false;

            var pairs = new SortedDictionary<char, char>
            {
                {'(', ')' },
                {'[', ']' },
                {'{', '}' },
                {'<', '>' }
            };

            var openingBrackets = new Stack<char>();
            foreach (char c in str)
            {
                if (pairs.Keys.Contains(c))
                {
                    openingBrackets.Push(c);
                }
                else if (pairs.Values.Contains(c))
                {
                    if (c == pairs[openingBrackets.Peek()])
                        openingBrackets.Pop();
                    else
                        return false;
                }
            }

            return !openingBrackets.Any();
        }
    }
}
