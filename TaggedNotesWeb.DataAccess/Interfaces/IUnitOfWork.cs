using System;

using TaggedNotesWeb.DataAccess.Entities;

namespace TaggedNotesWeb.DataAccess.Interfaces
{
	/// <summary>
	/// Interface for Unit of Work pattern realisation
	/// </summary>
	/// <see cref="https://www.martinfowler.com/eaaCatalog/unitOfWork.html"/>
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Repository of notes
		/// </summary>
		IRepository<NoteDAL> Notes { get; }

		/// <summary>
		/// Repository of tags
		/// </summary>
		IRepository<TagDAL> Tags { get; }

		/// <summary>
		/// Repository of links
		/// </summary>
		IRepository<LinkDAL> Links { get; }

		/// <summary>
		/// Saves data
		/// </summary>
		void Save();
	}
}