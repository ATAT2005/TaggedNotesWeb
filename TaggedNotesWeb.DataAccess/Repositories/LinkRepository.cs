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
	internal class LinkRepository : IRepository<LinkDAL>
	{
		private Context _context;

		public LinkRepository(Context context)
		{
			_context = context;
		}

		public IEnumerable<LinkDAL> ReadAll()
		{
			return _context.Links;
		}

		public LinkDAL Read(int? idLink)
		{
			return _context.Links.Find(idLink);
		}

		public void Create(LinkDAL link)
		{
			_context.Links.Add(link);
		}

		public void Update(LinkDAL link)
		{
			_context.Links.Update(link);
		}

		public void Delete(int? idLink)
		{
			var link = _context.Links.Find(idLink);

			if (link != null)
				_context.Links.Remove(link);
		}
	}
}