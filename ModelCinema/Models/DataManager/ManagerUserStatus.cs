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
    public class ManagerUserStatus
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        public List<user_status> GetAllUserStatus()
        {
            return db.user_status.ToList();
        }

        public user_status GetUserStatus(int? id)
        {
            return db.user_status.Find(id);
        }
    }
}