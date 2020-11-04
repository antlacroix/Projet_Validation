using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.ModelExeption
{
    public class NullIdExecption : Exception
    {
        public NullIdExecption(string objetType)
            : base (string.Format("aucune {0} avec cette ID existe", objetType))
        {

        }
    }
}
