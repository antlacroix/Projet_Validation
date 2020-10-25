using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.ModelExeption
{
    class SalleHaveSeanceException : Exception
    {
        public SalleHaveSeanceException ()
            : base("cette salle a encore des seances de programmer")
        {

        }
    }
}
