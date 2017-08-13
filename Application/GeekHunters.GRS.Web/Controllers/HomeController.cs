using GeekHunters.GRS.Services;
using GeekHunters.GRS.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeekHunters.GRS.Web.Controllers
{
    public class HomeController : BaseController
    {
        private ISkillsService skillsService;

        public HomeController(ISkillsService skillsService)
        {
            this.skillsService = skillsService;
        }

        public ActionResult Index()
        {
            var model = this.CreateViewModel<HomeIndexModel>();

            return View(model);
        }

        public ActionResult GetCandidatesView()
        {
            return View("~/Views/Home/_CandidatesView.cshtml");
        }

        public ActionResult GetSkillsView()
        {
            return View("~/Views/Home/_SkillsView.cshtml");
        }

        public ActionResult GetGeekRegistrationView()
        {
            var model = new GeekRegistrationModel();
            model.SkillCollection = this.skillsService.GetSkillCollection();

            return View("~/Views/Home/_GeekRegistrationView.cshtml", model);
        }

        public ActionResult RegisterCandidate(string firstName, string lastName,List<int> skillsCollection)
        {
            return View();
        }
    }
}