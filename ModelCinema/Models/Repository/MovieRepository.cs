using ModelCinema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModelCinema.Models.Repository
{
    public class MovieRepository : GenericRepository<film>
    {
        public MovieRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<film> GetByTitle(string title)
        {
            return dbSet.ToList().Where(movie => movie.Title.Contains(title)).ToList(); ;
        }
    }
}