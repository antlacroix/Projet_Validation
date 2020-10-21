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
        [DisplayName("Status de la salle")]
        [StringLength(10)]
        public string status { get; set; }
    }
}
