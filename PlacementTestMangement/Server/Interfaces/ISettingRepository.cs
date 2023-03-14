using PlacementTestMangement.Shared.Models;

namespace PlacementTestMangement.Server.Interfaces
{
	public interface ISettingRepository
	{
		ICollection<Level> GetLevels();
		Level AddLevel(Level level);
		bool DeleteLevel(int id);
	}
}
