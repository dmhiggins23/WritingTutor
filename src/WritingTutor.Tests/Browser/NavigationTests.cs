using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WritingTutor.Tests.BrowserFramework;

namespace WritingTutor.Tests.Browser
{
    [TestClass]
    public class NavigationTests : BrowserTestBase
    {
        [TestMethod]
        public void CanGoToHomePage() {
            LoginPage.GoTo();
            Navigation.Home.Select();
            Assert.IsTrue(HomePage.IsAt);
        }

        [TestMethod]
        public void CanGoToLoginPage() {
            HomePage.GoTo();
            Navigation.Login.Select();
            Assert.IsTrue(LoginPage.IsAt);
        }

        [TestMethod]
        public void CanGoToRegisterPage() {
            HomePage.GoTo();
            Navigation.Register.Select();
            Assert.IsTrue(RegisterPage.IsAt);
        }

        [TestMethod]
        public void MenuWillCollapseIfWindowWidthIsReduced() {
            HomePage.GoTo();
            Assert.IsFalse(Navigation.IsMenuCollapsed, "Preconditions for test not met: menu is not collapsed");
            Driver.MobileSize();
            Assert.IsTrue(Navigation.IsMenuCollapsed, "Menu did not collapse with window width is reduced");
        }


        [TestMethod]
        public void CanNavigateThroughCollapsedMenu() {
            Driver.MobileSize();
            HomePage.GoTo();

            Navigation.Login.Select();
            Assert.IsTrue(LoginPage.IsAt, "Could not open Login page from collapsed navigation menu");
            
            Navigation.Register.Select();
            Assert.IsTrue(RegisterPage.IsAt, "Could not open Register page from collapsed navigation menu");

            Navigation.Home.Select();
            Assert.IsTrue(HomePage.IsAt, "Could not open Home page from collapsed navigation menu");
        }

        
        
    }
}
