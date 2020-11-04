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
    public class ManagerUser
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        public List<user> GetAllUser()
        {
            try
            {
                return db.users.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public user GetUser(int? id)
        {
            try
            {
                return db.users.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PostUser(user user)
        {
            try
            {
                if (ValidatorUser.IsValide(user) && !ValidatorUser.IsUserExist(user, GetAllUser()))
                {
                    db.users.Add(user);
                    db.SaveChanges();
                    return true;
                }
                else if (ValidatorUser.IsUserExist(user, GetAllUser()))
                    throw new ExistingItemException("user");
                else
                    throw new InvalidItemException("user");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PutUser(user user)
        {
            try
            {
                if (ValidatorUser.IsUserExist(user, GetAllUser()) && ValidatorUser.IsValide(user))
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else if (!ValidatorUser.IsUserExist(user, GetAllUser()))
                    throw new ItemNotExistException("user");
                else
                    throw new InvalidItemException("user");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                if (db.users.Find(id) != null)
                {
                    user user = db.users.Find(id);
                    db.users.Remove(user);
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
