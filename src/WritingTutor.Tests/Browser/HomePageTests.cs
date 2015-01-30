using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WritingTutor.Tests.BrowserFramework;

namespace WritingTutor.Tests.Browser
{
    [TestClass]
    public class HomePageTests : BrowserTestBase
    {
        [TestMethod]
        public void CanAccessHomePage() {
            HomePage.GoTo();
            Assert.IsTrue(HomePage.IsAt);
        }
    }
}
