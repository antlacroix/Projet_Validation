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
                    PropretyValidation.IsStringValide(film.titre, film.titreMin, film.titreMax) &&
                    PropretyValidation.IsStringValide(film.description, film.descriptionMin, film.descriptionMax) &&
                    PropretyValidation.IsNumberValide(film.annee_parution, film.anneeParutionMin, film.anneeParutionMax) &&
                    PropretyValidation.IsNumberValide(film.duree, film.dureeMin, film.dureeMax)
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
            try
            {
                List<film> existingOne = manager.GetAllFilms().Where(o => o.titre == candidate.titre).ToList();
                if (existingOne.Count != 0)
                    return true;
                else
                    return false;
            }
            catch(Exception e)
            {
                throw e;
            }

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
