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
	internal class NoteRepository : IRepository<NoteDAL>
	{
		private Context _context;

		public NoteRepository(Context context)
		{
			_context = context;
		}

		public IEnumerable<NoteDAL> ReadAll()
		{
			return _context.Notes;
		}

		public NoteDAL Read(int? idNote)
		{
			return _context.Notes.Find(idNote);
		}

		public void Create(NoteDAL note)
		{
			_context.Notes.Add(note);
			_context.Entry(note).State = EntityState.Added;
		}

		public void Update(NoteDAL note)
		{
			var result = _context.Notes.SingleOrDefault(n => n.Id == note.Id);

			if (result != null)
			{
				result.Text = note.Text;
				_context.Notes.Update(result);
			}
		}

		public void Delete(int? idNote)
		{
			var note = _context.Notes.Find(idNote);

			if (note != null)
			{
				_context.Notes.Remove(note);
				_context.Entry(note).State = EntityState.Deleted;
			}
		}
	}
}