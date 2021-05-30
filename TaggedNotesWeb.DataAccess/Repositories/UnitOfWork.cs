using System;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


using TaggedNotesWeb.DataAccess.EF;
using TaggedNotesWeb.DataAccess.Entities;
using TaggedNotesWeb.DataAccess.Interfaces;

namespace TaggedNotesWeb.DataAccess.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private Context _context;
		private NoteRepository _noteRepository;
		private TagRepository _tagRepository;
		private LinkRepository _linkRepository;

		private bool _disposed = false;

		public UnitOfWork(IConfiguration config)
		{
			_context = new Context(config);
		}

		public IRepository<NoteDAL> Notes
		{
			get
			{
				if (_disposed)
					throw new ObjectDisposedException(nameof(UnitOfWork));

				if (_noteRepository == null)
					_noteRepository = new NoteRepository(_context);

				return _noteRepository;
			}
		}
		public IRepository<TagDAL> Tags
		{
			get
			{
				if (_disposed)
					throw new ObjectDisposedException(nameof(UnitOfWork));

				if (_tagRepository == null)
					_tagRepository = new TagRepository(_context);

				return _tagRepository;
			}
		}
		public IRepository<LinkDAL> Links
		{
			get
			{
				if (_disposed)
					throw new ObjectDisposedException(nameof(UnitOfWork));

				if (_linkRepository == null)
					_linkRepository = new LinkRepository(_context);

				return _linkRepository;
			}
		}
		public void Save()
		{
			if (_disposed)
				throw new ObjectDisposedException(nameof(UnitOfWork));

			_context.SaveChanges();
		}

		public virtual void Dispose(bool disposing)
		{
			if (!_disposed)
				if (disposing)
					_context.Dispose();

			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}