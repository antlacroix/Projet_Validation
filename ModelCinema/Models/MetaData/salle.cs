using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(salleMetaData))]
    public partial class salle
    {
        //min Length/Value for salle's proprety
        public const int
            nbrPlaceMin = 1,
            numSalleMin = 1,
            commentaireMin = 0;
        //max Length/Value for salle's proprety
        public const int
            nbrPlaceMax = 100,
            numSalleMax = 100,
            commentaireMax = 250;
    }

    public class salleMetaData
    {
        [Required]
        [DisplayName("Nombre de place")]
        [Range(salle.nbrPlaceMin, salle.nbrPlaceMax)]
        public int nbr_place { get; set; }

        [Required]
        [DisplayName("Numero de la salle")]
        [Range(salle.numSalleMin, salle.numSalleMax)]
        public int numero_salle { get; set; }

        [DisplayName("Commentaire")]
        [StringLength(salle.commentaireMax)]
        public string commentaire { get; set; }

        [DisplayName("Status de la salle")]
        public int status_id { get; set; }

        [DisplayName("Cinema")]
        public int cinema_id { get; set; }
    }
}
