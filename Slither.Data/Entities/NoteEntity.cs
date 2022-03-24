using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Slither.Data.Entities
{
    public class NoteEntity
    {
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int OwnerId { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }
    
    [Required]
    public DateTimeOffset CreatedUtc { get; set; }
    public DateTimeOffset? ModifiedUtc { get; set; }

    }
}