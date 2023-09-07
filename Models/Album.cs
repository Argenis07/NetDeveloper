using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Album")]
    public partial class Album
    {
        public Album()
        {
            Tracks = new HashSet<Track>();
        }

        public int Albumid { get; set; }

        [Required]
        [StringLength(160)]
        public string Title { get; set; }

        public int Artistid { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }

        public virtual Artist Artista { get; set; }
    }
}
