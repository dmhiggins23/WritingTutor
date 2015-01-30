using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WritingTutor.Web.Tests;
using WritingTutor.Web.Domain;
//using WritingTutor.Web.Models;

namespace WritingTutor.SystemTest
{
    [TestClass]
    public class DbContextSystemTests : DatabaseTestBase
    {
        [TestMethod]
        public void CanCreateContext()
        {
            Assert.IsNotNull(Context);
        }

        [TestMethod]
        public void CanSaveObjectToContext() { 
            var newUser = new ApplicationUser{
                UserName = "TempUser"
            };
            Context.Users.Add(newUser);
            Context.SaveChanges();

            Assert.IsNotNull(Context.Users.Any(o=>o.UserName == newUser.UserName));
        }
    }
}
