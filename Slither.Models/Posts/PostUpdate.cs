using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Slither.Models.Posts
{
    public class PostUpdate
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "{0} must be at least {2} characters.")]
        [MaxLength(100, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string PostTitle { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string PostText { get; set; }

    }
}