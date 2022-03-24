using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Slither.Models.Posts
{
    public class CreatePost
    {
        [Required]
        public string PostTitle { get; set; }
        [Required]
        [MaxLength(255)]
        public string PostText { get; set; }
        [Required]
        public int? AuthorId { get; set; }

    }
}