using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(cinemaMetaData))]
    public partial class cinema
    {
        public string CinemaText { 
            get { return this.contact_info.adresse;} 
            set { this.contact_info.adresse = value; }
        }
        //public int Id { set; get; }
        public string CinemaColor { set; get; }
    }
    public class cinemaMetaData
    {
        [DisplayName("Contact")]
        public int contact_info_id { get; set; }

        [DisplayName("Responsable")]
        public int responsable_user_id { get; set; }
    }
}
