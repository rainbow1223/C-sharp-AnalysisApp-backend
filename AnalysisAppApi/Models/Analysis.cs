using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisAppApi.Models
{
    public class Article
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public int UserID { get; set; }
        public string Heading { get; set; }
        public string Text { get; set; }
        public string Summary { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
