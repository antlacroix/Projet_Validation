using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(user_statusMetaData))]
    public partial class user_status
    {
    }

    public class user_statusMetaData
    {
        [Required]
        [DisplayName("Status")]
        [StringLength(128)]
        public string status { get; set; }
    }
}