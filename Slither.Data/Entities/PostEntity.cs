using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey(nameof(Owner))]
        public int? AuthorId { get; set; }
        public UserEntity Owner { get; set; }

        public List<CommentEntity> Comments { get; set; }

        public List<LikeEntity> Likes { get; set; }

    }
}