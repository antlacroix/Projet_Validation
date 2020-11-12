//using Autofac.Extras.Moq;
using Effort;
using Effort.DataLoaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelCinema.ModelExeption;
using ModelCinema.Models;
using ModelCinema.Models.DataManager;
using System;
using System.Collections.Generic;
using UnitTestModelCinema;

namespace UnitTestModelCinema
{
    [TestClass]
    public class Test_ManagerFilm
    {
        private cinema_dbEntities _context;

        [TestInitialize]
        public void Initialize()
        {
            _context = MockDB.cinema_DbEntities();
        }

        [TestMethod]
        public void GetFilmsFrom_Test()
        {
            //Arrange
            var managerFilm = new ManagerFilm(_context);
            int year = 2005;

            //Act
            var listeTest = managerFilm.GetAllFilmsFrom(year);

            //Assert
            Assert.IsTrue(listeTest.Count == 2);
        }

        [TestMethod]
        public void GetFilmsFromTo_Test()
        {
            //Arrage
            var managerFilm = new ManagerFilm(_context);
            int
                yearFrom = 2003,
                yearTo = 2007;

            //Act
            var listTest = managerFilm.GetAllFilmsFromTo(yearFrom, yearTo);

            //Assert
            Assert.IsTrue(listTest.Count == 1);
        }

        [TestMethod]
        public void PostConflictingTitre()
        {
            //Arrange
            var managerFilm = new ManagerFilm(_context);
            var conflictingFilm = new film() { id = 10, titre = "film test 1", description = "", annee_parution = 2000, duree = 15, id_type = 2 };

            //Act
            try
            {
                managerFilm.PostFilm(conflictingFilm);
                Assert.Fail("an exception should have been thrown");
            }
            //Assert
            catch (ExistingItemException eie)
            {
                Assert.AreEqual("cet 'film' existe deja", eie.Message);
            }
            catch (Exception e)
            {
                Assert.Fail($"unexpected error of type {e.GetType()} occure with a message : {e.Message}");
            }
        }


    }
}
