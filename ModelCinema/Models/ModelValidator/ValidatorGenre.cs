using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    static public class ValidatorGenre
    {
        //min Length/Value for genre's proprety
        static private int
            genreMin = 2;
        //max Length/Value for genre's proprety
        static private int
            genreMax = 25;

        static public bool IsValide(genre genre)
        {


            try
            {
                if (
                    PropretyValidation.IsStringValide(genre.genre1, genreMin, genreMax)
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

    }
}
