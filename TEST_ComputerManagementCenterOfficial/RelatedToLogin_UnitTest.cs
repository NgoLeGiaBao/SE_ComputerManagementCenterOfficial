using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BUS_ComputerManagementCenter;


namespace TEST_ComputerManagementCenterOfficial
{
    [TestClass]
    public class RelatedToLogin_UnitTest
    {

        // Test CheckLogin with 3 cases
        // Account Exist In DataBase
        [TestMethod]
        public void TestCheckLogin_AccountExistInDataBase()
        {
            bool expected, actual;
            actual = BUS_RelatedToLogin.Instance.CheckLogin("NV091204016193", "123456");
            expected = true;
            Assert.AreEqual(expected, actual);  
        }
        // Account Not Exist In DataBase
        [TestMethod]
        public void TestCheckLogin_AccountNotExistInDataBase()
        {
            bool expected, actual;
            actual = BUS_RelatedToLogin.Instance.CheckLogin("NV091204016194", "654321");
            expected = false;
            Assert.AreEqual(expected, actual);
        }
        // SQL Injection
        [TestMethod]
        public void TestCheckLogin_SQLInjection()
        {
            bool expected, actual;
            actual = BUS_RelatedToLogin.Instance.CheckLogin("NV091204016193", "' OR '1'='1");
            expected = false;
            Assert.AreEqual(expected, actual);
        }


        // Test case CheckAuthentication with four cases
        // Authentication exist
        [TestMethod]
        public void TestCheckAuthentication_Exist()
        {
            bool expected, actual;
            actual = BUS_RelatedToLogin.Instance.CheckVerifyCode("9lGhIs", "NV091204016193");
            expected = true;
            Assert.AreEqual(expected, actual);
        }

        // Authentication no exist
        [TestMethod]
        public void TestCheckAuthentication_NoExist()
        {
            bool expected, actual;
            actual = BUS_RelatedToLogin.Instance.CheckVerifyCode("9lGhIK", "NV091204016193");
            expected = false;
            Assert.AreEqual(expected, actual);
        }
        // Authentication lasted code
        [TestMethod]
        public void TestCheckAuthentication_GetLastedCode()
        {
            bool expected, actual;
            actual = BUS_RelatedToLogin.Instance.CheckVerifyCode("9lGhIs", "NV091204016193");
            expected = true;
            Assert.AreEqual(expected, actual);
        }
        // Authentication no lasted code
        [TestMethod]
        public void TestCheckAuthentication_NotLastedCode()
        {
            bool expected, actual;
            actual = BUS_RelatedToLogin.Instance.CheckVerifyCode("5opgnK", "NV091204016193");
            expected = false;
            Assert.AreEqual(expected, actual);
        }
    }
}
