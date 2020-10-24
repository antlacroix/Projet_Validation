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
            return db.participations.ToList();
        }

        public participation GetParticipation(int? id)
        {
            return db.participations.Find(id);
        }
    }
}