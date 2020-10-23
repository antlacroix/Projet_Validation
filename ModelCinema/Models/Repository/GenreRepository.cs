using ModelCinema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModelCinema.Models.Repository
{
    public class GenreRepository : GenericRepository<genre>
    {
        public GenreRepository(DbContext context) : base(context)
        {
        }
    }
}