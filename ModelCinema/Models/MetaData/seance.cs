using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(seanceMetaData))]
    public partial class seance
    {
        //min Length/Value for seance's proprety
        public const int
            titreMin = 1;
        public DateTime
            dateDebutMin = DateTime.Now,
            dateFinMin = DateTime.Now.AddMinutes(15);
        //max Length/Value for seance's proprety
        public const int
            titreMax = 50;
        public  DateTime
            dateDebutMax = DateTime.Now.AddYears(50),
            dateFinMax = DateTime.Now.AddYears(50);

        public int Id { get { return this.id ; } set { this.id = value; } }
        public string Subject { get { return this.titre_seance; } set { this.titre_seance = value; } }
        public DateTime StartTime { 
            get { return this.date_debut; } 
            set { this.date_debut = value; } }
        public DateTime EndTime { 
            get { return this.date_fin; } 
            set { this.date_fin = value; } }

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
        [StringLength(seance.titreMax)]
        public string titre_seance { get; set; }

        [DisplayName("Salle")]
        public int salle_id { get; set; }

        [DisplayName("Film")]
        public int film_id { get; set; }
    }
}