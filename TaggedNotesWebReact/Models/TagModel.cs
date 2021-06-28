using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaggedNotesWeb.Models
{
	/// <summary>
	/// Tag model at Presentation Layer
	/// </summary>
	public class TagModel
	{
		/// <summary>
		/// Tag model Id
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Tag model name
		/// </summary>
		public string Name { get; set; }
	}
}
