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
            return db.participants.ToList();
        }

        public participant GetParticipant(int? id)
        {
            return db.participants.Find(id);
        }

        public bool PostParticipant(participant participant)
        {
            if (ValidatorParticipant.IsValide(participant) && !ValidatorParticipant.IsParticipantExist(participant))
            {
                try
                {
                    db.participants.Add(participant);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if(ValidatorParticipant.IsParticipantExist(participant))
                throw new ExistingItemException("participant");
            else
                throw new InvalidItemException("participant");
        }

        public bool PutParticipant(participant participant)
        {
            if (ValidatorParticipant.IsParticipantExist(participant) && ValidatorParticipant.IsValide(participant))
            {
                try
                {
                    db.Entry(participant).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (!ValidatorParticipant.IsParticipantExist(participant))
                throw new ItemNotExistException("participant");
            else
                throw new InvalidItemException("participant");
        }

        public bool DeleteParticipant(int id)
        {
            if (db.participants.Find(id) != null)
            {
                try
                {
                    participant participant  = db.participants.Find(id);
                    db.participants.Remove(participant);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
