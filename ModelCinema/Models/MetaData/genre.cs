﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(genreMetadata))]
    public partial class genre 
    {
        public int Id
        {
            get { return id; }
        }

        public string Genre
        {
            get { return genre1; }
            set
            {
                genre1 = value;
            }
        }

        public ICollection<genre_film> MovieGenres
        {
            get { return genre_film; }
            set
            {
                genre_film = value;
            }
        }

        public override bool Equals(object obj)
        {
            var genre = obj as genre;
            return (this.Genre.Equals(genre.Genre));
        }

        public override int GetHashCode()
        {
            return Genre.GetHashCode();
        }
    }

    public class genreMetadata
    {
        [Required]
        [DisplayName("Genre de Film")]
        [StringLength(50)]
        public string Genre { get; set; }
    }
}
