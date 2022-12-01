using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisAppApi.Models.DTO
{
    public class AnalysisAnswerDTO : AnalysisAnswer
    {
        public string QuestionPointTo { get; set; }
        public string ActualQuestion { get; set; }
        public byte Tag { get; set; }
    }
}
