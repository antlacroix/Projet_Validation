using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(cinemaMetaData))]
    public partial class cinema
    {
    }
    public class cinemaMetaData
    {
        [DisplayName("Phone Number")]
        public int contact_info_id { get; set; }

        [DisplayName("Responsable")]
        public int responsable_user_id { get; set; }
    }
}
