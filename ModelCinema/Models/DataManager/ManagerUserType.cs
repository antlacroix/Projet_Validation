using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(id == null)
            {
                return null;
            }
            return db.user_type.Find(id);
        }

        public bool PostUserType(user_type type)
        {
            if(type.type.Length > 0 && type.type.Length < 11)
            {
                try
                {
                    db.user_type.Add(type);
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

        public bool PutUserType(user_type user_type)
        {
            if (db.user_type.Find(user_type.id) != null)
            {
                try
                {
                    db.Entry(user_type).State = EntityState.Modified;
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
