using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    class ValidatorUser : IValidator
    {
        static public bool IsValide(user user)
        {
            try
            {
                if (
                    //IsUserLoginExist(user.login) &&
                    IsUserLoginValide(user.login) &&
                    IsUserPasswordValide(user.password) &&
                    IsUserNameValide(user.name)
                    )
                {
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

        //TO-DO
        //vérifier si le login exist déjà via DataManager
        //static private bool IsUserLoginExist(string login){}

        static private bool IsUserLoginValide(string login)
        {

            if (login.Length > 0 && login.Length < 15)
                return true;
            else
                return false;
        }

        static private bool IsUserPasswordValide(string password)
        {
            //TO-DO
            //vérifier si password contient les charactere nécéssaire
            if (password.Length > 0 && password.Length < 25)
                return true;
            else
                return false;
        }

        static private bool IsUserNameValide(string name)
        {
            //TO-DO
            //vérifier si le name ne contient pas de charactere non valide
            if (name.Length > 0 && name.Length < 50)
                return true;
            else
                return false;
        }

    }
}
