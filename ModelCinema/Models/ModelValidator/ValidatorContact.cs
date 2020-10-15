using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    class ValidatorContact : IValidator
    {
        static public bool IsValide(contact_info contact_info)
        {
            try
            {
                if (
                    IsContactTelephoneValide(contact_info.tel_number) &&
                    IsContactCodePostalValide(contact_info.code_postal) &&
                    IsContactAdressValide(contact_info.adresse) &&
                    IsContactVilleValide(contact_info.ville) &&
                    IsContactProvinceValide(contact_info.province) &&
                    IsContactPaysValide(contact_info.pays)
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

        static private bool IsContactTelephoneValide(string telephone)
        {
            if (telephone.Length == 9)
                return true;
            else
                return false;
        }
        
        static private bool IsContactCodePostalValide(string code_postal)
        {
            //TO-DO
            //Vérifier si le code postal respecte une RegEx 
            if (code_postal.Length == 6)
                return true;
            else
                return false;
        }

        static private bool IsContactAdressValide(string adresse)
        {
            if (adresse.Length > 0 && adresse.Length < 50)
                return true;
            else
                return false;
        }

        static private bool IsContactVilleValide(string ville)
        {
            if (ville.Length > 0 && ville.Length < 50)
                return true;
            else
                return false;
        }
        
        static private bool IsContactProvinceValide(string province)
        {
            if (province.Length > 0 && province.Length < 20)
                return true;
            else
                return false;
        }
        
        static private bool IsContactPaysValide(string pays)
        {
            if (pays.Length > 0 && pays.Length < 15)
                return true;
            else
                return false;
        }
    }
}
