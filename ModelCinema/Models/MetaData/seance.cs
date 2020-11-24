using ModelCinema.Models;
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
        public static DateTime
            dateDebutMin = DateTime.Now,
            dateFinMin = DateTime.Now.AddMinutes(15);
        //max Length/Value for seance's proprety
        public const int
            titreMax = 50;
        public static DateTime
            dateDebutMax = DateTime.Now.AddYears(50),
            dateFinMax = DateTime.Now.AddYears(50);
			
        public bool IsAllDay{ get { return false; } }

        public int CinemaId
        {
            get 
			{
                if (this.salle == null)
                    return 0;
                else
                    return this.salle.cinema_id;
            }
        }
    }

    public class seanceMetaData
    {
        [Required]
        [DisplayName("Start Date")]
        [DataType(DataType.DateTime)]
        public System.DateTime date_debut { get; set; }

        [Required]
        [DisplayName("End Date")]
        [DataType(DataType.DateTime)]
        public System.DateTime date_fin { get; set; }

        [Required]
        [DisplayName("Session Title")]
        [StringLength(seance.titreMax)]
        public string titre_seance { get; set; }

        [DisplayName("Room")]
        public int salle_id { get; set; }
    }
}