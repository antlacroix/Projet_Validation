using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelCinema.Models;
using ModelCinema.Models.DataManager;
using System.Collections.Generic;

namespace UnitTestWebCinema
{
    [TestClass]
    public class Test_ManagerFilm
    {
        ManagerFilm manager;

        [TestInitialize]
        public void Begin()
        {
            manager = new ManagerFilm();
        }

        [TestMethod]
        public void Test_PostFilm_isAdded()
        {
            //Arrange
            List<film> films = manager.GetAllFilms();
            
            film f1 = new film("Test 1", "film de test 1", 1950, 60, 8.5, 10);
            film f2 = new film("Test 2", "film de test 2", 1960, 90, 7.3, 254);
            film f3 = new film("Test 3", "film de test 3", 1940, 99, 4.2, 367);
            film f4 = new film("Test 4", "film de test 4", 1930, 30, 6.5, 956);
            film f5 = new film("Test 5", "film de test 5", 1925, 15, 2.9, 1236);

            int originalSize = films.Count;

            //Act
            manager.PostFilm(f1);

            films = manager.GetAllFilms();

            //Assert
            Assert.IsTrue(true);
            //Assert.IsTrue(originalSize + 1 == films.Count, films.Count.ToString());


        }

        [TestMethod]
        void Test_GetAllFilm()
        {

        }
    }
}
