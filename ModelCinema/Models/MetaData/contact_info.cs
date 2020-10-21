using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(contact_infoMetaData))]
    public partial class contact_info
    {
    }

    public class contact_infoMetaData
    {
        [Required]
        [DisplayName("Phone Number")]
        [StringLength(10)]
        public string tel_number { get; set; }

        [Required]
        [DisplayName("Postal Code")]
        [StringLength(6)]
        public string code_postal { get; set; }

        [Required]
        [DisplayName("Address")]
        [StringLength(50)]
        public string adresse { get; set; }

        [Required]
        [DisplayName("City")]
        [StringLength(50)]
        public string ville { get; set; }

        [Required]
        [DisplayName("Province")]
        [StringLength(20)]
        public string province { get; set; }

        [Required]
        [DisplayName("Country")]
        [StringLength(15)]
        public string pays { get; set; }
    }
}
