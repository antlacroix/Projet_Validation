using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(userMetaData))]
    public partial class user
    {
    }

    public class userMetaData
    {
        [Required]
        [DisplayName("Login")]
        [StringLength(15)]
        public string login { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(25)]
        [PasswordPropertyText]
        public string password { get; set; }

        [Required]
        [DisplayName("Name")]
        [StringLength(50)]
        public string name { get; set; }

        [DisplayName("Phone Number")]
        public int contact_info_id { get; set; }

        [DisplayName("Status of user")]
        public int user_status_id { get; set; }

        [DisplayName("User type")]
        public int user_type_id { get; set; }

    }
}