using ModelCinema.Models.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    static public class ValidatorCinema
    {

        static public bool IsCinemaValide(cinema candidate)
        {
            if (PropretyValidation.IsStringValide(candidate.cinema_name, 0, 25))
                return true;
            else
                return false;
        }

        static public bool IsCinemaExist(cinema candidate, List<cinema> cinemas)
        {
            List<cinema> existingOne = cinemas.Where(o => o.id == candidate.id).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }
        static public bool IsCinemaContainSalle(cinema candidate)
        {
            if (candidate.salles.Count > 0)
                return true;
            else
                return false;
        }
    }
}
