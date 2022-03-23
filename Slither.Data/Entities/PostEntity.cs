using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Slither.Data.Entities
{
    public class PostEntity
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public string PostTitle { get; set; }

        [Required]
        public string PostText { get; set; }

        // list of comments
        //list of likes

        // Foreign key adaptaion Author Id

    }
}