using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisAppApi.Models.DTO
{
    public class AnalysisErrorDTO : AnalysisError
    {
        public byte Tag { get; set; }
    }
}
