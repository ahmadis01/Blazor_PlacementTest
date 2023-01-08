using Microsoft.EntityFrameworkCore;
using PlacementTestMangement.Server.Data;
using PlacementTestMangement.Server.Interfaces;
using PlacementTestMangement.Shared.Models;
using System.Xml.Linq;

namespace PlacementTestMangement.Server.Repository
{
	public class QuestionTypeRepository : IQuestionTypeRepository
	{
		private readonly DataContext _context;

		public QuestionTypeRepository(DataContext context)
		{
			_context = context;
		}
		public QuestionType GetQuestionType(int id)
		{
            return _context.QuestionTypes.Where(x => x.Id == id).FirstOrDefault();
        }

        public QuestionType GetQuestionType(string Name)
		{
			return _context.QuestionTypes.Where(x => x.Name == Name).FirstOrDefault();
		}

		public ICollection<QuestionType> GetQuestionTypes()
		{
			return _context.QuestionTypes.OrderBy(x => x.Id).ToList();
		}
	}
}
