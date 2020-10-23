using ModelCinema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModelCinema.Models.Repository
{
    public class ParticipantRepository : GenericRepository<participant>
    {
        public ParticipantRepository(DbContext context) : base(context)
        {

        }
    }
}