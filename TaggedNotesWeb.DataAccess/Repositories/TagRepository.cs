using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TaggedNotesWeb.DataAccess.EF;
using TaggedNotesWeb.DataAccess.Entities;
using TaggedNotesWeb.DataAccess.Interfaces;

namespace TaggedNotesWeb.DataAccess.Repositories
{
	internal class TagRepository : IRepository<TagDAL>
	{
		private Context _context;

		public TagRepository(Context context)
		{
			_context = context;
		}

		public IEnumerable<TagDAL> ReadAll()
		{
			return _context.Tags;
		}

		public TagDAL Read(int? idTag)
		{
			return _context.Tags.Find(idTag);
		}

		public void Create(TagDAL tag)
		{
			_context.Tags.Add(tag);
			_context.Entry(tag).State = EntityState.Added;
		}

		public void Update(TagDAL tag)
		{
			_context.Tags.Update(tag);
		}

		public void Delete(int? idTag)
		{
			var link = _context.Tags.Find(idTag);

			if (link != null)
				_context.Tags.Remove(link);
		}
	}
}