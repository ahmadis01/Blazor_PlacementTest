using Microsoft.EntityFrameworkCore;
using PlacementTestMangement.Server.Data;
using PlacementTestMangement.Server.Interfaces;
using PlacementTestMangement.Shared.Models;

namespace PlacementTestMangement.Server.Repository
{
	public class SettingRepository : ISettingRepository
	{
		private readonly DataContext _context;

		public SettingRepository(DataContext context)
		{
			_context = context;
		}

		public Level AddLevel(Level levelDto)
		{
			var level =  _context.Levels.Add(levelDto);
			 _context.SaveChanges();
			return level.Entity;
		}

		public ICollection<Level> GetLevels()
		{
			return  _context.Levels.OrderBy(o => o.Id).ToList();
		}
		public bool DeleteLevel(int id)
		{
			var level = _context.Levels.FirstOrDefault(l => l.Id == id);
			_context.Levels.Remove(level);
			_context.SaveChanges();
			return true;
		}
	}
}
