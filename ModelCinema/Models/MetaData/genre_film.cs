using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(genre_cinemaMetaData))]
    public partial class genre_cinema
    {
    }
    public class genre_cinemaMetaData
    {
        [DisplayName("Genre de Film")]
        public int genre_id { get; set; }

        [DisplayName("Film")]
        public int film_id { get; set; }
    }
}
