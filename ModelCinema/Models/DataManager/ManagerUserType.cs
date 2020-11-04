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
            try
            {
                return db.user_type.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public user_type GetUserType(int? id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }
                return db.user_type.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PostUserType(user_type type)
        {
            try
            {
                if (type.type.Length > 0 && type.type.Length < 11)
                {
                    db.user_type.Add(type);
                    db.SaveChanges();
                    return true;
                }
                else if (ValidatorUserType.IsUSerTypeExist(type, GetAllUserType()))
                    throw new ExistingItemException("user_type");
                else
                    throw new InvalidItemException("user_type");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PutUserType(user_type user_type)
        {
            try
            {
                if (ValidatorUserType.IsUSerTypeExist(user_type, GetAllUserType()))
                {
                    db.Entry(user_type).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else if (!ValidatorUserType.IsUSerTypeExist(user_type, GetAllUserType()))
                    throw new ItemNotExistException("user_type");
                else
                    throw new InvalidItemException("user_type");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteUserType(int id)
        {
            try
            {
                if (db.user_type.Find(id) != null)
                {
                    user_type type = db.user_type.Find(id);
                    db.user_type.Remove(type);
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
