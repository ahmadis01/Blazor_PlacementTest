using Microsoft.AspNetCore.Http;
using PlacementTestMangement.Shared.Enums;
using PlacementTestMangement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementTestMangement.Shared.Dto
{
	public class QuestionDto
    {
		public string QuestionText { get; set; }
		public string Image { get; set; }
		public Category Category { get; set; }
		public int Mark { get; set; }
		public QuestionSection QuestionSection { get; set; }
		public QuestionType QuestionType { get; set; }
		public List<Answer> Answers { get; set; }
	}
}
