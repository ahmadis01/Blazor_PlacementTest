using Microsoft.EntityFrameworkCore;
using PlacementTestMangement.Server.Data;
using PlacementTestMangement.Server.Interfaces;
using PlacementTestMangement.Shared.Models;

namespace PlacementTestMangement.Server.Repository
{
	public class TextRepository : ITextRepository
	{
		private readonly DataContext _context;

		public TextRepository(DataContext context)
		{
			_context = context;
		}

		public Text AddText(Text text)
		{
			var result = _context.Texts.Add(text);
			return result.Entity;
		}

		public Text GetText(int id)
		{
			var text = _context.Texts.FirstOrDefault(t => t.Id == id);
			return text;

        }
	}
}
