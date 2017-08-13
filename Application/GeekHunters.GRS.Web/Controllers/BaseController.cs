using GeekHunters.GRS.Services;
using GeekHunters.GRS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeekHunters.GRS.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected T CreateViewModel<T>() where T : BaseViewModel
        {
            var viewModel = Activator.CreateInstance<T>();
            viewModel.ApplicationName = Util.ApplicationName;

            return viewModel;
        }
    }
}