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
        [StringLength(128)]
        public string login { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(128)]
        [PasswordPropertyText]
        public string password { get; set; }

        [Required]
        [DisplayName("Name")]
        [StringLength(128)]
        public string name { get; set; }
    }
}