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
                if (PropretyValidation.IsStringValide(genre.genre1, genre.genreMin, genre.genreMax))
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

        static public bool IsGenreExist(genre candidate, List<genre> genres)
        {
            List<genre> existingOne = genres.Where(o => o.genre1 == candidate.genre1).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }

    }
}
