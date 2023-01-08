using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlacementTestMangement.Server.Data;
using PlacementTestMangement.Server.Interfaces;
using PlacementTestMangement.Shared.Dto;
using PlacementTestMangement.Shared.Models;

namespace PlacementTestMangement.Server.Repository
{
	public class QuestionRepository : IQuestionRepository
	{
		private readonly DataContext _context;
		public QuestionRepository(DataContext context)
		{
			_context = context;
		}
		public bool AddQuestion(Question question)
		{

            _context.Add(question);
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
		public async Task<Question> GetQuestion(int id)
		{
			var question =  await _context.Questions.Where(x => x.Id == id).FirstOrDefaultAsync();
			question.Answers = _context.Answers.Where(a => a.QuestionId == id).ToList();
            return question;
		}
		public ICollection<Question> GetQuestions()
		{
			return _context.Questions.OrderBy(x => x.Id).Include(c=> c.Answers).ToList();
		}
		public async Task<IEnumerable<Question>> GetQuestionsByType(int id)
		{
			return await _context.Questions.Where(x => x.QuestionTypeId == id).Include(a=>a.Answers).ToListAsync();
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
