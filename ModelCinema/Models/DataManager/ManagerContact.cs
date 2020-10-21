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

        public List<contact_info> GetAllContact ()
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
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool PutContact(contact_info contact_info)
        {
            if (db.contact_info.Find(contact_info.id) != null && ValidatorContact.IsValide(contact_info))
            {
                try
                {
                    db.Entry(contact_info).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
            else
            {
                return false;
            }
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
