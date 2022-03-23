using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Slither.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id {get; set;}
        [Required]
        [EmailAddress]
        public string Email {get; set;}
        [Required]
        public string Username {get; set;}
        [Required]
        public string Password {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        [Required]
        public DateTime DateCreated {get; set;}

        public List<PostEntity> Posts { get; set; }
        public List<CommentEntity> Comments { get; set; }
        public List<ReplyEntity> Replies { get; set; }
        public List<LikeEntity> Likes { get; set; }

    }
}