using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Models
{
    [Table("Musician_Track")]
    public class MusicianTrack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMusicianTrack { get; set; }
        

        public int IdTrack { get; set; }
        public int IdMusician { get; set; }

        [ForeignKey("IdTrack")]
        public Track Track { get; set; }

        [ForeignKey("IdMusician")]
        public Musician Musician { get; set; }
    }
}