using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisAppApi.Models.DTO
{
    public class AnalysisStatusDTO
    {
        public int TotalAnalysis { get; set; }
        public int TotalError { get; set; }
        public int TotalCompensator { get; set; }
        public int TotalFeedback { get; set; }
        public int TotalProblem { get; set; }
        public int TotalQuestion { get; set; }
        public int TotalAnswer { get; set; }
    }
}
