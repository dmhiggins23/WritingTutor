using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingTutor.Web.Controllers;
using WritingTutor.Web.Models;

namespace WritingTutor.Tests.BrowserFramework
{
    public static class RegisterPage
    {
        public static void GoTo() {
            Driver.GoTo<AccountController>(o => o.Register());
        }
        public static RegisterCommand RegisterAs(string email) {
            return new RegisterCommand(email);
        }
        public static bool IsAt {
            get {
                return Page.Title == "Register";
            }
        }
    }

    public class RegisterCommand
    {
        private string _email, _password, _confirmPassword;
        public RegisterCommand(string email) {
            _email = email;
        }
        public RegisterCommand WithPassword(string password) {
            _password = password;
            return this;
        }
        public RegisterCommand WithConfirmPassword(string confirmPassword) {
            _confirmPassword = confirmPassword;
            return this;
        }
        public void Register() {
            var form = new HtmlForm<RegisterViewModel>();
            form.WithValue(o => o.Email, _email)
                .WithValue(o => o.Password, _password)
                .WithValue(o => o.ConfirmPassword, _confirmPassword)
                .Submit();
        }
    }
}
