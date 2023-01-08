using Microsoft.EntityFrameworkCore;

namespace PlacementTestMangement.Shared.Models
{
    public class QuestionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mark { get; set; }
        public int Minute { get; set; }
        public ICollection<Question> Questions { get; set; }
    }

}
