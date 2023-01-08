using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PlacementTestMangement.Shared.Dto
{
	public class StudentAnswerDto
	{
		public int Id { get; set; }
		public int QuestionId { get; set; }
		[Required(AllowEmptyStrings = false , ErrorMessage = "Please Enter Answer")]
		public int AnswerId { get; set; }
		public int StudentId { get; set; }
		public TimeSpan Timer { get; set; }
	}
}
