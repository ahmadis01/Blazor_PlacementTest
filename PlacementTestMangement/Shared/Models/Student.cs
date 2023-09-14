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
        public string Address { get;set; }
        public string SchoolOrWork { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public double PlacementTestMark { get; set; } = 0;
        public int WritingMark { get; set; } = 0;
        public int SpeakingMark { get; set; } = 0;
        public string Level { get; set; }
        public string Note { get; set; }
        public int CurrentQuestion { get; set; } = 1;
        public DateTime StartTime { get; set; }= DateTime.Now;
        public TimeSpan Timer { get; set; } = new TimeSpan(0, 0, 50, 0, 0);

    }
}
