using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Artist")]
    public partial class Artist
    {
        public int Artistid { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }
    }
}
