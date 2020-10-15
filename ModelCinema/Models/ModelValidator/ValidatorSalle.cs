using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    static public class ValidatorSalle
    {
        static public bool IsValide(salle salle)
        {
            try
            {
                if (
                    IsSallePlaceValide(salle.nbr_place) &&
                    //IsSalleNumeroExist(salle.numero_salle) &&
                    IsSalleNumeroValide(salle.numero_salle) &&
                    IsSalleCommentaire(salle.commentaire)
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

        static public bool IsSallePlaceValide(int nbr_place)
        {
            if (nbr_place > 0)
                return true;
            else
                return false;
        }

        //TO-DO
        //vérifier si numero de salle existe avec DataManager
        //IsSalleNumeroExist(int no_salle){}

        static public bool IsSalleNumeroValide(int no_salle)
        {
            if (no_salle > 0)
                return true;
            else
                return false;
        }

        static public bool IsSalleCommentaire(string commentaire)
        {
            if (commentaire.Length > 0 && commentaire.Length < 250)
                return true;
            else
                return false;
        }
    }
}
