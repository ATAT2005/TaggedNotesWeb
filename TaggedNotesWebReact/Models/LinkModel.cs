using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaggedNotesWeb.Models
{
	/// <summary>
	/// Link model at Presentation Layer
	/// </summary>
	public class LinkModel
	{
		/// <summary>
		/// Link model Id
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Link model note Id
		/// </summary>
		public int IdNote { get; set; }

		/// <summary>
		/// Link model tag Id
		/// </summary>
		public int IdTag { get; set; }
	}
}
