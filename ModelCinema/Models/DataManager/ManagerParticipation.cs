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
    public class ManagerParticipation
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        public List<participation> GetAllParticipation()
        {
            try
            {
                return db.participations.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public participation GetParticipation(int? id)
        {
            try
            {
                return db.participations.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}