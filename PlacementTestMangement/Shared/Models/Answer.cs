namespace PlacementTestMangement.Shared.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerKey { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; } = false;
        public int QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}

