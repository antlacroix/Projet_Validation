using ModelCinema.Models.DataManager;
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
                    PropretyValidation.IsStringValide(contact_info.tel_number, contact_info.telephoneMin, contact_info.telephoneMax, contact_info.telephoneRegEx) &&
                    PropretyValidation.IsStringValide(contact_info.code_postal, contact_info.codePostalMin, contact_info.codePostalMax, contact_info.codePostalRegEx) &&
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
            catch (Exception e)
            {
                throw e;
            }
        }

        static public bool IsContactExist(contact_info candidate, List<contact_info> contacts)
        {
            List<contact_info> existingOne = contacts.Where(o => o.id == candidate.id).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }

    }
}
