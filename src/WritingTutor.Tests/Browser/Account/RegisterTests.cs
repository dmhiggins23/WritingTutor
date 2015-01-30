using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WritingTutor.Tests.BrowserFramework;

namespace WritingTutor.Tests.Browser.Account
{
    [TestClass]
    public class RegisterTests : BrowserTestBase
    {
        [TestMethod]
        public void CanRegister() {
            string emailAddress = Guid.NewGuid().ToString("N") + "@home.com";
            string password = "Ab6#" + Guid.NewGuid().ToString();
            RegisterPage.GoTo();
            RegisterPage.RegisterAs(emailAddress).WithPassword(password).WithConfirmPassword(password).Register();
            Assert.IsTrue(HomePage.IsAt);
        }
    }
}
