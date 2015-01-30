namespace WritingTutor.Web.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WritingTutor.Web.Data;
    using WritingTutor.Web.Domain;

    public class Configuration : DbMigrationsConfiguration<WritingTutor.Web.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WritingTutor.Web.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.


            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            // based on S Allen's MVC 5 Fundamentals Pluralsight Course
            // note foced block on async call with .Result
            var userManager = CreateUserManager(context);
            string[] emails = { "a@b.c", "b@b.c" };
            if (userManager.FindByEmail(emails[0]) == null) {
                foreach (string email in emails) {
                    IdentityResult x = userManager.Create(new ApplicationUser { UserName = email, Email = email }, "password");
                    Console.WriteLine(x.ToString());
                }
            }

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }



        private ApplicationUserManager CreateUserManager(ApplicationDbContext context){
            var store = new UserStore<ApplicationUser>(context);
            var manager = new ApplicationUserManager(store);
            return manager;
        }


    }
}
