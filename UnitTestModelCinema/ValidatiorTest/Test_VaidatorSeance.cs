using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelCinema.Models;
using ModelCinema.Models.DataManager;
using ModelCinema.Models.ModelValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestModelCinema
{
    [TestClass]
    public class Test_VaidatorSeance
    {
        private cinema_dbEntities _context;

        [TestInitialize]
        public void Initialize()
        {
            _context = MockDB.cinema_DbEntities();
        }

        [TestMethod]
        public void ConflictingSeance_seanceStartToEarly()
        {
            //Arrange
            ManagerSeance manager = new ManagerSeance(_context);
            seance s1 = new seance() { id = 999, salle_id = 1, titre_seance = "conflicting seance", date_debut = new DateTime(2021, 1, 1, 11, 0, 0), date_fin = new DateTime(2021, 1, 1, 12, 0, 0) };
            DateTime dateToLoad = new DateTime(2021, 1, 1);

            //Act
            var testResult1 = ValidatorSeance.IsSeanceConflict(s1, manager.GetAllSeanceFromSalle(s1.salle_id, dateToLoad));

            //Assert
            Assert.IsTrue(testResult1, "a seance starting before an other ended was accepted");
        }

        [TestMethod]
        public void ConflictingSeance_seanceEndToLate()
        {
            //Arrange
            ManagerSeance manager = new ManagerSeance(_context);
            seance s2 = new seance() { id = 999, salle_id = 1, titre_seance = "conflicting seance", date_debut = new DateTime(2021, 1, 1, 9, 0, 0), date_fin = new DateTime(2021, 1, 1, 11, 0, 0) };
            DateTime dateToLoad = new DateTime(2021, 1, 1);

            //Act
            var testResult2 = ValidatorSeance.IsSeanceConflict(s2, manager.GetAllSeanceFromSalle(s2.salle_id, dateToLoad));

            //Assert
            Assert.IsTrue(testResult2, "a seance endind after an other started was accepted");
        }

        [TestMethod]
        public void ConflictingSeance_seanceSameTime()
        {
            //Arrange
            ManagerSeance manager = new ManagerSeance(_context);
            seance s3 = new seance() { id = 999, salle_id = 1, titre_seance = "conflicting seance", date_debut = new DateTime(2021, 1, 1, 10, 0, 0), date_fin = new DateTime(2021, 1, 1, 12, 0, 0) };
            DateTime dateToLoad = new DateTime(2021, 1, 1);

            //Act
            var testResult3 = ValidatorSeance.IsSeanceConflict(s3, manager.GetAllSeanceFromSalle(s3.salle_id, dateToLoad));

            //Assert
            Assert.IsTrue(testResult3, "a seance with the same start time was accepted ");
        }

        [TestMethod]
        public void NonConflictingSeance()
        {
            //Arrange
            ManagerSeance manager = new ManagerSeance(_context);
            seance s = new seance() { id = 999, salle_id = 1, titre_seance = "non conflicting seance", date_debut = new DateTime(2021, 1, 1, 8, 0, 0), date_fin = new DateTime(2021, 1, 1, 10, 0, 0) };
            DateTime dateToLoad = new DateTime(2021, 1, 1);

            //Act
            var testResult3 = ValidatorSeance.IsSeanceConflict(s, manager.GetAllSeanceFromSalle(s.salle_id, dateToLoad));

            //Assert
            Assert.IsFalse(testResult3, "a seance with the same start time was accepted ");
        }
        
    }
}
