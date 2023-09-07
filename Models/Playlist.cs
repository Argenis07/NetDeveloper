using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Playlist")]
    public partial class Playlist
    {
        public int Playlistid { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }
    }
}
