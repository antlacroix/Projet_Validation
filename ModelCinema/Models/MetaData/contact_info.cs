using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(contact_infoMetaData))]
    public partial class contact_info
    {
        //min Length/Value for contact's proprety
        public const int
            telephoneMin = 10,
            codePostalMin = 6,
            AdressMin = 5,
            villeMin = 2,
            provinceMin = 2,
            paysMin = 2;
        //max Length/Value for contact's proprety
        public const int
            telephoneMax = 10,
            codePostalMax = 6,
            AdressMax = 50,
            villeMax = 50,
            provinceMax = 20,
            paysMax = 15;
        //regEx string for conctat's proprty
        public const string
            telephoneRegEx = "[0-9]{10}",
            codePostalRegEx = "[A-Za-z][\\d][A-Za-z][\\d][A-Za-z][\\d]";
    }

    public class contact_infoMetaData
    {
        [Required]
        [DisplayName("Phone Number")]
        [StringLength(contact_info.telephoneMax)]
        public string tel_number { get; set; }

        [Required]
        [DisplayName("Postal Code")]
        [StringLength(contact_info.codePostalMax)]
        public string code_postal { get; set; }

        [Required]
        [DisplayName("Address")]
        [StringLength(contact_info.AdressMax)]
        public string adresse { get; set; }

        [Required]
        [DisplayName("City")]
        [StringLength(contact_info.villeMax)]
        public string ville { get; set; }

        [Required]
        [DisplayName("Province")]
        [StringLength(contact_info.provinceMax)]
        public string province { get; set; }

        [Required]
        [DisplayName("Country")]
        [StringLength(contact_info.paysMax)]
        public string pays { get; set; }
    }
}
