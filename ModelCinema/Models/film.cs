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
    
    public partial class film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public film()
        {
            this.genre_film = new HashSet<genre_film>();
            this.participations = new HashSet<participation>();
            this.seances = new HashSet<seance>();
        }
    
        private int id { get; set; }
        private string titre { get; set; }
        private int ranking { get; set; }
        private string description { get; set; }
        private int annee_parution { get; set; }
        private int duree { get; set; }
        private double rating { get; set; }
        private Nullable<double> revenu { get; set; }
        private Nullable<int> votes { get; set; }
        private Nullable<int> metascore { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        private ICollection<genre_film> genre_film { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        private ICollection<participation> participations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        private ICollection<seance> seances { get; set; }
    }
}
