using System.ComponentModel.DataAnnotations;

namespace PlacementTestMangement.Shared.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int Mark { get; set; }
        public int QuestionTypeId { get; set; }
        QuestionType? QuestionType { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
