using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


namespace TaggedNotesWeb.DataAccess.Entities
{
	/// <summary>
	/// Link between note and tag at Data Access Layer
	/// </summary>
	public class LinkDAL
	{
		/// <summary>
		/// Link Id
		/// </summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// Note Id
		/// </summary>
		public int IdNote { get; set; }

		/// <summary>
		/// Tag Id
		/// </summary>
		public int IdTag { get; set; }
	}
}
