using PlacementTestMangement.Server.Data;
using PlacementTestMangement.Server.Interfaces;
using PlacementTestMangement.Shared.Models;

namespace PlacementTestMangement.Server.Repository
{
	public class AnswerRepository : IAnswerRepositroy
	{
		private readonly DataContext _context;

		public AnswerRepository(DataContext context)
		{
			_context = context;
		}
		public ICollection<Answer> GetAnswers()
		{
			return _context.Answers.OrderBy(x => x.Id).ToList();
		}
		public bool AddAnswer(Answer[] answer)
		{
			_context.Add(answer[0].AnswerKey="A");
            _context.Add(answer[1].AnswerKey = "B");
            _context.Add(answer[2].AnswerKey = "C");
            _context.Add(answer[3].AnswerKey = "D");
            var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public ICollection<Answer> GetQuestionAnswers(int QuestionId)
		{
			return _context.Answers.Where(a => a.QuestionId == QuestionId).ToList();
		}

		public bool RemoveAnswer(int id)
		{
			_context.Remove(id);
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool UpdateAnswer(Answer answer)
		{
            _context.Update(answer);
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
	}
}
