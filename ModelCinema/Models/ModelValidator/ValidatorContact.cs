using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    public class ValidatorContact
    {
        //min Length/Value for contact's proprety
        static private int
            telephoneMin = 10,
            codePostalMin = 6,
            AdressMin = 5,
            villeMin = 2,
            provinceMin = 2,
            paysMin = 2;
        //max Length/Value for contact's proprety
        static private int
            telephoneMax = 10,
            codePostalMax = 6,
            AdressMax = 50,
            villeMax = 50,
            provinceMax = 20,
            paysMax = 15;
        //regEx string for conctat's proprty
        static private string
            telephoneRegEx = "",
            codePostalRegEx = "";


        static public bool IsValide(contact_info contact_info)
        {
            try
            {
                if (
                    //TO-DO
                    //Vérifier si le telephone ne contient que des chiffres 
                    PropretyValidation.IsStringValide(contact_info.tel_number, telephoneMin, telephoneMax) &&
                    //TO-DO
                    //Vérifier si le code postal respecte une RegEx 
                    PropretyValidation.IsStringValide(contact_info.code_postal, codePostalMin, codePostalMax) &&
                    PropretyValidation.IsStringValide(contact_info.adresse, AdressMin, AdressMax) &&
                    PropretyValidation.IsStringValide(contact_info.ville, villeMin, villeMax) &&
                    PropretyValidation.IsStringValide(contact_info.province, provinceMin, provinceMax) &&
                    PropretyValidation.IsStringValide(contact_info.pays, paysMin, paysMax)
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
