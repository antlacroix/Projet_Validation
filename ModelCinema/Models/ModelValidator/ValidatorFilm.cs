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
        static public bool IsValide(film film)
        {
            try
            {
                if (
                    PropretyValidation.IsStringValide(film.Title, film.titreMin, film.titreMax) &&
                    PropretyValidation.IsStringValide(film.Description, film.descriptionMin, film.descriptionMax) &&
                    PropretyValidation.IsNumberValide(film.Year, film.anneeParutionMin, film.anneeParutionMax) &&
                    PropretyValidation.IsNumberValide(film.Duration, film.dureeMin, film.dureeMax) &&
                    PropretyValidation.IsNumberValide(film.Rating, film.ratingMin, film.ratingMax) &&
                    PropretyValidation.IsNumberValide(film.Revenue, film.revenuMin, film.revenuMax)
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

        static public bool IsTitleExist(film candidate)
        {
            ManagerFilm manager = new ManagerFilm();

            List<film> existingOne = manager.GetAllFilms().Where(o => o.Title == candidate.Title).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }

        static public bool IsFilmExist(film candidate)
        {
            ManagerFilm manager = new ManagerFilm();

            List<film> existingOne = manager.GetAllFilms().Where(o => o.id == candidate.id).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }
    }
}
