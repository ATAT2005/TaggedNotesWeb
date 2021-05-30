using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaggedNotesWeb.DataAccess.Entities
{
	/// <summary>
	/// Tag at Data Access Layer
	/// </summary>
	public class TagDAL
	{
		/// <summary>
		/// Tag Id
		/// </summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// Tag name
		/// </summary>
		public string Name { get; set; }
	}
}
