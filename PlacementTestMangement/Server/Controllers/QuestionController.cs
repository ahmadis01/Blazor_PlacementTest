﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlacementTestMangement.Server.Helper;
using PlacementTestMangement.Server.Interfaces;
using PlacementTestMangement.Shared.Dto;
using PlacementTestMangement.Shared.Enums;
using PlacementTestMangement.Shared.Models;
using System.Runtime.CompilerServices;

namespace PlacementTestMangement.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuestionController : ControllerBase
	{
		private readonly IQuestionRepository _questionRepository;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public QuestionController(IQuestionRepository questionRepository, IWebHostEnvironment webHostEnvironment)
		{
			_questionRepository = questionRepository;
			_webHostEnvironment = webHostEnvironment;
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
			var questions = await _questionRepository.GetQuestionsByType((QuestionType)questionType);
			return Ok(questions);
		}
		[HttpGet("getByQuestionSection")]
		public async Task<ActionResult<IEnumerable<Question>>> GetQuestionsBySection([FromQuery] int questionSection, [FromQuery] int studentAge)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var questions = _questionRepository.GetByQuestinoSection((QuestionSection)questionSection, studentAge);
			return Ok(questions);
		}
		[HttpPost]
		public IActionResult AddQuestion([FromBody] Question question)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			_questionRepository.AddQuestion(question);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateQuestion([FromBody] Question question)
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

		[HttpPost("[action]")]
		public async Task<IActionResult> UploadImage(IFormFile file)
		{
			var name = await HelperMethods.UploadFile(file, _webHostEnvironment);
			return Ok(name);
		}
	}
}
