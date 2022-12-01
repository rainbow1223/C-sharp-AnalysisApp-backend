using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisAppApi.Models.DTO
{
    public class AnalysisDTO : Analysis
    {
        public List<AnalysisQuestionDTO> QuestionList { get; set; }
        public List<AnalysisAnswerDTO> AnswerList { get; set; }
        public List<AnalysisErrorDTO> ErrorList { get; set; }
        public List<AnalysisCompensatorDTO> CompensatorList { get; set; }
        public List<AnalysisProblemDTO> ProblemList { get; set; }
        public List<AnalysisFeedbackDTO> FeedbackList { get; set; }
        public byte Tag { get; set; }
    }
}
