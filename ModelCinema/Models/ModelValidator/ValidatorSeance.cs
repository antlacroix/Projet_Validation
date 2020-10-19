﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    static public class ValidatorSeance
    {
        //min Length/Value for seance's proprety
        static private int
            titreMin = 1;
        static private DateTime
            dateDebutMin = DateTime.Now,
            dateFinMin = dateDebutMin.AddMinutes(15);
        //max Length/Value for seance's proprety
        static private int
            titreMax = 100;
        static private DateTime
            dateDebutMax = DateTime.Now.AddYears(50),
            dateFinMax = DateTime.Now.AddYears(50);

        static public bool IsValide(seance seance)
        {
            try
            {
                if (
                    PropretyValidation.IsDateValide(seance.date_debut, dateDebutMin, dateDebutMax) &&
                    PropretyValidation.IsDateValide(seance.date_debut, dateFinMin, dateFinMax) &&
                    PropretyValidation.IsStringValide(seance.titre_seance, titreMin, titreMax)
                    )
                {
                    //TO-DO
                    //vérifier si la sceance est en conflit avec une autre
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
