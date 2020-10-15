using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(salle_statusMetaData))]
    public partial class salle_status
    {
    }

    public class salle_statusMetaData
    {
        [Required]
        [DisplayName("Status")]
        [StringLength(128)]
        public string status { get; set; }
    }
}
