using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Services;
using Core.Domains;
using Core.Dtos;
using Core.Exceptions;

namespace API.Controllers
{
    
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private IServices service;
        public QuestionsController(IServices service)
        {
            this.service = service;
        }

        [HttpGet("/api/quiz")]
        public ActionResult<IEnumerable<QuestionDto>> LoadQuiz()
        {
            try
            {
                var questions = this.service.LoadQuestion();
                return Ok(questions);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500, "Error", null);
            }
           
        }
        [HttpGet("/api/load")]
        public ActionResult<IEnumerable<UserQuestionDto>> Load(string username)
        {
            try
            {
                var questions = this.service.LoadUserAnswer(username);
                return Ok(questions);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }catch(Exception ex)
            {
                return Problem(ex.Message, null, 500, "Error", null);
            }
       
        }

        [HttpPost("/api/save")]
        public ActionResult<IEnumerable<UserQuestionDto>> Save(List<UserQuestionDto> data)
        {
          
            try
            {
                var userQuestions = this.service.SaveUserAnswer(data);
                return Ok(userQuestions);
            }
            catch(BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }catch (Exception ex)
            {
                return Problem(ex.Message, null, 500, "Error", null);
            }

        }

        [HttpPost("/api/submit")]
        public ActionResult<SummaryDto> Submit(List<UserQuestionDto> data)
        {
            
            try
            {
                var summaryDto = this.service.SubmitUserAnswer(data);
                return Ok(summaryDto);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500, "Error", null);
            }
        }

        [HttpGet("/api/summary")]
        public ActionResult<SummaryDto> Summary(string username="")
        {
            var summaryDto = this.service.Summary(username);
            return Ok(summaryDto);
        }
    }
}
