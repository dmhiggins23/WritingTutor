using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingTutor.Tests.BrowserFramework;
using WritingTutor.Web.Tests;

namespace WritingTutor.Tests.Browser
{
    public class BrowserTestBase : DatabaseTestBase
    {
        [TestInitialize]
        public override void InitializeTest() {
            base.InitializeTest();
            Driver.Initialize();
        }
        [TestCleanup]
        public override void CleanupTest() {
            Driver.Close();
            base.CleanupTest();
        }
    }
}


