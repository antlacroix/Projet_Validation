using ModelCinema.Models.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    class ValidatorUserType
    {
        static public bool IsValide(user_type candidate)
        {
            try
            {
                if (
                    PropretyValidation.IsStringValide(candidate.type, user_type.typeMin, user_type.typeMax)
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

        static public bool IsUSerTypeExist(user_type candidate, List<user_type> types)
        {
            List<user_type> existingOne = types.Where(o => o.type == candidate.type).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }
    }
}
