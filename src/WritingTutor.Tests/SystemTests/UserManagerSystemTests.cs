using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WritingTutor.Tests;
using WritingTutor.Web.Domain;
using Microsoft.AspNet.Identity;

namespace WritingTutor.SystemTest
{
    [TestClass]
    public class UserManagerSystemTests : UserManagerTestsBase
    {
        [TestMethod]
        public void CreateUserUsingUsingManager()
        {
            string email = "daniel1234@home.com";

            var result = _userManager.Create(new ApplicationUser { UserName = email, Email = email }, "Pa5$word");

            Assert.IsTrue(result.Succeeded);
            Assert.IsNotNull(Context.Users.Any<ApplicationUser>(o => o.Email == email));

            //var username = "test";
            //var user = context.Users.FirstOrDefault(o=>o.UserName == username);
            //if(user != null) context.Users.Remove(user);
            //context.save
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
