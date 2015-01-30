using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WritingTutor.Web.Service
{
    public interface IHomeService
    {
        string GetName();
    }
    public class HomeService : IHomeService
    {
        public string GetName() {
            return "John Smith";
        }
    }
}