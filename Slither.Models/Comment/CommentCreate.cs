using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Slither.Models.Comment
{
    public class CommentCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(100, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string Comment { get; set; }
        
        [Required]
    
        public DateTime DateCreated { get; set; }
        public int AuthorId {get; set;}
    }
}