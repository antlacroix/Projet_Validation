using ModelCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.ModelExeption
{
    class ConflictiongSeanceException : Exception
    {
        public ConflictiongSeanceException(List<seance> seances)
            : base("cette nouvelle seance est en conflit avec une seance existante")
        {
            Data[0] = seances;
        }
    }
}
