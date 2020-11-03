using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.ModelExeption
{
    public class MovieUsedInSeanceException : Exception
    {
        public MovieUsedInSeanceException()
            :base("ce film est utilise dans une seance")
        {

        }
    }
}
