using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelCinema.Models.ModelValidator;
using ModelCinema.Models;
using ModelCinema.Models.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelCinema.ModelExeption;

namespace UnitTestModelCinema.ValidatiorTest
{
    [TestClass]
    public class Test_SalleValidator
    {
        private cinema_dbEntities _context;

        [TestInitialize]
        public void Initialize()
        {
            _context = MockDB.cinema_DbEntities();
         
        }

        [TestMethod]
        public void IsSalleContainSeance_WithNullParam()
        {
            //Arrange
            ManagerSalle manager = new ManagerSalle(_context);
            salle nullSalle = null;
            //Act
            try
            {
                var testResult = ValidatorSalle.IsSalleContainSeance(nullSalle);
            //Assert
                Assert.Fail("A exception should have been throw");
            }
            catch (NullIdExecption NIE)
            {
                Assert.AreEqual("aucune Salle avec cette ID existe", NIE.Message);
            }
            catch (Exception e)
            {
                Assert.Fail($"unexpected error of type {e.GetType()} occure with a message : {e.Message}");
            }
        }

        [TestMethod]
        public void IsSalleContainSeance_TrueParam()
        {
            //Arrange
            ManagerSalle manager = new ManagerSalle(_context);
            salle ValidSalle = manager.GetSalle(1);
            //Act
            try
            {
                var testResult = ValidatorSalle.IsSalleContainSeance(ValidSalle);
                //Assert
                Assert.IsTrue(testResult, "La Salle Contien des Seance mais la fonction dit que non");
            }
            catch (Exception e)
            {
                Assert.Fail($"unexpected error of type {e.GetType()} occure with a message : {e.Message}");
            }
        }

        [TestMethod]
        public void IsSalleContainSeance_FalsParam()
        {
            //Arrange
            ManagerSalle manager = new ManagerSalle(_context);
            salle ValidSalle = manager.GetSalle(6);
            //Act
            try
            {
                var testResult = ValidatorSalle.IsSalleContainSeance(ValidSalle);
                //Assert
                Assert.IsFalse(testResult, "La Salle ne Contien pas de Seance mais la fonction dit que oui");
            }
            catch (Exception e)
            {
                Assert.Fail($"unexpected error of type {e.GetType()} occure with a message : {e.Message}");
            }
        }

        [TestMethod]
        public void IsSalleActive_WithNullParam()
        {
            //Arrange
            ManagerSalle manager = new ManagerSalle(_context);
            salle NullSalle = null;
            //Act
            try
            {
                var testResult = ValidatorSalle.IsSalleActive(NullSalle);
                //Assert
                Assert.Fail("A exception should have been throw");
            }
            catch (NullIdExecption NIE)
            {
                Assert.AreEqual("aucune Salle avec cette ID existe", NIE.Message);
            }
            catch (Exception e)
            {
                Assert.Fail($"unexpected error of type {e.GetType()} occure with a message : {e.Message}");
            }
        }

        [TestMethod]
        public void IsSalleActive_TrueParam()
        {
            //Arrange
            ManagerSalle manager = new ManagerSalle(_context);
            salle ActiveSalle = manager.GetSalle(1);
            //Act
            try
            {
                var testResult = ValidatorSalle.IsSalleActive(ActiveSalle);
                //Assert
                Assert.IsTrue(testResult, "La Salle est Active mais la fonction dit que NON");
            }
            catch (Exception e)
            {
                Assert.Fail($"unexpected error of type {e.GetType()} occure with a message : {e.Message}");
            }
        }

        [TestMethod]
        public void IsSalleActive_FalsParam()
        {
            //Arrange
            ManagerSalle manager = new ManagerSalle(_context);
            salle InactiveSalle = manager.GetSalle(6);
            //Act
            try
            {
                var testResult = ValidatorSalle.IsSalleActive(InactiveSalle);
                //Assert
                Assert.IsFalse(testResult, "La Salle n'est pas Active mais la fonction dit que OUI");
            }
            catch (Exception e)
            {
                Assert.Fail($"unexpected error of type {e.GetType()} occure with a message : {e.Message}");
            }
        }


    }
}
