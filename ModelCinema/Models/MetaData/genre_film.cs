using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(genre_filmMetadata))]
    public partial class genre_film
    {
        public genre_film() { }
        public int Id
        {
            get { return id; }
        }
        public genre Genre
        {
            get { return genre; }
            set
            {
                genre = value;
            }
        }

        public film Movie
        {
            get { return film; }
            set
            {
                film = value;
            }
        }

        public override bool Equals(object obj)
        {
            var movieGenre = obj as genre_film;

            return (Genre == movieGenre.Genre && Movie == movieGenre.Movie);
        }

        public override int GetHashCode()
        {
            int hashGenre = Genre == null ? 0 : Genre.GetHashCode();
            int hashMovie = Movie == null ? 0 : Movie.GetHashCode();

            return hashGenre ^ hashMovie;
        }
    }
    public class genre_filmMetadata
    {
        [DisplayName("Genre de Film")]
        public genre_film Genre { get; set; }

        [DisplayName("Film")]
        public film Movie { get; set; }
    }
}
