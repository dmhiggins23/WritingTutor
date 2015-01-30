using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WritingTutor.Web.Domain;

namespace WritingTutor.Tests.BrowserFramework
{
    public class HtmlForm<T> : HtmlForm
    {
        public HtmlForm(string selector = null) : base(selector) { }

        public HtmlForm<T> WithValue<P>(Expression<Func<T, P>> expression, string value){
            string name = GetPropertyName.GetMemberName(expression);
            base.WithValue(name, value);
            return this;
        }
    }

    public class HtmlForm
    {
        private string _formSelector;
        private Dictionary<string, string> _textInputs = new Dictionary<string, string>();
        public HtmlForm(string selector = null) {
            _formSelector = selector == null ? "" : selector + " ";
        }

        public HtmlForm WithValue(string name, string value) {
            _textInputs[name] = value;
            return this;
        }

        public void Submit(string selector = null) {
            foreach (var pair in _textInputs) {
                Driver.Instance
                    .FindElement(By.CssSelector(_formSelector + string.Format("input[name='{0}']", pair.Key)))
                    .SendKeys(pair.Value);
            }
            string submitSelector = string.IsNullOrEmpty(selector) ? " input[type='submit']" : " " + selector;
            Driver.Instance.FindElement(By.CssSelector(_formSelector + submitSelector)).Click();
        }
    }
}
