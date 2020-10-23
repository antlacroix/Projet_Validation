using ModelCinema.Models.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    static public class ValidatorGenre
    {
        static public bool IsValide(genre genre)
        {
            try
            {
                if (PropretyValidation.IsStringValide(genre.Genre, genre.genreMin, genre.genreMax))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        static public bool IsGenreExist(genre candidate)
        {
            ManagerGenre manager = new ManagerGenre();

            List<genre> existingOne = manager.GetAllGenre().Where(o => o.Genre == candidate.Genre).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }

    }
}
