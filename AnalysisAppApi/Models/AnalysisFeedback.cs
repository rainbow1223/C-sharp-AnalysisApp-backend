using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnalysisAppApi.Models
{
    public class AnalysisFeedback
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public Guid AnalysisId { get; set; }
        public string AricleId { get; set; }
        public string ErrorId { get; set; }
        public string ApplicaitonName { get; set; }
        public string CommFunction { get; set; }
        public string CompensatorId { get; set; }
        public string ActualCompReplaced { get; set; }
        public string FeedbackSubject { get; set; }
        public string FeedbackApp { get; set; }
        public string FromPerson { get; set; }
        public string FromPersonId { get; set; }
        public string ToPerson { get; set; }
        public string ToPersonId { get; set; }
        public string ActualFeedback { get; set; }
    }
}
