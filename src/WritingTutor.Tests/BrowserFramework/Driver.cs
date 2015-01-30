using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WritingTutor.Tests.BrowserFramework
{
    public class Driver
    {

        public static IWebDriver Instance { get; set; }
        //            var driver = new FirefoxDriver();

        public static void Initialize() {
            Instance = new FirefoxDriver();
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        public static void GoTo(string url) {
            Instance.Navigate().GoToUrl(url);
        }

        public static void GoTo<TController>(Expression<Func<TController, object>> expression, int? id = null, object vals = null) {
            string url = CreateUrl(expression, id, vals);
            GoTo(url);
        }

        public static string CreateUrl<TController>(Expression<Func<TController, object>> expression, int? id = null, object vals = null) {
            string controllerName = typeof(TController).Name.Replace("Controller", string.Empty);
            string actionName = ((MethodCallExpression)expression.Body).Method.Name;
            string query = "";
            if (vals != null) {
                Type type = vals.GetType();
                foreach (PropertyInfo pi in type.GetProperties()) {
                    query = string.IsNullOrEmpty(query) ? "?" : "&";
                    query = pi.Name + "=" + pi.GetValue(vals);
                }
            }
            string strId = id != null ? "/" + id.ToString() : "";
            string url = WebSite.BaseUrl + "/" + controllerName + "/" + actionName + strId + query;
            return url;
        }


        public static void MobileSize() {
            Instance.Manage().Window.Size = new System.Drawing.Size(400, 400);
        }

        public static void Close() {
            Instance.Close();
        }
    }

}
