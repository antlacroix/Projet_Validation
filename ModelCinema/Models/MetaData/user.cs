using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(userMetaData))]
    public partial class user
    {
        //min Length/Value for user's proprety
        public const int
            loginMin = 5,
            passwordMin = 6,
            nameMin = 3;
        //max Length/Value for user's proprety
        public const int
            loginMax = 15,
            passwordMax = 25,
            nameMax = 50;
    }

    public class userMetaData
    {
        [Required]
        [DisplayName("Login")]
        [StringLength(user.loginMax)]
        public string login { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(user.passwordMax)]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        public string password { get; set; }

        [Required]
        [DisplayName("Name")]
        [StringLength(user.nameMax)]
        public string name { get; set; }

        [DisplayName("Phone Number")]
        public int contact_info_id { get; set; }

        [DisplayName("Status of user")]
        public int user_status_id { get; set; }

        [DisplayName("User type")]
        public int user_type_id { get; set; }

    }
}