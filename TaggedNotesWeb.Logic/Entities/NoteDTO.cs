using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaggedNotesWeb.Logic.Entities
{
	/// <summary>
	/// Note data transfer object at Business Logic Layer
	/// </summary>
	public class NoteDTO
	{
		/// <summary>
		/// Note data transfer object Id
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Note data transfer object text
		/// </summary>
		public string Text { get; set; }
	}
}
