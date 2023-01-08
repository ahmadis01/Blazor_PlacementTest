using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlacementTestMangement.Server.Interfaces;
using PlacementTestMangement.Shared.Models;

namespace PlacementTestMangement.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AnswerController : ControllerBase
	{
		private readonly IAnswerRepositroy _answerRepositroy;

		public AnswerController(IAnswerRepositroy answerRepositroy)
		{
			_answerRepositroy = answerRepositroy;
		}
		[HttpGet]
		public IActionResult GetAnaswers()
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			else
            {
                var answers = _answerRepositroy.GetAnswers();
                return Ok(answers);
            }

		}
		[HttpGet("{QuestionId:int}")]
		public IActionResult GetQuestionAnswers(int QuestionId)
		{
			if(QuestionId == null)
				return NotFound();
			var respond = _answerRepositroy.GetQuestionAnswers(QuestionId);
			return Ok(respond);
		}
		[HttpPost] 
		public IActionResult AddAnswer(Answer[] answers)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			_answerRepositroy.AddAnswer(answers);
            return Ok();
		}
	}
}
