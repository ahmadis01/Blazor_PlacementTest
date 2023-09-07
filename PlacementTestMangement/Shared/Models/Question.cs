using PlacementTestMangement.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlacementTestMangement.Shared.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int Mark { get; set; }
        public QuestionSection QuestionSection { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
