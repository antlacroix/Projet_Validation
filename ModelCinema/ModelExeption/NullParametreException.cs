using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.ModelExeption
{
    public class NullParametreException : Exception
    {
        public NullParametreException(string methodName, string parametreName)
            : base($"this exception was raised because {parametreName} in {methodName} was null")
        {

        }
    }
}
