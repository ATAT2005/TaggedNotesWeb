using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaggedNotesWeb.Logic.Entities;

namespace TaggedNotesWeb.Logic.Interfaces
{
	/// <summary>
	/// Service for working with link data transfer objects
	/// </summary>
	public interface ILinkService
	{
		/// <summary>
		/// Adds link data transfer object
		/// </summary>
		/// <param name="link">Link data transfer object to add</param>
		void AddLink(LinkDTO link);

		/// <summary>
		/// Updates link data transfer object
		/// </summary>
		/// <param name="link">Link data transfer object to update</param>
		void UpdateLink(LinkDTO link);

		/// <summary>
		/// Deletes link data transfer object
		/// </summary>
		/// <param name="link">Link data transfer object to delete</param>
		void DeleteLink(LinkDTO link);

		/// <summary>
		/// Returns link data transfer object
		/// </summary>
		/// <param name="idLink">Id of the link data transfer object to get</param>
		LinkDTO GetLink(int? idLink);

		/// <summary>
		/// Returns enumerable collection of link data transfer objects
		/// </summary>
		IEnumerable<LinkDTO> GetLinks();

		/// <summary>
		/// Disposes resources
		/// </summary>
		void Dispose();
	}
}