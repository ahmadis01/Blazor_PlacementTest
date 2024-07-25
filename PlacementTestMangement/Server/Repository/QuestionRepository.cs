using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlacementTestMangement.Server.Data;
using PlacementTestMangement.Server.Helper;
using PlacementTestMangement.Server.Interfaces;
using PlacementTestMangement.Shared.Dto;
using PlacementTestMangement.Shared.Enums;
using PlacementTestMangement.Shared.Models;

namespace PlacementTestMangement.Server.Repository
{
	public class QuestionRepository : IQuestionRepository
	{
		private readonly DataContext _context;
		private readonly IWebHostEnvironment _hostingEnvironment;
		public QuestionRepository(DataContext context, IWebHostEnvironment hostingEnvironment)
		{
			_context = context;
			_hostingEnvironment = hostingEnvironment;
		}
		public async Task<bool> AddQuestion(Question question)
		{
			var entity = new Question();

			_context.Add(question);
			var saved = await _context.SaveChangesAsync();
			return saved > 0 ? true : false;
		}
		public async Task<Question> GetQuestion(int id)
		{
			var question = await _context.Questions.Where(x => x.Id == id).FirstOrDefaultAsync();
			question.Answers = _context.Answers.Where(a => a.QuestionId == id).ToList();
			return question;
		}
		public ICollection<Question> GetQuestions()
		{
			return _context.Questions.OrderBy(x => x.Id).Include(c => c.Answers).ToList();
		}
		public async Task<IEnumerable<Question>> GetQuestionsByType([FromQuery] QuestionType questionType)
		{
			return await _context.Questions.Where(x => x.QuestionType == questionType).Include(a => a.Answers).ToListAsync();
		}

		public IEnumerable<Question> GetByQuestinoSection(QuestionSection questionSection, int studentAge)
		{
			Category category;
			if (6 < studentAge && studentAge <= 9)
			{
				category = Category.Kids;
			}
			else if (10 < studentAge && studentAge <= 15)
			{
				category = Category.Teens;
			}
			else
			{
				category = Category.Adults;
			}
			var questions = _context.Questions.Where(x => x.QuestionSection == (QuestionSection)questionSection && category == x.Category).Include(a => a.Answers).ToList();
			return questions;
		}

		public bool RemoveQuestion(int id)
		{
			var question = _context.Questions.FirstOrDefault(x => x.Id == id);
			_context.Remove(question);
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
		public bool UpdateQuestion(Question question)
		{
			_context.Update(question);
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
	}
}
