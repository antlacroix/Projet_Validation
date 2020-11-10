using ModelCinema.ModelExeption;
using ModelCinema.Models.ModelValidator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
            try
            {
                return db.contact_info.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public contact_info GetContact(int? id)
        {
            try
            {
                return db.contact_info.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PostContact(contact_info contact_info)
        {
            try
            {
                if (ValidatorContact.IsValide(contact_info))
                {
                    db.contact_info.Add(contact_info);
                    db.SaveChanges();
                    return true;
                }
                else
                    throw new InvalidItemException("contact");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PutContact(contact_info contact_info)
        {
            try
            {
                if (ValidatorContact.IsContactExist(contact_info, GetAllContact()) && ValidatorContact.IsValide(contact_info))
                {
                    db.Entry(contact_info).State = EntityState.Modified;
                    db.Set<contact_info>().AddOrUpdate(contact_info);
                    db.SaveChanges();
                    return true;
                }
                else if (!ValidatorContact.IsContactExist(contact_info, GetAllContact()))
                    throw new ItemNotExistException("contact");
                else
                    throw new InvalidItemException("contact");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteContact(int id)
        {
            try
            {
                if (db.contact_info.Find(id) != null)
                {
                    contact_info contact_info = db.contact_info.Find(id);
                    db.contact_info.Remove(contact_info);
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
