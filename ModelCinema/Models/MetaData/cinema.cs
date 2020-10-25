using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(cinemaMetaData))]
    public partial class cinema
    {
        //public int Id
        //{
        //    get { return this.id; }
        //    set { this.id = value; }
        //}
        //public string CinemaText
        //{
        //    get;
        //    set;
        //}
        //public int Id { set; get; }
        //public string CinemaColor { set; get; }
    }
    public class cinemaMetaData
    {
        [DisplayName("Contact")]
        public int contact_info_id { get; set; }

        [DisplayName("Responsable")]
        public int responsable_user_id { get; set; }
    }
}
