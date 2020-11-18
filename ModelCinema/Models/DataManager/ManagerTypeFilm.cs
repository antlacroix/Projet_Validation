using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelCinema.ModelExeption;
using ModelCinema.Models.ModelValidator;
using Xceed.Wpf.Toolkit;

namespace ModelCinema.Models.DataManager
{
    public class ManagerTypeFilm
    {
        private cinema_dbEntities db;

        public ManagerTypeFilm()
        {
            db = new cinema_dbEntities();
        }

        public ManagerTypeFilm(cinema_dbEntities dbEntities)
        {
            db = dbEntities;
        }

        public List<type_film> GetAllType_film()
        {
            try
            {
                return db.type_film.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<type_film> GetType_film()
        {
            try
            {
                return db.type_film.Where(f => f.typage.ToUpper() != "PROMOTIONNEL").ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
