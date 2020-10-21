using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    public class ValidatorContact
    {
        static public bool IsValide(contact_info contact_info)
        {
            try
            {
                if (
                    //TO-DO
                    //Vérifier si le telephone ne contient que des chiffres 
                    PropretyValidation.IsStringValide(contact_info.tel_number, contact_info.telephoneMin, contact_info.telephoneMax) &&
                    //TO-DO
                    //Vérifier si le code postal respecte une RegEx 
                    PropretyValidation.IsStringValide(contact_info.code_postal, contact_info.codePostalMin, contact_info.codePostalMax) &&
                    PropretyValidation.IsStringValide(contact_info.adresse, contact_info.AdressMin, contact_info.AdressMax) &&
                    PropretyValidation.IsStringValide(contact_info.ville, contact_info.villeMin, contact_info.villeMax) &&
                    PropretyValidation.IsStringValide(contact_info.province, contact_info.provinceMin, contact_info.provinceMax) &&
                    PropretyValidation.IsStringValide(contact_info.pays, contact_info.paysMin, contact_info.paysMax)
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
