using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaggedNotesWeb.Logic.Entities
{
	/// <summary>
	/// Tag data transfer object at Business Logic Layer
	/// </summary>
	public class TagDTO
	{
		/// <summary>
		/// Tag data transfer object Id
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Tag data transfer object name
		/// </summary>
		public string Name { get; set; }
	}
}
