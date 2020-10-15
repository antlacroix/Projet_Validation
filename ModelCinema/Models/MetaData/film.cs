using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(filmMetaData))]
    public partial class film
    {
    }

    public class filmMetaData
    {
        [Required]
        [DisplayName("Titre")]
        [StringLength(128)]
        public string titre { get; set; }

        [DisplayName("Description")]
        [StringLength(128)]
        public string description { get; set; }

        [Required]
        [DisplayName("Annee")]
        [Range(1900, 2100)]
        public int annee_parution { get; set; }

        [Required]
        [DisplayName("Duree")]
        [Range(0, 360)]
        public int duree { get; set; }

        [Required]
        [DisplayName("Rating")]
        [Range(0, 5)]
        public double rating { get; set; }

        [Required]
        [DisplayName("Revenue")]
        [Range(0, 100000)]
        public int revenu { get; set; }
    }
}