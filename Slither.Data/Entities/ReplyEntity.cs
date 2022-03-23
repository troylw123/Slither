using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Slither.Data.Entities
{
    public class ReplyEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        public CommentEntity Comment { get; set; }

        [ForeignKey("Owner")]
        int AuthorId { get; set; }
        public UserEntity Owner { get; set; }
    }
}