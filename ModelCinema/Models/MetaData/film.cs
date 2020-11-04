using System;

using System.Collections.Generic;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelCinema.Models
{
    [MetadataType(typeof(filmMetadata))]
    public partial class film
    {
        //min Length/Value for film proprety
        public const int
            titreMin = 0,
            descriptionMin = 0,
            anneeParutionMin = 1895,
            dureeMin = 0,
            ratingMin = 0,
            revenuMin = 0;
        //max Length/Value for film proprety
        public const int
            titreMax = 100,
            descriptionMax = 500,
            anneeParutionMax = 2070,
            dureeMax = 360,
            ratingMax = 10,
            revenuMax = 1000000;

        public film(string titre, string description, int annee, int duree, double rating, int revenu)
        {
            this.titre = titre;
            this.description = description;
            this.annee_parution = annee;
            this.duree = duree;
            this.rating = rating;
            this.revenu = revenu;
        }
    }

    public class filmMetadata
    {
        // [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [Required]
        [DisplayName("Titre")]
        [StringLength(film.titreMax, ErrorMessage = "titre")]
        public string titre { get; set; }

        [DisplayName("Classement")]
        [Range(0, 1001, ErrorMessage = "Ranking")]
        public int ranking { get; set; }

        [DisplayName("Description")]
        [StringLength(film.descriptionMax, ErrorMessage = "description")]
        public string description { get; set; }

        [Required]
        [DisplayName("Annee")]
        [Range(film.anneeParutionMin, film.anneeParutionMax, ErrorMessage = "annee")]
        public int annee_parution { get; set; }

        [Required]
        [DisplayName("Duree")]
        [Range(film.dureeMin, film.dureeMax, ErrorMessage = "duration")]
        public int duree { get; set; }

        [DisplayName("Rating")]
        [Range(film.ratingMin, film.ratingMax, ErrorMessage = "rating")]
        public double rating { get; set; }

        [DisplayName("Revenue")]
        [Range(film.revenuMin, film.revenuMax, ErrorMessage = "revenue")]
        public double? revenu { get; set; }

        [DisplayName("Votes")]
        [Range(0, 10000000, ErrorMessage = "votes")]
        public int? votes { get; set; }

        [DisplayName("Metascore")]
        [Range(0, 100, ErrorMessage = "metascore")]
        public int? metascore { get; set; }

        [Required]
        [DisplayName("Typage")]
        public int id_type { get; set; }

        [DisplayName("Titre")]
        public int? id_film { get; set; }
    }
}
