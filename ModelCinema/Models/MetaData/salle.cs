﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(salleMetaData))]
    public partial class salle
    {
    }

    public class salleMetaData
    {
        [Required]
        [DisplayName("Nombre de place")]
        [Range(0,500)]
        public int nbr_place { get; set; }

        [Required]
        [DisplayName("Numero de la salle")]
        [Range(0, 500)]
        public int numero_salle { get; set; }

        [DisplayName("Commentaire")]
        [StringLength(128)]
        public string commentaire { get; set; }
    }
}
