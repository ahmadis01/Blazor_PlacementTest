using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementTestMangement.Shared.Dto
{
    public class ReadingAnswersDto
    {
        public List<ReadingAnswerDto> Answers { get; set; }
        public int StudentId { get; set; }
        public TimeSpan Timer { get; set; }
    }
}
