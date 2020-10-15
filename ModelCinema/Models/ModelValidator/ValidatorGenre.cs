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
                    IsGenreTypeValide(genre.genre1)
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

        static public bool IsGenreTypeValide(string genre)
        {
            if (genre.Length > 0 && genre.Length < 50)
                return true;
            else
                return false;
        }
    }
}
