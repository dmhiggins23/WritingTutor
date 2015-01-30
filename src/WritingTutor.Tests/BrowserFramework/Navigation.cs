using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingTutor.Tests.BrowserFramework
{
    public class Navigation
    {
        //public static class MenuX
        //{
        //    public static class SubMenuA{
        //        public static void Select() { }
        //    }
        //}


        public static bool IsMenuCollapsed {
            get {
                var collapsedButton = Driver.Instance.FindElement(By.CssSelector("button.navbar-toggle"));
                return collapsedButton != null && collapsedButton.Displayed;
            }
        }

        private static void OpenCollapsedMenu(){
            var collapsedButton = Driver.Instance.FindElement(By.CssSelector("button.navbar-toggle"));
            if(collapsedButton != null && collapsedButton.Displayed) collapsedButton.Click();
        }

        public static class Home
        {
            public static void Select() {
                OpenCollapsedMenu();
                Driver.Instance.FindElement(By.LinkText("Home")).Click();
            }
        }

        public static class Register
        {
            public static void Select() {
                OpenCollapsedMenu();
                Driver.Instance.FindElement(By.LinkText("Register")).Click();
            }
        }

        public static class Login
        {
            public static void Select() {
                OpenCollapsedMenu();
                Driver.Instance.FindElement(By.LinkText("Log in")).Click();
            }
        }

        

    }


}
