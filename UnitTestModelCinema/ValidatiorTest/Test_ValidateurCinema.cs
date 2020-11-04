using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelCinema.Models;
using ModelCinema.Models.DataManager;
using ModelCinema.Models.ModelValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestModelCinema.ValidatiorTest
{
    [TestClass]
    public class Test_ValidateurCinema
    {
        private cinema_dbEntities _context;

        [TestInitialize]
        public void Initialize()
        {
            _context = MockDB.cinema_DbEntities();
        }

        [TestMethod]
        public void CinemaContainSalle_emptyCinema()
        {
            //Arrange
            ManagerCinema manager = new ManagerCinema(_context);
           
            //Act
            var testResult1 = ValidatorCinema.IsCinemaContainSalle(manager.GetCinema(3));

            //Assert
            Assert.IsFalse(testResult1, "un cinema vide n'as pas renvoyer false");
        }

        [TestMethod]
        public void CinemaContainSalle_CinemaWithSalle()
        {
            //Arrange
            ManagerCinema manager = new ManagerCinema(_context);

            //Act
            var testResult1 = ValidatorCinema.IsCinemaContainSalle(manager.GetCinema(2));

            //Assert
            Assert.IsTrue(testResult1, "un cinema contient des salle n'as pas renvoyer true");
        }
    }
}
