using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.ModelExeption
{
    class SalleActiveException : Exception
    {

        public SalleActiveException()
            : base("cette salle ne peut etre supprimer car elle est active")
        {

        }
    }
}
