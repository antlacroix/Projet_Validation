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
            return db.users.ToList();
        }

        public user GetUser(int? id)
        {
            return db.users.Find(id);
        }

        public bool PostUser(user user)
        {
            if (ValidatorUser.IsValide(user) && !ValidatorUser.IsUserExist(user))
            {
                try
                {
                    db.users.Add(user);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if(ValidatorUser.IsUserExist(user))
                throw new ExistingItemException("user");
            else
                throw new InvalidItemException("user");
        }

        public bool PutUser(user user)
        {
            if (db.users.Find(user.id) != null && ValidatorUser.IsValide(user))
            {
                try
                {
                    db.Entry(user).State = EntityState.Modified;
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

        public bool DeleteUser(int id)
        {
            if (db.users.Find(id) != null)
            {
                try
                {
                    user user = db.users.Find(id);
                    db.users.Remove(user);
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
