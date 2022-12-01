using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace AnalysisAppApi.Models
{
    public class AnalysisQuestion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public Guid AnalysisId { get; set; }
        public string AricleId { get; set; }
        public string QuestionPointTo { get; set; }
        public string ActualQuestion { get; set; }
        public DateTime QuestionDate { get; set; }
    }
}
