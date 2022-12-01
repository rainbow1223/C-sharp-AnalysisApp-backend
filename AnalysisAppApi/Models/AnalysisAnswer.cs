using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace AnalysisAppApi.Models
{
    public class AnalysisAnswer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public Guid AnalysisId { get; set; }
        public string AricleId { get; set; }
        public Guid QuestionId { get; set; }
        public string AnswerPointTo { get; set; }
        public string ActualAnswer { get; set; }
        public DateTime AnswerDateTime { get; set; }
    }
}
