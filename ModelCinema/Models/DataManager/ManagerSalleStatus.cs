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
    public class ManagerSalleStatus
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        public List<salle_status> GetAllSalleStatus()
        {
            try
            {
                return db.salle_status.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public salle_status GetSalleStatus(int? id)
        {
            try
            {
                return db.salle_status.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

