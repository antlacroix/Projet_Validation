﻿using ModelCinema.Models.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    static public class ValidatorUser
    {
        //min Length/Value for user's proprety
        static private int
            loginMin = 5,
            passwordMin = 6,
            nameMin = 3;
        //max Length/Value for user's proprety
        static private int
            loginMax = 15,
            passwordMax = 25,
            nameMax = 50;

        static public bool IsValide(user user)
        {
            try
            {
                if (
                    PropretyValidation.IsStringValide(user.login, loginMin, loginMax) &&
                    PropretyValidation.IsStringValide(user.password, passwordMin, passwordMax) &&
                    PropretyValidation.IsStringValide(user.name, nameMin, nameMax) &&
                    !IsUserExist(user)
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
        static private bool IsUserExist(user candidate)
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
