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
    public class ManagerParticipationRole
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        public List<role_participant> GetAllParticipationRole()
        {
            return db.role_participant.ToList();
        }

        public role_participant GetParticipationRole(int? id)
        {
            return db.role_participant.Find(id);
        }
    }
}