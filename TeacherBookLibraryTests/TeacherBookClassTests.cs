using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TeacherBook.Classes;
using TeacherBook.Controllers;

namespace TeacherBookLibraryTests
{
    [TestClass]
    public class TeacherBookClassTests
    {
        [TestMethod]
        public void TeacherBook_UserController_TF()
        {
            // act
            string usr = String.Empty;
            string pass = String.Empty;
            // arrange
            UserController obj = new UserController();
            bool one = obj.Auth(usr, pass);
            // assert
            Assert.IsFalse(one);
        }

        [TestMethod]
        public void TeacherBook_CorrectString_TF()
        {
            // act
            string txt = String.Empty;
            // arrange
            CorrectStringClass obj = new CorrectStringClass();
            bool one = obj.StringOfEmpty(txt);
            // assert
            Assert.IsFalse(one);
        }
    }
}
