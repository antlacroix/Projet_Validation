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
        [StringLength(12)]
        public string tel_number { get; set; }

        [DisplayName("Postal Code")]
        [StringLength(7)]
        public string code_postal { get; set; }

        [DisplayName("Address")]
        [StringLength(50)]
        public string adresse { get; set; }

        [DisplayName("City")]
        [StringLength(50)]
        public string ville { get; set; }

        [DisplayName("Province")]
        [StringLength(25)]
        public string province { get; set; }

        [DisplayName("Country")]
        [StringLength(25)]
        public string pays { get; set; }
    }
}
