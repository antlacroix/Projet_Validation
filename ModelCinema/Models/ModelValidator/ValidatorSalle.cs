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
                    PropretyValidation.IsStringValide(salle.commentaire, salle.commentaireMin, salle.commentaireMax) &&
                    !IsSalleExist(salle)
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
        static private bool IsSalleExist(salle candidate)
        {
            ManagerSalle manager = new ManagerSalle();

            List<salle> existingOne = manager.GetAllSalle().Where(o => o.cinema_id == candidate.cinema_id && o.numero_salle == candidate.numero_salle).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }
    }
}
