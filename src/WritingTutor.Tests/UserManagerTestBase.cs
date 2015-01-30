using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingTutor.Web;
using WritingTutor.Web.Data;
using WritingTutor.Web.Domain;
using WritingTutor.Web.Tests;

namespace WritingTutor.Tests
{
    public class UserManagerTestsBase : DatabaseTestBase
    {
        protected ApplicationUserManager _userManager;

        [TestInitialize]
        public override void InitializeTest() {
            base.InitializeTest();
            _userManager = CreateUserManager(Context);
        }

        private ApplicationUserManager CreateUserManager(ApplicationDbContext context) {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new ApplicationUserManager(store);
            return manager;
        }

        [TestCleanup]
        public override void CleanupTest() {
            _userManager.Dispose();
            base.CleanupTest();
        }
    }
}
