using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WritingTutor.Tests.BrowserFramework;

namespace WritingTutor.Tests.Browser.Account
{
    [TestClass]
    public class Login : BrowserTestBase
    {
        [TestMethod]
        public void CanLogin() {
            LoginPage.GoTo();
            LoginPage.LoginAs("a@b.c").WithPassword("password").Login();
            Assert.IsTrue(HomePage.IsAt, "Failed to login");
        }
    }
}
