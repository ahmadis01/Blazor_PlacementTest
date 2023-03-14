using System.ComponentModel.DataAnnotations;

namespace PlacementTestMangement.Shared.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone Number is required")]
        [MaxLength(10, ErrorMessage = "Phone Number Wrong"),MinLength(10,ErrorMessage = "Phone Number Wrong")]
        public string PhoneNumber { get; set; }
        public int ListeningMark { get; set; } = 0;
        public int GrammerMark { get; set; } = 0;
        public int WritingMark { get; set; } = 0;
        public int SpeakingMark { get; set; } = 0;
        public string? Level { get; set; }
        public int CurrentQuestion { get; set; } = 1;
        public DateTime StartTime { get; set; }= DateTime.Now;
        public TimeSpan Timer { get; set; } = new TimeSpan(0, 0, 40, 0, 0);

    }
}
