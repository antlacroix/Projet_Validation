using ModelCinema.Models.DataManager;
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
                    PropretyValidation.IsDateValide(seance.date_debut, seance.dateDebutMin, seance.dateDebutMax) &&
                    PropretyValidation.IsDateValide(seance.date_debut, seance.dateFinMin, seance.dateFinMax) &&
                    PropretyValidation.IsStringValide(seance.titre_seance, seance.titreMin, seance.titreMax)
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
        static public bool IsSeanceExiste(seance candidate)
        {
            ManagerSeance manager = new ManagerSeance();
            List<seance> existingOne = manager.GetAllSeance().Where(o => o.id == candidate.id).ToList();
            if (existingOne.Count != 0)
            {
                return true;
            }
            else 
                return false;
        }

        static public bool IsSeanceConflict(seance candidate)
        {
            ManagerSeance manager = new ManagerSeance();

            List<seance> conflitingOne = manager.GetAllSeance().Where
                (seance =>
                    seance.salle_id == candidate.salle_id &&
                    (
                        (
                            candidate.date_debut < seance.date_debut &&
                            candidate.date_fin > seance.date_debut
                        ) || 
                        (
                            candidate.date_debut < seance.date_fin &&
                            candidate.date_fin > seance.date_fin 
                        ) ||
                        (
                            candidate.date_debut > seance.date_debut &&
                            candidate.date_fin < seance.date_fin
                        ) 
                    )
                ).ToList();

            if (conflitingOne.Count != 0)
                return true;
            else
                return false;
        }
    }
}
