using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(user_typeMetaData))]
    public partial class user_type
    {
        //min Length/Value for userType's proprety
        public const int
            typeMin = 2;
        //max Length/Value for userType's proprety
        public const int
            typeMax = 10;
    }

    public class user_typeMetaData
    {
        [Required]
        [DisplayName("Type user")]
        [StringLength(10)]
        public string type { get; set; }
    }
}