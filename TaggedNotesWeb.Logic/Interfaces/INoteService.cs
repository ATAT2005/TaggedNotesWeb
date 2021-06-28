using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaggedNotesWeb.Logic.Entities;

namespace TaggedNotesWeb.Logic.Interfaces
{
	/// <summary>
	/// Service for working with note data transfer objects
	/// </summary>
	public interface INoteService
	{
		/// <summary>
		/// Adds note data transfer object
		/// </summary>
		/// <param name="note">Note data transfer object to add</param>
		void AddNote(NoteDTO note);

		/// <summary>
		/// Updates note data transfer object
		/// </summary>
		/// <param name="note">Note data transfer object to update</param>
		void UpdateNote(NoteDTO note);

		/// <summary>
		/// Deletes note data transfer object
		/// </summary>
		/// <param name="note">Note data transfer object to delete</param>
		void DeleteNote(NoteDTO note);

		/// <summary>
		/// Returns note data transfer object
		/// </summary>
		/// <param name="idNote">Id of the note data transfer object to get</param>
		NoteDTO GetNote(int? idNote);

		/// <summary>
		/// Returns enumerable collection of note data transfer objects
		/// </summary>
		IEnumerable<NoteDTO> GetNotes();

		/// <summary>
		/// Disposes resources
		/// </summary>
		void Dispose();


		/// <summary>
		/// Saves changes
		/// </summary>
		void SaveChanges();
	}
}