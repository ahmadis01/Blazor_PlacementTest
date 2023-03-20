using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlacementTestMangement.Server.Interfaces;
using PlacementTestMangement.Server.Repository;

namespace PlacementTestMangement.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TextController : ControllerBase
	{
		private readonly ITextRepository _textRepository;

		public TextController(ITextRepository textRepository)
		{
			_textRepository = textRepository;
		}
        [HttpGet("{id:int}")]
        public IActionResult GetText(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var text = _textRepository.GetText(id);
            return Ok(text);
        }
    }
}
