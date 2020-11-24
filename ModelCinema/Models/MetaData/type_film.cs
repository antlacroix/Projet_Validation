
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(type_filmMetaData))]
    public partial class type_film
    { }

       public class type_filmMetaData
    {
        [Required]
        [DisplayName("Type")]
        public string typage { get; set; }
    }
}





