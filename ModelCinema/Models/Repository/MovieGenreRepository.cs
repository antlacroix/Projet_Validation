using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.Repository
{
    public class MovieGenreRepository : GenericRepository<genre_film>
    {
        public MovieGenreRepository(DbContext context) : base(context)
        {
        }
    }
}
