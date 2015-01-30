using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingTutor.Web.Migrations;
using WritingTutor.Web.Data;

namespace WritingTutor.Web.Tests
{
    // from pluralsight course Automated Testing in Asp.net with SpecsFor and SpecsFor.Mvc
    public static class DatabaseCreator
    {
        private static bool _isCreated;
        public static void Create() {
            if (_isCreated) return;

            // prepares DataDirectory so it means something in the app.config connection string
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            var strategy = new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>();
            Database.SetInitializer(strategy);

            // create DbContext and forces EF to initialize the database
            using (var context = new ApplicationDbContext()) {
                context.Database.Initialize(force: true);
            }

            _isCreated = true;
        }
    }
}
