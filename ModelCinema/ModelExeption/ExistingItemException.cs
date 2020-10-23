using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.ModelExeption
{
    class ExistingItemException : Exception
    {
        public ExistingItemException(string objectType)
            : base(String.Format("cet '{0}' existe deja", objectType))
        {

        }
    }
}
