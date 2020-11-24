using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(salleMetaData))]
    public partial class salle
    {
        //public string SalleText { set; get; }
        //public int Id {
        //    get {return this.id; }
        //    set { this.id = value; } }

        //public string SalleColor { set; get; }
        public int SalleGroupId { 
            get {return this.cinema_id; } 
            set {this.cinema_id = value; } }

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
        [DisplayName("Number of Places")]
        [Range(salle.nbrPlaceMin, salle.nbrPlaceMax)]
        public int nbr_place { get; set; }

        [Required]
        [DisplayName("Room Number")]
        [Range(salle.numSalleMin, salle.numSalleMax)]
        public int numero_salle { get; set; }

        [DisplayName("Comment")]
        [StringLength(salle.commentaireMax)]
        public string commentaire { get; set; }

        [DisplayName("Status")]
        public int status_id { get; set; }

        [DisplayName("Cinema")]
        public int cinema_id { get; set; }
    }
}
