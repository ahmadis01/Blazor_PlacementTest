using PlacementTestMangement.Shared.Models;

namespace PlacementTestMangement.Server.Interfaces
{
    public interface IQuestionTypeRepository
    {
        ICollection<QuestionType> GetQuestionTypes();
        QuestionType GetQuestionType(int id);
        QuestionType GetQuestionType(string Name);
    }
}
