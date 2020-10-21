using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(seanceMetaData))]
    public partial class seance
    {
    }

    public class seanceMetaData
    {
        [Required]
        [DisplayName("Date de debut")]
        [DataType(DataType.DateTime)]
        public System.DateTime date_debut { get; set; }

        [Required]
        [DisplayName("Date de fin")]
        [DataType(DataType.DateTime)]
        public System.DateTime date_fin { get; set; }

        [Required]
        [DisplayName("Titre de la seance")]
        [StringLength(50)]
        public string titre_seance { get; set; }

        [DisplayName("Salle")]
        public int salle_id { get; set; }

        [DisplayName("Film")]
        public int film_id { get; set; }
    }
}