using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.ModelExeption
{
    class SeanceToShortException : Exception
    {
        public SeanceToShortException()
            : base("la seance est trop courte pour acomoder ce film")
        {

        }
    }
}
