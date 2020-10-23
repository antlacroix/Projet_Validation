using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(filmMetaData))]
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
            titreMax = 50,
            descriptionMax = 50,
            anneeParutionMax = 2070,
            dureeMax = 360,
            ratingMax = 5,
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

    public class filmMetaData
    {
       // [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [Required]
        [DisplayName("Titre")]
        [StringLength(film.titreMax)]
        public string titre { get; set; }

        [Required]
        [DisplayName("Description")]
        [StringLength(film.descriptionMax)]
        public string description { get; set; }

        [Required]
        [DisplayName("Annee")]
        [Range(film.anneeParutionMin, film.anneeParutionMax)]
        public int annee_parution { get; set; }

        [Required]
        [DisplayName("Duree")]
        [Range(film.dureeMin, film.dureeMax)]
        public int duree { get; set; }

        [Required]
        [DisplayName("Rating")]
        [Range(film.ratingMin, film.ratingMax)]
        public double rating { get; set; }

        [Required]
        [DisplayName("Revenue")]
        [Range(film.revenuMin, film.revenuMax)]
        public int revenu { get; set; }
    }
}