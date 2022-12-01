using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace AnalysisAppApi.Models
{
    public class AnalysisCompensator
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public string AricleId { get; set; }
        public Guid AnalysisId { get; set; }
        public Guid ErrorId { get; set; }
        public string ActualCompensator { get; set; }
        public string InActualAppComm { get; set; }
        public DateTime CompensatorDateTime { get; set; }
        public string CompensatorDescription { get; set; }
    }
}
