using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnalysisAppApi.Models;
using AnalysisAppApi.Models.DTO;
using AutoMapper;

namespace AnalysisAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly AnalysisDbContext _context;
        private readonly IMapper _mapper;
        public AnalysisController(AnalysisDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //// GET: api/AnalysisQuestion
        //[HttpGet]
        //public async Task<ActionResult<AnalysisDTO>> GetAnalysis()
        //{
        //    var x = new AnalysisDTO();
        //    return await _context.AnalysisQuestions.ToListAsync();
        //}

        // GET: api/AnalysisQuestion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalysisDTO>> GetAnalysis(string id)
        {
            //AnalysisDTO analysisDTO = new AnalysisDTO();
            var analysis = await _context.Analysis.FirstOrDefaultAsync(x => x.AricleId == id);
            if (analysis != null)
            {
                var analysisDTO = MapExistingAnalysis(analysis);
                MapExistingAnalysisError(analysisDTO);
                MapExistingAnalysisCompensator(analysisDTO);
                MapExistingAnalysisQuestion(analysisDTO);
                MapExistingAnalysisAnswer(analysisDTO);
                MapExistingAnalysisFeedback(analysisDTO);
                return analysisDTO;
            }
            else
            {
                return new AnalysisDTO();
            }
        }

        //// PUT: api/AnalysisQuestion/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAnalysisQuestion(Guid id, AnalysisQuestion analysisQuestion)
        //{
        //    if (id != analysisQuestion.id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(analysisQuestion).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AnalysisQuestionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Analysis
        [HttpPost]
        public async Task<ActionResult<AnalysisDTO>> Analysis(AnalysisDTO analysis)
        {
            try
            {
                MapAnalysis(analysis);
                MapAnalysisError(analysis);
                MapAnalysisCompensator(analysis);
                MapAnalysisQuestion(analysis);
                MapAnalysisAnswer(analysis);
                MapAnalysisProblem(analysis);
                MapAnalysisFeedback(analysis);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAnalysis", new { id = analysis.id }, analysis);
            }catch(Exception e)
            {
                throw e;
            }
        }


        private void MapAnalysis(AnalysisDTO analysis)
        {
            try
            {
                var analysisMapper = new MapperConfiguration(cfg => cfg.CreateMap<AnalysisDTO, Analysis>().BeforeMap((s, d) =>
                {
                    switch (s.Tag)
                    {
                        case 1:
                            s.id = Guid.NewGuid();
                            break;
                        case 2:
                            s.id = Guid.NewGuid();
                            break;
                        case 3:

                            break;
                    }
                }).AfterMap((s, d) =>
                {
                    switch (s.Tag)
                    {
                        case 1:
                            _context.Analysis.Add(d);
                            break;
                        case 2:
                            _context.Entry(d).State = EntityState.Modified;
                            break;
                        case 3:
                            _context.Analysis.Remove(d);
                            break;
                    }
                    s.Tag = 0;
                }));

                var mapper = analysisMapper.CreateMapper();
                var dest = mapper.Map<Analysis>(analysis);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void MapAnalysisError(AnalysisDTO analysis)
        {
            try
            {
                var errorMapper = new MapperConfiguration(cfg => cfg.CreateMap<AnalysisErrorDTO, AnalysisError>().BeforeMap((s, d) =>
                {
                    switch (s.Tag)
                    {
                        case 1:

                            var newId = Guid.NewGuid();
                            analysis.CompensatorList.ForEach(x =>
                            {
                                x.ErrorId = x.ErrorId == s.id ? newId : s.id;
                            });
                            s.id = newId;
                            s.AnalysisId = analysis.id;
                            s.AricleId = analysis.AricleId;
                            s.ErrorDateTime = DateTime.Now;
                            break;
                        case 2:
                            s.id = Guid.NewGuid();
                            break;
                        case 3:

                            break;
                    }
                }).AfterMap((s, d) =>
                {
                    switch (s.Tag)
                    {
                        case 1:
                            _context.AnalysisError.Add(d);
                            break;
                        case 2:
                            _context.Entry(d).State = EntityState.Modified;
                            break;
                        case 3:
                            _context.AnalysisError.Remove(d);
                            break;
                    }
                    s.Tag = 0;
                }));

                var mapper = errorMapper.CreateMapper();
                var dest = analysis.ErrorList.Select(x => mapper.Map<AnalysisError>(x)).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void MapAnalysisCompensator(AnalysisDTO analysis)
        {
            try
            {
                var compensatorMapper = new MapperConfiguration(cfg => cfg.CreateMap<AnalysisCompensatorDTO, AnalysisCompensator>().BeforeMap((s, d) =>
                {
                    switch (s.Tag)
                    {
                        case 1:
                            s.id = Guid.NewGuid();
                            s.AnalysisId = analysis.id;
                            s.AricleId = analysis.AricleId;
                            s.CompensatorDateTime = DateTime.Now;
                            break;
                        case 2:
                            s.id = Guid.NewGuid();
                            break;
                        case 3:

                            break;
                    }
                }).AfterMap((s, d) =>
                {
                    switch (s.Tag)
                    {
                        case 1:
                            _context.AnalysisCompensator.Add(d);
                            break;
                        case 2:
                            _context.Entry(d).State = EntityState.Modified;
                            break;
                        case 3:
                            _context.AnalysisCompensator.Remove(d);
                            break;
                    }
                    s.Tag = 0;
                }));

                var mapper = compensatorMapper.CreateMapper();
                var dest = analysis.CompensatorList.Select(x => mapper.Map<AnalysisCompensator>(x)).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void MapAnalysisQuestion(AnalysisDTO analysis)
        {
            try
            {
                var compensatorMapper = new MapperConfiguration(cfg => cfg.CreateMap<AnalysisQuestionDTO, AnalysisQuestion>().BeforeMap((s, d) =>
                {
                    switch (s.Tag)
                    {
                        case 1:
                            var newId = Guid.NewGuid();
                            //analysis.CompensatorList.ForEach(x =>
                            //{
                            //    x.ErrorId = x.ErrorId == s.id ? newId : s.id;
                            //});
                            s.id = newId;
                            s.AnalysisId = analysis.id;
                            s.AricleId = analysis.AricleId;
                            s.QuestionDate = DateTime.Now;
                            break;
                        case 2:
                            s.id = Guid.NewGuid();
                            break;
                        case 3:

                            break;
                    }
                }).AfterMap((s, d) =>
                {
                   // MapAnalysisAnswer(s);
                    switch (s.Tag)
                    {
                        case 1:
                            _context.AnalysisQuestion.Add(d);
                            break;
                        case 2:
                            _context.Entry(d).State = EntityState.Modified;
                            break;
                        case 3:
                            _context.AnalysisQuestion.Remove(d);
                            break;
                    }
                    s.Tag = 0;
                }));

                var mapper = compensatorMapper.CreateMapper();
                var dest = analysis.QuestionList.Select(x => mapper.Map<AnalysisQuestion>(x)).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void MapAnalysisAnswer(AnalysisDTO analysis)
        {
            try
            {
                var answerMapper = new MapperConfiguration(cfg => cfg.CreateMap<AnalysisAnswerDTO, AnalysisAnswer>().BeforeMap((s, d) =>
                {
                    switch (s.Tag)
                    {
                        case 1:
                            s.id = Guid.NewGuid();
                            s.AnswerDateTime = DateTime.Now;
                            break;
                        case 2:
                            s.id = Guid.NewGuid();
                            break;
                        case 3:

                            break;
                    }
                }).AfterMap((s, d) =>
                {
                    switch (s.Tag)
                    {
                        case 1:
                            _context.AnalysisAnswer.Add(d);
                            break;
                        case 2:
                            _context.Entry(d).State = EntityState.Modified;
                            break;
                        case 3:
                            _context.AnalysisAnswer.Remove(d);
                            break;
                    }
                    s.Tag = 0;
                }));

                var mapper = answerMapper.CreateMapper();
                var dest = analysis.AnswerList.Select(x => mapper.Map<AnalysisAnswer>(x)).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void MapAnalysisProblem(AnalysisDTO analysis)
        {
            try
            {
                var problemMapper = new MapperConfiguration(cfg => cfg.CreateMap<AnalysisProblemDTO, AnalysisProblem>().BeforeMap((s, d) =>
                {
                    switch (s.Tag)
                    {
                        case 1:
                            s.id = Guid.NewGuid();
                            s.ProblemDateTime = DateTime.Now;
                            break;
                        case 2:
                            s.id = Guid.NewGuid();
                            break;
                        case 3:

                            break;
                    }
                }).AfterMap((s, d) =>
                {
                    switch (s.Tag)
                    {
                        case 1:
                            _context.AnalysisProblem.Add(d);
                            break;
                        case 2:
                            _context.Entry(d).State = EntityState.Modified;
                            break;
                        case 3:
                            _context.AnalysisProblem.Remove(d);
                            break;
                    }
                    s.Tag = 0;
                }));

                var mapper = problemMapper.CreateMapper();
                var dest = analysis.ProblemList.Select(x => mapper.Map<AnalysisProblem>(x)).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void MapAnalysisFeedback(AnalysisDTO analysis)
        {
            try
            {
                var feedbackMapper = new MapperConfiguration(cfg => cfg.CreateMap<AnalysisFeedbackDTO, AnalysisFeedback>().BeforeMap((s, d) =>
                {
                    switch (s.Tag)
                    {
                        case 1:
                            s.id = Guid.NewGuid();
                            break;
                        case 2:
                            s.id = Guid.NewGuid();
                            break;
                        case 3:
                            break;
                    }
                }).AfterMap((s, d) =>
                {
                    switch (s.Tag)
                    {
                        case 1:
                            _context.AnalysisFeedback.Add(d);
                            break;
                        case 2:
                            _context.Entry(d).State = EntityState.Modified;
                            break;
                        case 3:
                            _context.AnalysisFeedback.Remove(d);
                            break;
                    }
                    s.Tag = 0;
                }));

                var mapper = feedbackMapper.CreateMapper();
                var dest = analysis.FeedbackList.Select(x => mapper.Map<AnalysisFeedback>(x)).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private AnalysisDTO MapExistingAnalysis(Analysis analysis)
        {
            try
            {
                var analysisMapper = new MapperConfiguration(cfg => cfg.CreateMap<Analysis, AnalysisDTO>().BeforeMap((s, d) =>
                {
                    d.Tag = 0;
                    d.ErrorList = new List<AnalysisErrorDTO>();
                    d.CompensatorList = new List<AnalysisCompensatorDTO>();
                    d.QuestionList = new List<AnalysisQuestionDTO>();
                }));

                var mapper = analysisMapper.CreateMapper();
                return mapper.Map<AnalysisDTO>(analysis);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void MapExistingAnalysisError(AnalysisDTO analysis)
        {
            try
            {
                var analysisError = _context.AnalysisError.Where(x => x.AnalysisId == analysis.id).ToList();
                if (analysisError.Count > 0)
                {
                    var errorMapper = new MapperConfiguration(cfg => cfg.CreateMap<AnalysisError, AnalysisErrorDTO>().BeforeMap((s, d) =>
                    {
                        d.Tag = 0;
                    }));

                    var mapper = errorMapper.CreateMapper();
                    var dest = analysisError.Select(x => mapper.Map<AnalysisErrorDTO>(x)).ToList();
                    analysis.ErrorList.AddRange(dest);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void MapExistingAnalysisCompensator(AnalysisDTO analysis)
        {

            try
            {
                var existingData = _context.AnalysisCompensator.Where(x => x.AnalysisId == analysis.id).ToList();
                if (existingData.Count > 0)
                {
                    var errorMapper = new MapperConfiguration(cfg => cfg.CreateMap<AnalysisCompensator, AnalysisCompensatorDTO>().BeforeMap((s, d) =>
                    {
                        d.Tag = 0;
                    }));

                    var mapper = errorMapper.CreateMapper();
                    var dest = existingData.Select(x => mapper.Map<AnalysisCompensatorDTO>(x)).ToList();
                    analysis.CompensatorList.AddRange(dest);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        private void MapExistingAnalysisQuestion(AnalysisDTO analysis)
        {
            try
            {
                try
                {
                    var existingData = _context.AnalysisQuestion.Where(x => x.AnalysisId == analysis.id).ToList();
                    if (existingData.Count > 0)
                    {
                        var errorMapper = new MapperConfiguration(cfg => cfg.CreateMap<AnalysisQuestion, AnalysisQuestionDTO>().BeforeMap((s, d) =>
                        {
                            d.Tag = 0;
                        }));

                        var mapper = errorMapper.CreateMapper();
                        var dest = existingData.Select(x => mapper.Map<AnalysisQuestionDTO>(x)).ToList();
                        analysis.QuestionList.AddRange(dest);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void MapExistingAnalysisAnswer(AnalysisDTO analysis)
        {
            try
            {
                var existingData = _context.AnalysisAnswer.Where(x => x.AnalysisId == analysis.id).ToList();
                if (existingData.Count > 0)
                {
                    var errorMapper = new MapperConfiguration(cfg => cfg.CreateMap<AnalysisAnswer, AnalysisAnswerDTO>().BeforeMap((s, d) =>
                    {
                        d.Tag = 0;
                    }));

                    var mapper = errorMapper.CreateMapper();
                    var dest = existingData.Select(x => mapper.Map<AnalysisAnswerDTO>(x)).ToList();
                    //analysis.AnswerList.AddRange(dest);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void MapExistingAnalysisFeedback(AnalysisDTO analysis)
        {
            try
            {
                var existingData = _context.AnalysisFeedback.Where(x => x.AnalysisId == analysis.id).ToList();
                if (existingData.Count > 0)
                {
                    var errorMapper = new MapperConfiguration(cfg => cfg.CreateMap<AnalysisFeedback, AnalysisFeedbackDTO>().BeforeMap((s, d) =>
                    {
                        d.Tag = 0;
                    }));

                    var mapper = errorMapper.CreateMapper();
                    var dest = existingData.Select(x => mapper.Map<AnalysisFeedbackDTO>(x)).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // DELETE: api/AnalysisQuestion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalysis(Guid id)
        {
            var analysisQuestion = await _context.Analysis.FindAsync(id);
            if (analysisQuestion == null)
            {
                return NotFound();
            }

            _context.Analysis.Remove(analysisQuestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnalysisQuestionExists(Guid id)
        {
            return _context.AnalysisQuestion.Any(e => e.id == id);
        }

        [HttpGet("GetArticleStatus")]
        public async Task<ActionResult<object>> GetArticleStatus(string articleId)
        {
            var status = new AnalysisStatusDTO();
            status.TotalAnalysis = await _context.Analysis.Where(x => x.AricleId == articleId).CountAsync();
            status.TotalAnswer = await _context.AnalysisAnswer.Where(x => x.AricleId == articleId).CountAsync();
            status.TotalFeedback = await _context.AnalysisFeedback.Where(x => x.AricleId == articleId).CountAsync();
            status.TotalCompensator = await _context.AnalysisCompensator.Where(x => x.AricleId == articleId).CountAsync();
            status.TotalError = await _context.AnalysisError.Where(x => x.AricleId == articleId).CountAsync();
            status.TotalProblem = await _context.AnalysisProblem.Where(x => x.AricleId == articleId).CountAsync();
            status.TotalQuestion = await _context.AnalysisQuestion.Where(x => x.AricleId == articleId).CountAsync();

            //existingData.ForEach(x =>
            //{
            //    status.TotalAnswer = 0;
            //    status.TotalFeedback = 0;
            //    status.TotalCompensator = _context.AnalysisCompensator.Where(c => c.AnalysisId == x.id).Count();
            //    status.TotalError = _context.AnalysisError.Where(e => e.AnalysisId == x.id).Count();
            //    status.TotalProblem = 0; //_context.AnalysisError.Where(e => e.AnalysisId == x.id).Count();
            //    status.TotalQuestion = _context.AnalysisQuestion.Where(e => e.AnalysisId == x.id).Count();
            //});

            return status;
        }

        [HttpPost]
        [Route("SaveArticle")]
        public async Task<ActionResult<ArticleDTO>> SaveArticle(ArticleDTO article)
        {
            try
            {
                var articleMapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, Article>().BeforeMap((s, d) =>
                {
                    switch (s.Tag)
                    {
                        case 1:
                            s.id = Guid.NewGuid();
                            s.CreatedDateTime = DateTime.Now;
                            break;
                        case 2:
                            s.id = Guid.NewGuid();
                            break;
                        case 3:
                            break;
                    }
                }).AfterMap((s, d) =>
                {
                    switch (s.Tag)
                    {
                        case 1:
                            _context.Article.Add(d);
                            break;
                        case 2:
                            _context.Entry(d).State = EntityState.Modified;
                            break;
                        case 3:
                            _context.Article.Remove(d);
                            break;
                    }
                    s.Tag = 0;
                }));

                var mapper = articleMapper.CreateMapper();
                var dest = mapper.Map<Article>(article);
                await _context.SaveChangesAsync();

                return article;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("GetArticle")]
        public async Task<ActionResult<object>> GetArticle()
        {
            var articleList = from article in _context.Article
                              join user in _context.Accounts on article.UserID equals user.Id
                              select new
                              {
                                  article.id,
                                  article.UserID,
                                  article.Heading,
                                  article.Text,
                                  article.Summary,
                                  article.CreatedDateTime,
                                  CreatedBy = user.FirstName + ' ' + user.LastName
                                };

            articleList = articleList.OrderByDescending(a => a.CreatedDateTime);

            var analysisList = _context.Analysis.ToList();
            var answerList = _context.AnalysisAnswer.ToList();
            var feedbackList = _context.AnalysisFeedback.ToList();
            var compensatorList = _context.AnalysisCompensator.ToList();
            var errorList = _context.AnalysisError.ToList();
            var problemList = _context.AnalysisProblem.ToList();
            var questionList = _context.AnalysisQuestion.ToList();

            var articleListWithStatus = new List<object>();

            foreach (var item in articleList)
            {
                var status = new AnalysisStatusDTO
                {
                    TotalAnalysis = analysisList.Where(a => a.AricleId == item.id.ToString()).Count(),
                    TotalAnswer = answerList.Where(a => a.AricleId == item.id.ToString()).Count(),
                    TotalFeedback = feedbackList.Where(a => a.AricleId == item.id.ToString()).Count(),
                    TotalCompensator = compensatorList.Where(a => a.AricleId == item.id.ToString()).Count(),
                    TotalError = errorList.Where(a => a.AricleId == item.id.ToString()).Count(),
                    TotalProblem = problemList.Where(a => a.AricleId == item.id.ToString()).Count(),
                    TotalQuestion = questionList.Where(a => a.AricleId == item.id.ToString()).Count(),
                };

                var article = new
                {
                    item.id,
                    item.Heading,
                    item.Text,
                    item.Summary,
                    item.UserID,
                    item.CreatedDateTime,
                    item.CreatedBy,
                    Status = status
                };
                articleListWithStatus.Add(article);
            }
            return articleListWithStatus;

        }

    }
}
