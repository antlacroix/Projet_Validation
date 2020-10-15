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
        public System.DateTime date_debut { get; set; }

        [Required]
        [DisplayName("Date de fin")]
        public System.DateTime date_fin { get; set; }

        [Required]
        [DisplayName("Titre de la seance")]
        [StringLength(128)]
        public string titre_seance { get; set; }
    }
}