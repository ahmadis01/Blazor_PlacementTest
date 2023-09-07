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
		[Required]
		public string PhoneNumber { get; set; }
		[Required]
		public string HomenNumber { get; set; }
		[Required]
		public string Address { get; set; }
		public string ForEmergenciesName { get; set; } = string.Empty;
		public string ForEmergenciesNumber { get; set; } = string.Empty;
		[Required]
		public string SchoolOrWork { get; set; }
		[Required]
		public DateTime BirthDate { get; set; }
		[Required]
		public int Age { get; set; }

	}
}
