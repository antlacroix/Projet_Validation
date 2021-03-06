﻿using ModelCinema.Models.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    static public class ValidatorParticipant
    {
        static public bool IsValide(participant participant)
        {
            try
            {
                if (PropretyValidation.IsStringValide(participant.name, participant.nameMin, participant.nameMax))
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

        static public bool IsParticipantExist(participant candidate, List<participant> participants)
        {
            List<participant> existingOne = participants.Where(o => o.name == candidate.name).ToList();

            if (existingOne.Count != 0)
                return true;
            else
                return false;
        }
    }
}
