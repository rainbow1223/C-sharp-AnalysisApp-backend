using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisAppApi.Models
{
    public class Analysis
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public string AricleId { get; set; }
        public string AnalysisFrom { get; set; }
        public string AnalysisSubject { get; set; }
        public string ActualAnalysis { get; set; }
        public string EntityUnderAnalysis { get; set; }
    }
}
