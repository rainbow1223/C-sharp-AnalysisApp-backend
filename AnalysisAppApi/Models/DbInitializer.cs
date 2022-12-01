using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalysisAppApi.Models
{
    public class DbInitializer
    {
        public static void Initialize(AnalysisDbContext context)
        {
            context.Database.EnsureCreated();

            //// Look for any students.
            //if (context.AnalysisQuestion.Any())
            //{
            //    return;   // DB has been seeded
            //}

            //var questions = new AnalysisQuestion[]
            //{
            //new AnalysisQuestion{ActualQuestion="Carson",QuestionPointTo="Alexander"},
            //};
            //foreach (var q in questions)
            //{
            //    context.AnalysisQuestion.Add(q);
            //}
            context.SaveChanges();
        }
    }
}
