//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelCinema.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class participation
    {
        public int id { get; set; }
        public int participant_id { get; set; }
        public int role_id { get; set; }
        public int film_id { get; set; }
    
        public virtual film film { get; set; }
        public virtual participant participant { get; set; }
        public virtual role_participant role_participant { get; set; }
    }
}
