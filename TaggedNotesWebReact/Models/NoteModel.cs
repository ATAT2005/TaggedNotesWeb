using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaggedNotesWeb.Models
{
	/// <summary>
	/// Note model at Presentation Layer
	/// </summary>
	public class NoteModel
	{
		/// <summary>
		/// Note model Id
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Note model text
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Note model linked tag names joined into one string
		/// </summary>
		public string LinkedTags { get; set; }

		/// <summary>
		/// String representation of note model
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Text;
		}
	}
}
