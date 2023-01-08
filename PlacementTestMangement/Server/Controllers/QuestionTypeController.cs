using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlacementTestMangement.Server.Interfaces;

namespace PlacementTestMangement.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuestionTypeController : ControllerBase
	{
		private readonly IQuestionTypeRepository _questionType;

		public QuestionTypeController(IQuestionTypeRepository questionType)
		{
			_questionType = questionType;
		}
		[HttpGet]
		public IActionResult GetQuestionTypes()
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var QuestionTypes = _questionType.GetQuestionTypes();
			return Ok(QuestionTypes);
		}
		[HttpGet("{id:int}")]
		public IActionResult GetQuestionType(int id)
		{

			var QuestionType = _questionType.GetQuestionType(id);
			return Ok(QuestionType);
		}
		[HttpGet("{name}")]
		public IActionResult GetQuestionType(string name)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var QuestionType = _questionType.GetQuestionType(name);
            return Ok(QuestionType);
        }
    }
}
