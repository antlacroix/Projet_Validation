//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelCinema.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class seance
    {
        public int id { get; set; }
        public System.DateTime date_debut { get; set; }
        public System.DateTime date_fin { get; set; }
        public string titre_seance { get; set; }
        public int salle_id { get; set; }
        public Nullable<int> film_id { get; set; }
    
        public virtual film film { get; set; }
        public virtual salle salle { get; set; }
    }
}
