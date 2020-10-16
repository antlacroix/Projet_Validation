using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelCinema.Models;
using ModelCinema.Models.ModelValidator;
using System;
using System.Collections.Generic;

namespace UnitTestWebCinema
{
    [TestClass]
    public class TestClass_ValidatorContact
    {
        //private Dictionary<int, string> TestString(string s, int? minLength, int? maxLength, string? regEx, bool canNull, Validator validator)
        //{
        //    Dictionary<int, string> testResult = new Dictionary<int, string>();

        //    if (!canNull)
        //    {
        //        try
        //        {

        //        } catch(Exception e)
        //        {
        //            System.Console.WriteLine(e.Message);
        //        }
        //    }

        //}

        [TestMethod]
        public void Test_IsContactTelephoneValide_EmptyString()
        {
            //arrange
            string testTelephone = "";

            //assert
            Assert.IsFalse(ValidatorContact.IsContactTelephoneValide(testTelephone), "empty phone was accepted");
        }

        [TestMethod]
        public void Test_IsContactTelephoneValide_ToLong()
        {
            //arrange
            string testTelephone = "12345678912";

            //assert
            Assert.IsFalse(ValidatorContact.IsContactTelephoneValide(testTelephone));
        }

        [TestMethod]
        public void Test_IsContactTelephoneValide_ToShort()
        {
            //arrange
            string testTelephone = "123456789";

            //assert
            Assert.IsFalse(ValidatorContact.IsContactTelephoneValide(testTelephone));
        }

        [TestMethod]
        public void Test_IsContactTelephoneValide_Good()
        {
            //arrange
            string testTelephone = "1234567891";

            //assert
            Assert.IsTrue(ValidatorContact.IsContactTelephoneValide(testTelephone));
        }

        [TestMethod]
        public void Test_IsContactCodePostalValide_EmptyString()
        {
            //arrange
            string testCodePostal = "";

            //assert
            Assert.IsFalse(ValidatorContact.IsContactCodePostalValide(testCodePostal));
        }

        [TestMethod]
        public void Test_IsContactCodePostalValide_ToLong()
        {
            //arrange
            string testCodePostal = "1234567";

            //assert
            Assert.IsFalse(ValidatorContact.IsContactCodePostalValide(testCodePostal));
        }

        [TestMethod]
        public void Test_IsContactCodePostalValide_ToShort()
        {
            //arrange
            string testCodePostal = "12345";

            //assert
            Assert.IsFalse(ValidatorContact.IsContactCodePostalValide(testCodePostal));
        }

        [TestMethod]
        public void Test_IsContactCodePostalValide_Good()
        {
            //arrange
            string testCodePostal = "123456";

            //assert
            Assert.IsTrue(ValidatorContact.IsContactCodePostalValide(testCodePostal));
        }
    }

}
