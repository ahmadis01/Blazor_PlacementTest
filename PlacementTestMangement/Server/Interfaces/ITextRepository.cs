using PlacementTestMangement.Shared.Models;

namespace PlacementTestMangement.Server.Interfaces
{
	public interface ITextRepository
	{
		Text GetText(int id);
		Text AddText(Text text);
	}
}
