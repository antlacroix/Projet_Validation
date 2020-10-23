using ModelCinema.Models.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    static public class ValidatorParticipant
    {
        static public bool IsValide(participant participant)
        {
            try
            {
                if (PropretyValidation.IsStringValide(participant.Name, participant.nameMin, participant.nameMax))
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

        static public bool IsParticipantExist(participant candidate)
        {
            ManagerParticipant manager = new ManagerParticipant();

            List<participant> existingOne = manager.GetAllParticipant().Where(o => o.Name == candidate.Name).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }
    }
}
