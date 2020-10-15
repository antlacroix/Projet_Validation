using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(user_typeMetaData))]
    public partial class user_type
    {
    }

    public class user_typeMetaData
    {
        [Required]
        [DisplayName("Status")]
        [StringLength(128)]
        public string type { get; set; }
    }
}