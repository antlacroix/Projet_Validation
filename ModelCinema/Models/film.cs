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
            this.programmations = new HashSet<programmation>();
            this.film1 = new HashSet<film>();
            this.participations = new HashSet<participation>();
        }
    
        public int id { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public int annee_parution { get; set; }
        public int duree { get; set; }
        public Nullable<double> rating { get; set; }
        public Nullable<double> revenu { get; set; }
        public Nullable<int> ranking { get; set; }
        public Nullable<int> votes { get; set; }
        public Nullable<int> metascore { get; set; }
        public int id_type { get; set; }
        public Nullable<int> id_film { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<genre_film> genre_film { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<programmation> programmations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<film> film1 { get; set; }
        public virtual film film2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<participation> participations { get; set; }
        public virtual type_film type_film { get; set; }
    }
}
