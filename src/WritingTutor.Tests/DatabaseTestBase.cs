using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using WritingTutor.Web.Data;

namespace WritingTutor.Web.Tests
{
    [TestClass]
    public class DatabaseTestBase
    {

        private TransactionScope _scope;

        private ApplicationDbContext _context;
        protected ApplicationDbContext Context { get { return _context; } }


        [AssemblyInitialize]
        public static void InitializeAssembly(TestContext testContext) {
            DatabaseCreator.Create();
        }

        [TestInitialize]
        public virtual void InitializeTest() {
            _scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            _context = new ApplicationDbContext();
        }

        [TestCleanup]
        public virtual void CleanupTest() {
            _context.Dispose();
            _scope.Dispose();
        }


    }
}
