using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingTutor.Web.Controllers;
using WritingTutor.Web.Models;

namespace WritingTutor.Tests.BrowserFramework
{
    public class LoginPage
    {
        public static void GoTo(string returnUrl = null) {
            object queryVals = returnUrl == null ? null : new { returnUrl };
            Driver.GoTo<AccountController>(o => o.Login(""), null, queryVals);
        }
        public static LoginCommand LoginAs(string username) {
            return new LoginCommand(username);
        }
        public static bool IsAt {
            get {
                return Page.Title == "Log in";
            }
        }
    }


    public class LoginCommand
    {
        private string _email;
        private string _password;

        public LoginCommand(string username) {
            _email = username;
        }
        public LoginCommand WithPassword(string password) {
            _password = password;
            return this;
        }

        //public void Login() {
        //    var loginInput = Driver.Instance.FindElement(By.Id("Email"));
        //    loginInput.SendKeys(_username);

        //    var passwordInput = Driver.Instance.FindElement(By.Id("Password"));
        //    passwordInput.SendKeys(_password);

        //    var loginButton = Driver.Instance.FindElement(By.CssSelector("input[type='submit']"));
        //    loginButton.Click();
        //}

        public void Login() {
            //var loginInput = Driver.Instance.FindElement(By.Id("Email"));
            //loginInput.SendKeys(_email);

            //var passwordInput = Driver.Instance.FindElement(By.Id("Password"));
            //passwordInput.SendKeys(_password);

            //var loginButton = Driver.Instance.FindElement(By.CssSelector("input[type='submit']"));
            //loginButton.Click();

            var form = new HtmlForm<LoginViewModel>();
            form.WithValue(o => o.Email, _email)
                .WithValue(o => o.Password, _password)
                .Submit();
        }
    }

}
