using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.ModelExeption
{
    class ItemNotExistException : Exception
    {

        public ItemNotExistException(string objectType)
            : base(String.Format("l'objet '{0}' n'a pas de correspondance dans la DB", objectType))
        {

        }

    }
}
