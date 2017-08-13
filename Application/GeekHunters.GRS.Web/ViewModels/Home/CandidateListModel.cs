using GeekHunters.GRS.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekHunters.GRS.Web.ViewModels.Home
{
    public class CandidateListModel
    {
        public List<CandidateModel> CandidateCollection { get; set; }
    }
}