using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace AnalysisAppApi.Models
{
    public class AnalysisError
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public Guid AnalysisId { get; set; }
        public string AricleId { get; set; }
        public string ActualError { get; set; }
        public string FromActualComm { get; set; }
        public string ErrorPointTo { get; set; }
        public DateTime ErrorDateTime { get; set; }
        public string ErrorDescription { get; set; }
    }
}
