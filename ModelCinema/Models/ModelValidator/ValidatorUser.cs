using ModelCinema.Models.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    static public class ValidatorUser
    {
        static public bool IsValide(user user)
        {
            try
            {
                if (
                    PropretyValidation.IsStringValide(user.login, user.loginMin, user.loginMax) &&
                    PropretyValidation.IsStringValide(user.password, user.passwordMin, user.passwordMax) &&
                    PropretyValidation.IsStringValide(user.name, user.nameMin, user.nameMax) 
                    )
                {
                    //TO-DO
                    //vérifier si le name ne contient pas de charactere non valide
                    //TO-DO
                    //vérifier si password contient les charactere nécéssaire
                    return true;
                } else
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
        static public bool IsUserExist(user candidate)
        {
            ManagerUser manager = new ManagerUser();

            List<user> existingOne = manager.GetAllUser().Where(o => o.login == candidate.login).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }
    }
}
