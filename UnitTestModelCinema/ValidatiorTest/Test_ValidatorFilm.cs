using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelCinema.ModelExeption;
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
    class Test_ValidatorFilm
    {
        private cinema_dbEntities _context;

        [TestInitialize]
        public void Initialize()
        {
            _context = MockDB.cinema_DbEntities();
        }

        [TestMethod]
        public void IsTitleExist_conflictingTitle()
        {
            //Arrange
            ManagerFilm manager = new ManagerFilm(_context);
            film conflitingTitlefilm = new film() { id = 999, titre = "film test 1", description = "test", duree = 15, annee_parution = 2020 };
            bool testResult = false;

            //Act
            try
            {
                testResult = ValidatorFilm.IsTitleExist(conflitingTitlefilm, manager.GetAllFilmsFromTo(conflitingTitlefilm.annee_parution - 20, conflitingTitlefilm.annee_parution + 20));
            }
            catch (Exception e)
            {
                Assert.Fail($"unexpected error of type: {e.GetType()}, with message: {e.Message}");
            }

            //Assert
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void IsTitleExist_correctTitle()
        {
            //Arrange
            ManagerFilm manager = new ManagerFilm(_context);
            film nonConflitingTitlefilm = new film() { id = 999, titre = "non conflicting title", description = "test", duree = 15, annee_parution = 2020 };
            bool testResult = false;

            //Act
            try
            {
                testResult = ValidatorFilm.IsTitleExist(nonConflitingTitlefilm, manager.GetAllFilmsFromTo(nonConflitingTitlefilm.annee_parution - 20, nonConflitingTitlefilm.annee_parution + 20));
            }
            catch (Exception e)
            {
                Assert.Fail($"unexpected error of type: {e.GetType()}, with message: {e.Message}");
            }

            //Assert
            Assert.IsFalse(testResult);
        }

        [TestMethod]
        public void IsTitleExist_withNullCandidate()
        {
            ManagerFilm manager = new ManagerFilm(_context);
            film nullFIlm = null;

            try
            {
                ValidatorFilm.IsTitleExist(nullFIlm, manager.GetAllFilmsFrom(2010));
                Assert.Fail("an exception should have been thown");
            }
            catch(NullParametreException npe)
            {
                Assert.AreEqual(npe.Message, $"this exception was raised because candidate in IsFilmExist was null");
            }
            catch(Exception e)
            {
                Assert.Fail($"unexpected error of type: {e.GetType()}, with message: {e.Message}");
            }
        }

        [TestMethod]
        public void IsTitleExist_withNullFilms()
        {
            ManagerFilm manager = new ManagerFilm(_context);
            film testFilm = new film() { id = 999, titre = "non conflicting title", description = "test", duree = 15, annee_parution = 2020 };
            List<film> nullFilms = null;

            try
            {
                ValidatorFilm.IsTitleExist(testFilm, nullFilms);
                Assert.Fail("an exception should have been thown");
            }
            catch (NullParametreException npe)
            {
                Assert.AreEqual(npe.Message, $"this exception was raised because films in IsFilmExist was null");
            }
            catch (Exception e)
            {
                Assert.Fail($"unexpected error of type: {e.GetType()}, with message: {e.Message}");
            }
        }
    }
}
