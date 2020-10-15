using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(genreData))]
    public partial class genre
    {
    }

    public class genreData
    {
        [Required]
        [DisplayName("Genre de Film")]
        [StringLength(128)]
        public string genre1 { get; set; }
    }
}
