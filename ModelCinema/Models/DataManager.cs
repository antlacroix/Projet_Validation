using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models
{
    public class DataManager
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        private List<film> films;

        public DataManager()
        {
            films = db.films.ToList();
        }
    }
}
