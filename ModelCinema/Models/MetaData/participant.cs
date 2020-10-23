using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(participantMetaData))]
    public partial class participant
    {
        //min Length/Value for participant's proprety
        public const int
            nameMin = 2;
        //max Length/Value for participant's proprety
        public const int
            nameMax = 50;
    }

    public class participantMetaData
    {
        [Required]
        [DisplayName("Nom")]
        [StringLength(participant.nameMax)]
        public string name { get; set; }
    }
}
