using ModelCinema.Models.DataManager;
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
            revenuMin = 0;
        //max Length/Value for film proprety
        static private int
            titreMax = 50,
            descriptionMax = 500,
            anneeParutionMax = DateTime.Now.Year + 50,
            ratingMax = 10,
            revenuMax = 1000000;


        static public bool IsValide(film film)
        {
            try
            {
                if (
                    PropretyValidation.IsStringValide(film.Title, titreMin, titreMax) &&
                    PropretyValidation.IsStringValide(film.Description, descriptionMin, descriptionMax) &&
                    PropretyValidation.IsNumberValide(film.Year, anneeParutionMin, anneeParutionMax) &&
                    PropretyValidation.IsNumberValide(film.Rating, ratingMin, ratingMax) &&
                    PropretyValidation.IsNumberValide(film.Revenue, revenuMin, revenuMax)
                    //&& !IsTitleExist(film)
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

        static private bool IsTitleExist(film candidate)
        {
            ManagerFilm manager = new ManagerFilm();

            List<film> existingOne = manager.GetAllFilms().Where(o => o.Title == candidate.Title).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }

    }
}
