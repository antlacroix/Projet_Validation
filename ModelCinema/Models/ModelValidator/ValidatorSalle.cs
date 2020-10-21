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
        //min Length/Value for salle's proprety
        static private int
            nbrPlaceMin = 1,
            numSalleMin = 1,
            commentaireMin = 0;
        //max Length/Value for salle's proprety
        static private int
            nbrPlaceMax = 100,
            numSalleMax = 100,
            commentaireMax = 250;

        static public bool IsValide(salle salle)
        { 
            try
            {
                if (
                    PropretyValidation.IsNumberValide(salle.nbr_place, nbrPlaceMin, nbrPlaceMax) &&
                    PropretyValidation.IsNumberValide(salle.numero_salle, numSalleMin, numSalleMax) &&
                    PropretyValidation.IsStringValide(salle.commentaire, commentaireMin, commentaireMax) &&
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
