using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    class ValidatorFilm : IValidator
    {
        static public bool IsValide(film film)
        {
            try
            {
                if (
                    //IsFilmTitreExist(film.titre) &&
                    IsFilmDescriptionValide(film.description) &&
                    IsFilmAnneeValide(film.annee_parution) &&
                    IsFilmRatingValide(film.rating) &&
                    IsFilmRevenuValide(film.revenu)
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

        //TO-DO
        //vérifier si le titre du film existe déjà avec DataManager
        //static private bool IsFilmTitreExist(string titre) {}

        static private bool IsFilmTitreValide(string titre)
        {
            if (titre.Length > 0 && titre.Length < 50)
                return true;
            else
                return false;
        }

        static private bool IsFilmDescriptionValide(string description)
        {
            if (description.Length > 0 && description.Length < 50)
                return true;
            else
                return false;
        }

        static private bool IsFilmAnneeValide(int annee)
        {
            if (annee >= 1895)
                return true;
            else
                return false;
        }

        static private bool IsFilmRatingValide(double rating)
        {
            if (rating >= 0)
                return true;
            else
                return false;
        }

        static private bool IsFilmRevenuValide(int revenu)
        {
            if (revenu > 0)
                return true;
            else
                return false;
        }
    }
}
