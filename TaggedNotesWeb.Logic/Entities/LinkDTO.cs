using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaggedNotesWeb.Logic.Entities
{
	/// <summary>
	/// Link data transfer object at Business Logic Layer
	/// </summary>
	public class LinkDTO
	{
		/// <summary>
		/// Link data transfer object Id
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Link data transfer object note Id
		/// </summary>
		public int IdNote { get; set; }

		/// <summary>
		/// Link data transfer object tag Id
		/// </summary>
		public int IdTag { get; set; }
	}
}
