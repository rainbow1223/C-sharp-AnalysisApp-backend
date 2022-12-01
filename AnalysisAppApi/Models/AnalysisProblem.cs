using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace AnalysisAppApi.Models
{
    public class AnalysisProblem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public Guid AnalysisId { get; set; }
        public string AricleId { get; set; }
        public Guid ErrorId { get; set; }
        public string ProblemName { get; set; }
        public string ActualProblem { get; set; }
        public string ProblemDescription { get; set; }
        public DateTime ProblemDateTime { get; set; }
    }
}
