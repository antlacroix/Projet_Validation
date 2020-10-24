using ModelCinema.ModelExeption;
using ModelCinema.Models.ModelValidator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.DataManager
{
    public class ManagerContact
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        public List<contact_info> GetAllContact()
        {
            return db.contact_info.ToList();
        }

        public contact_info GetContact(int? id)
        {
            return db.contact_info.Find(id);
        }

        public bool PostContact(contact_info contact_info)
        {
            if (ValidatorContact.IsValide(contact_info))
            {
                try
                {
                    db.contact_info.Add(contact_info);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                throw new InvalidItemException("contact");
            }
        }

        public bool PutContact(contact_info contact_info)
        {
            if (ValidatorContact.IsContactExist(contact_info) && ValidatorContact.IsValide(contact_info))
            {
                try
                {
                    db.Entry(contact_info).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (!ValidatorContact.IsContactExist(contact_info))
                throw new ItemNotExistException("contact");
            else
                throw new InvalidItemException("contact");
        }

        public bool DeleteContact(int id)
        {
            if (db.contact_info.Find(id) != null)
            {
                try
                {
                    contact_info contact_info = db.contact_info.Find(id);
                    db.contact_info.Remove(contact_info);
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
