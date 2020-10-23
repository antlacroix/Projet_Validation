﻿using System;

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

        public int Id
        {
            get { return id; }
        }
        public string Title
        {
            get { return titre; }
            set
            {
                titre = value;
            }
        }

        public int Ranking
        {
            get { return ranking; }
            set
            {
                ranking = value;
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
            }
        }

        public int Year
        {
            get { return annee_parution; }
            set
            {
                annee_parution = value;
            }
        }

        public int Duration
        {
            get { return duree; }
            set
            {
                duree = value;
            }
        }

        public double Rating
        {
            get { return rating; }
            set
            {
                rating = value;
            }
        }

        public double? Revenue
        {
            get { return revenu; }
            set
            {
                revenu = value;
            }
        }

        public int? Votes
        {
            get { return votes; }
            set
            {
                votes = value;
            }
        }

        public int? Metascore
        {
            get { return metascore; }
            set
            {
                metascore = value;
            }
        }

        public ICollection<genre_film> Genres
        {
            get { return genre_film; }
            set
            {
                genre_film = value;
            }
        }

        public ICollection<participation> Participations
        {
            get { return participations; }
            set
            {
                participations = value;
            }
        }

        public ICollection<seance> Seances
        {
            get { return seances; }
            set
            {
                seances = value;
            }
        }

        public override bool Equals(object obj)
        {
            var movie = obj as film;

            return Title.Equals(movie.Title) &&
                 Description.Equals(movie.Description) &&
                 Year.Equals(movie.Year) &&
                 Duration.Equals(movie.Duration);
        }

        public override int GetHashCode()
        {
            int hashTitle = Title == null ? 0 : Title.GetHashCode();
            int hashDescription = Description == null ? 0 : Description.GetHashCode();
            int hashYear = Year.GetHashCode();
            int hashDuration = Duration.GetHashCode();

            return hashTitle ^ hashDescription ^ hashYear ^ hashDuration;
        }
    }

    public class filmMetadata
    {
        // [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [Required]
        [DisplayName("Titre")]
        [StringLength(film.titreMax)]
        public string Title { get; set; }

        [Required]
        [DisplayName("Classement")]
        [Range(1, 1001)]
        [Column("ranking")]
        public int Ranking { get; set; }

        [DisplayName("Description")]

        [StringLength(film.descriptionMax)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Annee")]
        [Range(film.anneeParutionMin, film.anneeParutionMax)]
        public int Year { get; set; }

        [Required]
        [DisplayName("Duree")]
        [Range(film.dureeMin, film.dureeMax)]
        public int Duration { get; set; }

        [Required]
        [DisplayName("Rating")]
        [Range(film.ratingMin, film.ratingMax)]
        public double Rating { get; set; }

        [Required]
        [DisplayName("Revenue")]
        [Range(film.revenuMin, film.revenuMax)]
        public double? Revenue { get; set; }

        [DisplayName("Votes")]
        [Range(0, 10000000)]
        public int? Votes { get; set; }

        [DisplayName("Metascore")]
        [Range(0, 100)]
        public int? Metascore { get; set; }
    }
}