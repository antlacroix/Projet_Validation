using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    static public class ValidatorSeance
    {
        static public bool IsValide(seance seance)
        {
            try
            {
                if (
                    //IsSeanceConflict(seance.date_debut, seance.date_fin) &&
                    IsSeanceDateDebutValide(seance.date_debut) &&
                    IsSeanceDateFinValide(seance.date_debut, seance.date_fin) &&
                    IsSeanceTitreValide(seance.titre_seance)
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

        //TO-DO
        //vérifier si la sceance est en conflit avec une autre
        //static public bool IsSeanceConflict(DateTime date_debut, DateTime date_fin){}

        static public bool IsSeanceDateDebutValide(DateTime date_debut)
        {
            if (date_debut.CompareTo(DateTime.Now) >= 0)
                return true;
            else
                return false;
        }

        static public bool IsSeanceDateFinValide(DateTime date_debut, DateTime date_fin)
        {
            if (date_fin.AddMinutes(30).CompareTo(date_debut) >= 0)
                return true;
            else
                return false;
        }

        static public bool IsSeanceTitreValide(string titre)
        {
            if (titre.Length > 0 && titre.Length < 50)
                return true;
            else
                return false;
        }

    }

}
