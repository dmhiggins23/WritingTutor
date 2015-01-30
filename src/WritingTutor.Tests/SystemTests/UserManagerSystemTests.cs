using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using WritingTutor.Web;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity;
//using WritingTutor.Web.Models;

using System.Linq;
using WritingTutor.Web.Tests;
using WritingTutor.Web.Data;
using WritingTutor.Web.Domain;
using WritingTutor.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WritingTutor.SystemTest
{
    [TestClass]
    public class UserManagerSystemTests : DatabaseTestBase
    {
        private ApplicationUserManager _userManager;

        public override void InitializeTest()
        {
 	         base.InitializeTest();
             _userManager = CreateUserManager(Context);
        }

        public override void CleanupTest()
        {
            _userManager.Dispose();
            base.CleanupTest();
        }

        [TestMethod]
        public void CreateUserUsingUsingManager()
        {
            //string email = "daniel1234@home.com";
            
            //var result = _userManager.Create(new ApplicationUser { UserName = email, Email = email }, "pa$$word!");

            //Assert.IsTrue(result.Succeeded);
            //Assert.IsNotNull(Context.Users.Any<ApplicationUser>(o=>o.Email == email));

            ////var username = "test";
            ////var user = context.Users.FirstOrDefault(o=>o.UserName == username);
            ////if(user != null) context.Users.Remove(user);
            ////context.save
        }


        private ApplicationUserManager CreateUserManager(ApplicationDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new ApplicationUserManager(store);
            return manager;
        }
        
        //[TestMethod]
        //public void CanCreateAUser()
        //{
        //    ApplicationDbContext context = new ApplicationDbContext();
        //    ApplicationUserManager manager = CreateUserManager(context);


        //    string username = Guid.NewGuid().ToString();
        //    IdentityResult result = manager.Create(new ApplicationUser { UserName = username }, "pa$$word!");
        //    Assert.IsTrue(result.Succeeded);

        //    //var username = "test";
        //    //var user = context.Users.FirstOrDefault(o=>o.UserName == username);
        //    //if(user != null) context.Users.Remove(user);
        //    //context.save

        //}

    }
}
