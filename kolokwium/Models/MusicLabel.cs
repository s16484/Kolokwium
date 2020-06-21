using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Models
{
    public class MusicLabel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMusicLabel { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public IEnumerable<Album> Albums { get; set; }
    }
}