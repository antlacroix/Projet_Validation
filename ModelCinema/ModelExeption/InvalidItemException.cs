using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.ModelExeption
{
    class InvalidItemException : Exception
    {
        public InvalidItemException(string objectType) 
            : base(String.Format("l'objet '{0}' contient une information invalide", objectType))
        {

        }
    }
}
