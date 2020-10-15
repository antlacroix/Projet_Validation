using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    interface IValidator<T>
        where T : class
    {
        bool IsValide(T t);
    }
}
