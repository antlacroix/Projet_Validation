using ModelCinema.ModelExeption;
using ModelCinema.Models.ModelValidator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModelCinema.Models.DataManager
{
    public class ManagerParticipant
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        public List<participant> GetAllParticipant()
        {
            try
            {
                return db.participants.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public participant GetParticipant(int? id)
        {
            try
            {
                return db.participants.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PostParticipant(participant participant)
        {
            try
            {
                if (ValidatorParticipant.IsValide(participant) && !ValidatorParticipant.IsParticipantExist(participant, GetAllParticipant()))
                {
                    db.participants.Add(participant);
                    db.SaveChanges();
                    return true;
                }
                else if (ValidatorParticipant.IsParticipantExist(participant, GetAllParticipant()))
                    throw new ExistingItemException("participant");
                else
                    throw new InvalidItemException("participant");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PutParticipant(participant participant)
        {
            try
            {
                if (ValidatorParticipant.IsParticipantExist(participant, GetAllParticipant()) && ValidatorParticipant.IsValide(participant))
                {
                    db.Entry(participant).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else if (!ValidatorParticipant.IsParticipantExist(participant, GetAllParticipant()))
                    throw new ItemNotExistException("participant");
                else
                    throw new InvalidItemException("participant");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteParticipant(int id)
        {
            try
            {
                if (db.participants.Find(id) != null)
                {
                    participant participant = db.participants.Find(id);
                    db.participants.Remove(participant);
                    db.SaveChanges();
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
    }
}
