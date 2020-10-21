using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(role_participantMetaData))]
    public partial class role_participant
    {
    }

    public class role_participantMetaData
    {
        [Required]
        [DisplayName("Role")]
        [StringLength(50)]
        public string role { get; set; }
    }
}