using Effort;
using Effort.DataLoaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelCinema.ModelExeption;
using ModelCinema.Models;
using ModelCinema.Models.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestModelCinema
{
    [TestClass]
    public class Test_ManagerSeance
    {
        private cinema_dbEntities _context;

        [TestInitialize]
        public void Initialize()
        {
            _context = MockDB.cinema_DbEntities();
        }


        //[TestMethod]
        //public void PutMultiSeanceIsGood()
        //{
        //    //Arrange
        //    var managerSeance = new ManagerSeance(_context);
        //    var newSeance = managerSeance.GetSeance(1);
        //    int count = managerSeance.GetAllSeanceFromSalle(newSeance.salle_id, newSeance.date_debut).Count;
        //    string recurrance = "Daily";
        //    List<seance> seances = managerSeance.GetAllSeanceFromSalle(newSeance.salle_id, newSeance.date_debut);
        //    List<seance> seances2 = managerSeance.GetAllSeanceFromSalle(newSeance.salle_id, newSeance.date_debut);

        //    //Act
        //    try
        //    {
        //        managerSeance.RecurranceSeances(newSeance.id, recurrance, 4);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.Fail($"unexpected error of type {e.GetType()} occure with a message : {e.Message}");
        //    }
        //    //Assert
        //  seances2 = managerSeance.GetAllSeanceFromSalle(newSeance.salle_id, newSeance.date_debut);
        //    Assert.IsTrue(count + 4 == managerSeance.GetAllSeanceFromSalle(newSeance.salle_id, newSeance.date_debut).Count);
        //}
    }

}
