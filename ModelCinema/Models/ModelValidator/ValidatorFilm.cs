using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    static public class ValidatorFilm
    {
        //min Length/Value for film proprety
        static private int 
            titreMin = 0,
            descriptionMin = 0,
            anneeParutionMin = 1895,
            ratingMin = 0,
            revenuMin =0;
        //max Length/Value for film proprety
        static private int
            titreMax = 50,
            descriptionMax = 50,
            anneeParutionMax = DateTime.Now.Year + 50,
            ratingMax = 10,
            revenuMax = 1000000;


        static public bool IsValide(film film)
        {
            try
            {
                if (
                    PropretyValidation.IsStringValide(film.titre, titreMin, titreMax) &&
                    PropretyValidation.IsStringValide(film.description, descriptionMin, descriptionMax) &&
                    PropretyValidation.IsNumberValide(film.annee_parution, anneeParutionMin, anneeParutionMax) &&
                    PropretyValidation.IsNumberValide(film.rating, ratingMin, ratingMax) &&
                    PropretyValidation.IsNumberValide(film.revenu, revenuMin, revenuMax)
                    )
                {
                    //TO-DO
                    //vérifier si le titre du film existe déjà avec DataManager
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
