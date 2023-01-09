using System.ComponentModel.DataAnnotations;

namespace PlacementTestMangement.Shared.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }
        public int ListeningMark { get; set; } = 0;
        public int GrammerMark { get; set; } = 0;
        public int WritingMark { get; set; } = 0;
        public int SpeakingMark { get; set; } = 0;
        public int TotalScore { get; set; } = 0;
        public int CurrentQuestion { get; set; } = 1;
        public DateTime StartTime { get; set; }= DateTime.Now;
        public TimeSpan Timer { get; set; } = new TimeSpan(0, 0, 40, 0, 0);
    }
}
