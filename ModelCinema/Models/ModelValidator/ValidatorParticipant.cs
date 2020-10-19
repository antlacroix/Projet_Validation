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
                    PropretyValidation.IsStringValide(participant.name, nameMin, nameMax)
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
    }
}
