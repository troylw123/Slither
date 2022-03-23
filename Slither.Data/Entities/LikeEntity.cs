using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Slither.Data.Entities
{
    public class LikeEntity
    {
        [Key]
        public int Id { get; set; }
        // [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        // public UserEntity Owner;
    }
}