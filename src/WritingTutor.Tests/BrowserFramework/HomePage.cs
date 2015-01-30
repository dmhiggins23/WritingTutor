using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingTutor.Web.Controllers;

namespace WritingTutor.Tests.BrowserFramework
{
    public static class HomePage
    {
        public static void GoTo() {
            Driver.GoTo<HomeController>(o=>o.Index());
        }

        public static bool IsAt {
            get {
                return Page.Title == "Home Page";
                //var h2s = Driver.Instance.FindElements(By.TagName("h2"));
                //return h2s.Any(o => o.Text == "Getting started");
            }
        }
    }
}
