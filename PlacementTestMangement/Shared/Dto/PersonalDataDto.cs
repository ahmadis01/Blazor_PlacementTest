using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementTestMangement.Shared.Dto
{
	public class PersonalDataDto
	{
        public int Id { get; set; }
		[Required]
        public string Name { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Phone Number is required")]
		[MaxLength(10, ErrorMessage = "Phone Number Wrong"), MinLength(10, ErrorMessage = "Phone Number Wrong")]
		public string PhoneNumber { get; set; }
		public string Address { get; set; } = string.Empty;
		public string SchoolOrWork { get; set; } = string.Empty;
		[Required]
		public DateTime BirthDate { get; set; }
		[Required]
		public int Age { get; set; }

	}
}
