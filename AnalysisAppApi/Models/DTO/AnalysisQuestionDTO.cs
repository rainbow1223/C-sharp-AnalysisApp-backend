using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisAppApi.Models.DTO
{
    public class AnalysisQuestionDTO : AnalysisQuestion
    {
        //public IEnumerable<AnalysisAnswerDTO> AnswerList { get; set; }
        public byte Tag { get; set; }
    }
}
