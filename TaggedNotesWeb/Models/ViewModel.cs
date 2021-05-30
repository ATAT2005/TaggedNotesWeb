using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaggedNotesWeb.Models
{
	/// <summary>
	/// Collections of Note, Tag and Link models
	/// </summary>
	public class ViewModel
	{
		public List<NoteModel> Notes { get; set; }

		public List<TagModel> Tags { get; set; }

		public List<LinkModel> Links { get; set; }
	}
}
