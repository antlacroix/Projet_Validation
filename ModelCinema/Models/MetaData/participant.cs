﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(participantMetaData))]
    public partial class participant
    {
    }

    public class participantMetaData
    {
        [Required]
        [DisplayName("Nom")]
        [StringLength(50)]
        public string name { get; set; }
    }
}
