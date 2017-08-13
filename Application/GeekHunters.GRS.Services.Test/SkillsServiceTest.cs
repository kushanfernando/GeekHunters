using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunters.GRS.Services.Test
{
    [TestClass]
    public class SkillsServiceTest
    {
        [TestMethod]
        public void GetSkillCollectionTest()
        {
            var skillsService = new SkillsService();

            Assert.IsTrue(skillsService.GetSkillCollection().Count > 0);
        }
    }
}
