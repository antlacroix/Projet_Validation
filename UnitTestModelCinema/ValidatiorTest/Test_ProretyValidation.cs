using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelCinema.Models;
using ModelCinema.Models.ModelValidator;
using System;
using System.Collections.Generic;

namespace UnitTestModelCinema
{
    [TestClass]
    public class Test_ProretyValidation
    {
        [TestMethod]
        public void Test_IsStringValide_stringToshort()
        {
            //Arrange
            string 
                shortString = "short";
            int
                minLength = 10,
                maxLength = 100;

            //Act
            bool testResult = PropretyValidation.IsStringValide(shortString, minLength, maxLength);

            //Assert
            Assert.IsFalse(testResult);
        }

        [TestMethod]
        public void Test_IsStringValide_stringToLong()
        {
            //Arrange
            string 
                shortString = "this string is supposed to be way to long";
            int
                minLength = 1,
                maxLength = 10;

            //Act
            bool testResult = PropretyValidation.IsStringValide(shortString, minLength, maxLength);

            //Assert
            Assert.IsFalse(testResult);
        }

        [TestMethod]
        public void Test_IsStringValide_stringGoodLength()
        {
            //Arrange
            string
                shortString = "this is the right length.";
            int
                minLength = 25,
                maxLength = 25;

            //Act
            bool testResult = PropretyValidation.IsStringValide(shortString, minLength, maxLength);

            //Assert
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void Test_IsStringValideRegEx_failedRegEx()
        {
            //Arrange
            string
                testedString1 = "418-895-9871",
                testedString2 = "this is normal the regEx is incorrect",
                regEx1 = "[0-9]{10}",
                regEx2 = "{[][ds...}";
            int
                minLength = 1,
                maxLength = 100;

            //Act
            bool testResult1 = PropretyValidation.IsStringValide(testedString1, minLength, maxLength, regEx1);
            bool testResult2 = PropretyValidation.IsStringValide(testedString2, minLength, maxLength, regEx2);

            //Assert
            Assert.IsFalse(testResult1, "test 1 failed");
            Assert.IsFalse(testResult2, "test 2 failed");
        }

        [TestMethod]
        public void Test_IsStringValideRegEx_valideRegEx()
        {
            //Arrange
            string
                testedString1 = "4188959871",
                testedString2 = "antoine@mail.com",
                regEx1 = "[0-9]{10}",
                regEx2 = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
            int
                minLength = 1,
                maxLength = 100;

            //Act
            bool testResult1 = PropretyValidation.IsStringValide(testedString1, minLength, maxLength, regEx1);
            bool testResult2 = PropretyValidation.IsStringValide(testedString2, minLength, maxLength, regEx2);
            
            //Assert
            Assert.IsTrue(testResult1, "test 1 failed");
            Assert.IsTrue(testResult2, "test 2 failed");
        }

        [TestMethod]
        public void Test_IsNumberValide_numbertoSmall()
        {
            //Arrange
            int
                val = 0,
                minVal = 10,
                maxVal = 100;

            //Act
            bool testResult = PropretyValidation.IsNumberValide(val, minVal, maxVal);

            //Assert
            Assert.IsFalse(testResult);
        }

        [TestMethod]
        public void Test_IsNumberValide_numbertoBig()
        {
            //Arrange
            int
                val = 110,
                minVal = 10,
                maxVal = 100;

            //Act
            bool testResult = PropretyValidation.IsNumberValide(val, minVal, maxVal);

            //Assert
            Assert.IsFalse(testResult);
        }

        [TestMethod]
        public void Test_IsNumberValide_valideNumber()
        {
            //Arrange
            int
                val = 50,
                minVal = 10,
                maxVal = 100;

            //Act
            bool testResult = PropretyValidation.IsNumberValide(val, minVal, maxVal);

            //Assert
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void Test_IsDateValide_earlyDate()
        {
            //Arrange
            DateTime
                earlyDate = DateTime.Now.AddYears(-10),
                minDate = DateTime.Now,
                maxDate = DateTime.Now.AddYears(10);

            //Act
            bool testResult = PropretyValidation.IsDateValide(earlyDate, minDate, maxDate);

            //Assert
            Assert.IsFalse(testResult);

        }

        [TestMethod]
        public void Test_IsDateValide_lateDate()
        {
            //Arrange
            DateTime
                lateDate = DateTime.Now.AddYears(20),
                minDate = DateTime.Now,
                maxDate = DateTime.Now.AddYears(10);

            //Act
            bool testResult = PropretyValidation.IsDateValide(lateDate, minDate, maxDate);

            //Assert
            Assert.IsFalse(testResult);
        }

        [TestMethod]
        public void Test_IsDateValide_valideDate()
        {
            //Arrange
            DateTime
                valideDate = DateTime.Now.AddYears(5),
                minDate = DateTime.Now,
                maxDate = DateTime.Now.AddYears(10);

            //Act
            bool testResult = PropretyValidation.IsDateValide(valideDate, minDate, maxDate);

            //Assert
            Assert.IsTrue(testResult);
        }

    }

}
