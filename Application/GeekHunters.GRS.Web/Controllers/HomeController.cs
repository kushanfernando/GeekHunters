using GeekHunters.GRS.BusinessModels;
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

        private ICandidateService candidateService;

        public HomeController(ISkillsService skillsService, ICandidateService candidateService)
        {
            this.skillsService = skillsService;
            this.candidateService = candidateService;
        }

        public ActionResult Index()
        {
            var model = this.CreateViewModel<HomeIndexModel>();

            return View(model);
        }

        public ActionResult GetCandidatesView()
        {
            ViewBag.SkillCollection = this.skillsService.GetSkillCollection();

            return View("~/Views/Home/_CandidatesView.cshtml");
        }
        
        public ActionResult GetCandidateListView(IEnumerable<int> skillIdCollection)
        {
            var model = new CandidateListModel();
            model.CandidateCollection = this.candidateService.GetAllCandidate(skillIdCollection);

            return View("~/Views/Home/_CandidateListView.cshtml", model);
        }

        public ActionResult GetSkillsView()
        {
            var model = new SkillListModel
            {
                SkillCollection = this.skillsService.GetSkillCollection()
            };

            return View("~/Views/Home/_SkillsView.cshtml", model);
        }

        public ActionResult GetGeekRegistrationView()
        {
            var model = new GeekRegistrationModel();
            model.SkillCollection = this.skillsService.GetSkillCollection();

            return View("~/Views/Home/_GeekRegistrationView.cshtml", model);
        }

        public ActionResult RegisterCandidate(string firstName, string lastName,List<int> skillsCollection)
        {
            this.candidateService.RegisterCandidate(firstName, lastName, skillsCollection);

            return Content("OK");
        }
    }
}