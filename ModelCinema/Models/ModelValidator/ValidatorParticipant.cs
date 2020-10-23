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
        //min Length/Value for participant's proprety
        static private int
            nameMin = 2;
        //max Length/Value for participant's proprety
        static private int
            nameMax = 50;

        static public bool IsValide(participant participant)
        {
            try
            {
                if (
                    PropretyValidation.IsStringValide(participant.Name, nameMin, nameMax) &&
                    !IsParticipantExist(participant)
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

        static private bool IsParticipantExist(participant candidate)
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
