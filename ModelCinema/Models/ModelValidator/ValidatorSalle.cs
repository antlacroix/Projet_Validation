using ModelCinema.ModelExeption;
using ModelCinema.Models.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    static public class ValidatorSalle
    {
        

        static public bool IsValide(salle salle)
        { 
            try
            {
                if (
                    PropretyValidation.IsNumberValide(salle.nbr_place, salle.nbrPlaceMin, salle.nbrPlaceMax) &&
                    PropretyValidation.IsNumberValide(salle.numero_salle, salle.numSalleMin, salle.numSalleMax) &&
                    PropretyValidation.IsStringValide(salle.commentaire, salle.commentaireMin, salle.commentaireMax)
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
        static public bool IsSalleExist(salle candidate, List<salle> salles)
        {
            List<salle> existingOne = salles.Where(o => o.id == candidate.id).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }
        static public bool IsSalleConflict(salle candidate, List<salle> salles)
        {
            List<salle> existingOne = salles.Where(o => o.numero_salle == candidate.numero_salle && o.id != candidate.id).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }

        static public bool IsSalleContainSeance(salle candidate)
        {
            if (candidate == null)
            {
                throw new NullIdExecption("Salle");
            }
            if (candidate.seances.Count() > 0)
                return true;
            else
                return false;
        }

        static public bool IsSalleActive(salle candidate)
        {
            if (candidate == null)
            {
                throw new NullIdExecption("Salle");
            }
            if (candidate.salle_status.status.ToUpper() == "ACTIVE")
                return true;
            else
                return false;
        }
    }
}
