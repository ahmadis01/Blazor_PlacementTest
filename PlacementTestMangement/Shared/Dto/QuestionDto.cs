using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementTestMangement.Shared.Dto
{
	public class QuestionDto
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int Mark { get; set; }
        public int QuestionTypeId { get; set; }
    }
}
