using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelCinema.Models.ModelValidator;
using ModelCinema.ModelExeption;

namespace ModelCinema.Models.DataManager
{
    public class ManagerUserType
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        public List<user_type> GetAllUserType()
        {
            return db.user_type.ToList();
        }

        public user_type GetUserType(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return db.user_type.Find(id);
        }

        public bool PostUserType(user_type type)
        {
            if (type.type.Length > 0 && type.type.Length < 11)
            {
                try
                {
                    db.user_type.Add(type);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (ValidatorUserType.IsUSerTypeExist(type))
                throw new ExistingItemException("user_type");
            else
                throw new InvalidItemException("user_type");
        }

        public bool PutUserType(user_type user_type)
        {
            if (ValidatorUserType.IsUSerTypeExist(user_type))
            {
                try
                {
                    db.Entry(user_type).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (!ValidatorUserType.IsUSerTypeExist(user_type))
                throw new ItemNotExistException("user_type");
            else
                throw new InvalidItemException("user_type");
        }

        public bool DeleteUserType(int id)
        {
            if (db.user_type.Find(id) != null)
            {
                try
                {
                    user_type type = db.user_type.Find(id);
                    db.user_type.Remove(type);
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
