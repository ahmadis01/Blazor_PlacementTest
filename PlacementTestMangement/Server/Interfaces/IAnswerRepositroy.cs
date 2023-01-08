using PlacementTestMangement.Shared.Models;

namespace PlacementTestMangement.Server.Interfaces
{
	public interface IAnswerRepositroy
	{
		ICollection<Answer> GetAnswers();
		ICollection<Answer> GetQuestionAnswers(int QuestionId);
		bool AddAnswer(Answer[] answer);
		bool RemoveAnswer(int id);
		bool UpdateAnswer(Answer answer);

	}
}
