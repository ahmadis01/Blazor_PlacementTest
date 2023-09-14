using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlacementTestMangement.Server.Interfaces;
using PlacementTestMangement.Shared.Dto;
using PlacementTestMangement.Shared.Enums;
using PlacementTestMangement.Shared.Models;

namespace PlacementTestMangement.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuestionController : ControllerBase
	{
		private readonly IQuestionRepository _questionRepository;

		public QuestionController(IQuestionRepository questionRepository)
		{
			_questionRepository = questionRepository;
		}
		[HttpGet]
		public IActionResult GetQuestions()
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			return Ok(_questionRepository.GetQuestions());
		}
		[HttpGet("{id:int}")]
		public async Task<ActionResult<Question>> GetQuestion(int id)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var question = await _questionRepository.GetQuestion(id);
			return Ok(question);
		}
		[HttpGet("getByQuestionType/{QuestionTypeId:int}")]
		public async Task<ActionResult<IEnumerable<Question>>> GetQuestionsByType(int questionType)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var questions =await _questionRepository.GetQuestionsByType((QuestionType)questionType);
			return Ok(questions);
		}
		[HttpGet("getByQuestionSection/{questionSection}")]
		public async Task<ActionResult<IEnumerable<Question>>> GetQuestionsBySection(int questionSection)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var questions = _questionRepository.GetByQuestinoSection((QuestionSection)questionSection);
			return Ok(questions);
		}
		[HttpPost]
		public IActionResult AddQuestion([FromBody]Question question){
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			_questionRepository.AddQuestion(question);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateQuestion([FromBody]Question question)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			_questionRepository.UpdateQuestion(question);
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteQuestion(int id)
		{
			_questionRepository.RemoveQuestion(id);
			return Ok();
		}
	}
}
