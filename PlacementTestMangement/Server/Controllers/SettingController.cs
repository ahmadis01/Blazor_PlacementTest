using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlacementTestMangement.Server.Interfaces;
using PlacementTestMangement.Shared.Models;

namespace PlacementTestMangement.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SettingController : ControllerBase
	{
		private readonly ISettingRepository _settingRepository;

		public SettingController(ISettingRepository settingRepository)
		{
			_settingRepository = settingRepository;
		}

		[HttpGet("level")]
		public IActionResult GetLevels()
		{
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var levels = _settingRepository.GetLevels();
			return Ok(levels);
		}
		[HttpPost("addLevel")]
        public IActionResult AddLevel(Level levelDto)
		{
			var level = _settingRepository.AddLevel(levelDto);
			return Ok(level);
		}
        [HttpDelete("deleteLevel/{id}")]
        public IActionResult DeleteLevel(int id)
        {
            var level = _settingRepository.DeleteLevel(id);
            return Ok();
        }
    }
}
