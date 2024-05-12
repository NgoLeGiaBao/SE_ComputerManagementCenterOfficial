using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BUS_ComputerManagementCenter;


namespace TEST_ComputerManagementCenterOfficial
{
    [TestClass]
    public class RelatedToLogin_UnitTest
    {
        
        [TestMethod]
        public void TestCheckLogin()
        {
            bool expected, actual;
            actual = BUS_RelatedToLogin.Instance.CheckLogin("HV001", "123456");
            expected = false;
            Assert.AreEqual(expected, actual);  
        }

        [TestMethod]
        public void TestChangePassword()
        {
            bool expected, actual;
            actual = BUS_RelatedToLogin.Instance.CheckLogin("HV001", "123456");
            expected = false;
            Assert.AreEqual(expected, actual);
        }
    }
}
