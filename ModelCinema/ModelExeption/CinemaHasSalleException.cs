using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.ModelExeption
{
    class CinemaHasSalleException : Exception
    {
        public CinemaHasSalleException()
            : base("ce cinema contient encore des salles")
        {

        }
    }
}
