using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(role_participantMetadata))]
    public partial class role_participant
    {
    }

    public class role_participantMetadata
    {
        [Required]
        [DisplayName("Role")]
        [StringLength(50)]
        public string role { get; set; }
    }
}