using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeekHunters.GRS.Services;
using System.Linq;

namespace GeekHunters.GRS.Services.Test
{
    [TestClass]
    public class CandidateServiceTest
    {
        [TestMethod]
        public void GetAllCandidateTest()
        {
            var candidateService = new CandidateService();
            Assert.IsTrue(candidateService.GetAllCandidate(null).Count > 0);
        }

        [TestMethod]
        public void RegisterCandidateTest()
        {
            var candidateService = new CandidateService();
            var skillService = new SkillsService();

            var skillCollection = skillService.GetSkillCollection().Select(e => e.ID).ToList();
            var r = new Random();

            var firstName = "Kushan";
            var lastName = "Fernando";            
            var randomSkillCollection = skillCollection.OrderBy(x => r.Next()).Take(3);
            
            candidateService.RegisterCandidate(firstName, lastName, randomSkillCollection);

            var candidateCollection = candidateService.GetAllCandidate(randomSkillCollection);

            Assert.IsTrue(candidateCollection.Where(e => e.FirstName == firstName && e.LastName == lastName).Any());
        }
    }
}
