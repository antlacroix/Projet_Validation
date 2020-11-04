using ModelCinema.ModelExeption;
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
            if (film == null)
                throw new NullParametreException("IsFilmExist", "film");
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
            catch (Exception e)
            {
                throw e;
            }
        }

        static public bool IsTitleExist(film candidate, List<film> films)
        {
            if (candidate == null)
                throw new NullParametreException("IsFilmExist", "candidate");
            if (films == null)
                throw new NullParametreException("IsFilmExist", "films");
            try
            {
                List<film> existingOne = films.Where(o => o.titre == candidate.titre).ToList();
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

        static public bool IsFilmExist(film candidate, List<film> films)
        {
            if (candidate == null)
                throw new NullParametreException("IsFilmExist", "candidate");
            if (films == null)
                throw new NullParametreException("IsFilmExist", "films");
            List<film> existingOne = films.Where(o => o.id == candidate.id).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }
    }
}
