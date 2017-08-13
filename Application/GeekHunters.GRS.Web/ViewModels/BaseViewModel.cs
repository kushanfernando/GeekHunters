using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekHunters.GRS.Web.ViewModels
{
    public abstract class BaseViewModel
    {
        public string Title { get; set; }

        public string ApplicationName { get; set; }
    }
}