using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Track")]
    public partial class Track
    {
        public int TrackId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int GenreId { get; set; }

        [StringLength(200)]
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }

        [Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; }
    }
}
