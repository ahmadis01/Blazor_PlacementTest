using PlacementTestMangement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementTestMangement.Shared.Dto
{
	public class StudentProfileAnswers
	{
		public int Id { get; set; }
		public int QuestionId { get; set; }
        public QuestionType QuestionType { get; set; }
        public int? AnswerId { get; set; }
        public string AnswerText { get; set; }
        public int StudentId { get; set; }
	}
}
