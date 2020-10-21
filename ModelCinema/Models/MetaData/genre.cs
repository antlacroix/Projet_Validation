using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(genreData))]
    public partial class genre
    {
        //min Length/Value for genre's proprety
        public const int
            genreMin = 2;
        //max Length/Value for genre's proprety
        public const int
            genreMax = 25;
    }

    public class genreData
    {
        [Required]
        [DisplayName("Genre de Film")]
        [StringLength(genre.genreMax)]
        public string genre1 { get; set; }
    }
}
