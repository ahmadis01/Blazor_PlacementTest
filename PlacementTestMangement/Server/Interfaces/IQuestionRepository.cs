using PlacementTestMangement.Server.Data;
using PlacementTestMangement.Shared.Dto;
using PlacementTestMangement.Shared.Models;

namespace PlacementTestMangement.Server.Interfaces
{
	public interface IQuestionRepository
	{
		ICollection<Question> GetQuestions();
		Task<IEnumerable<Question>> GetQuestionsByType(int id);
		Task<Question> GetQuestion(int id);
		bool AddQuestion(Question question);
		bool RemoveQuestion(int id);
		bool UpdateQuestion(Question question);
		
	}
}
