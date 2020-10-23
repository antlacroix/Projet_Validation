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

        static public bool IsCinemaExist(cinema candidate)
        {
            ManagerCinema manager = new ManagerCinema();

            List<cinema> existingOne = manager.GetAllCinema().Where(o => o.id == candidate.id).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }
    }
}
