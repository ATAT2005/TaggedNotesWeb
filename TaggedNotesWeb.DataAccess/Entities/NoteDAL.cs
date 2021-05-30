using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaggedNotesWeb.DataAccess.Entities
{
	/// <summary>
	/// Note at Data Access Layer
	/// </summary>
	public class NoteDAL
	{
		/// <summary>
		/// Note Id
		/// </summary>
		[Key]
		public int Id { get; set; }


		/// <summary>
		/// Note text
		/// </summary>
		public string Text { get; set; }
	}
}
