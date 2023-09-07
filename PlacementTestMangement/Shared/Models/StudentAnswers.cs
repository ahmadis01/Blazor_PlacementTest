using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementTestMangement.Shared.Models
{
	public class StudentAnswers
	{
        public int Id { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Answer Answer { get; set; }
        public int? AnswerId { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
