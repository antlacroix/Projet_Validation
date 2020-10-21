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
                if (
                    PropretyValidation.IsStringValide(genre.genre1, genre.genreMin, genre.genreMax) &&
                    !IsGenreExist(genre)
                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //TO-DO
            //Créer et implémenter une exeption 
            catch (Exception e)
            {
                throw e;
            }
        }

        static private bool IsGenreExist(genre candidate)
        {
            ManagerGenre manager = new ManagerGenre();

            List<genre> existingOne = manager.GetAllGenre().Where(o => o.genre1 == candidate.genre1).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }

    }
}
