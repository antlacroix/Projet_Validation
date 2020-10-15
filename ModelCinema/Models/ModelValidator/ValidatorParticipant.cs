using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    class ValidatorParticipant : IValidator
    {
        static public bool IsValide(participant participant)
        {
            try
            {
                if (
                    IsParticipantNameValide(participant.name)
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

        static private bool IsParticipantNameValide(string name)
        {
            if (name.Length > 0 && name.Length < 50)
                return true;
            else
                return false;
        }
    }
}
