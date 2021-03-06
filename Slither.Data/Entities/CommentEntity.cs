using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slither.Data.Entities
{
    public class CommentEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        
        [ForeignKey(nameof(Owner))]
        public int? AuthorId { get; set; }
        public UserEntity Owner { get; set; }
        

        public List<ReplyEntity> Replies { get; set; }

        [ForeignKey(nameof(Post))]
        public int? PostId { get; set; }
        public PostEntity Post { get; set; }
        
    }
}