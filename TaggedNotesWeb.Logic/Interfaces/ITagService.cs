using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaggedNotesWeb.Logic.Entities;

namespace TaggedNotesWeb.Logic.Interfaces
{
	/// <summary>
	/// Service for working with tag data transfer objects
	/// </summary>
	public interface ITagService
	{
		/// <summary>
		/// Adds tag data transfer object
		/// </summary>
		/// <param name="tag">Tag data transfer object to add</param>
		void AddTag(TagDTO tag);

		/// <summary>
		/// Updates tag data transfer object
		/// </summary>
		/// <param name="tag">Tag data transfer object to update</param>
		void UpdateTag(TagDTO tag);

		/// <summary>
		/// Deletes tag data transfer object
		/// </summary>
		/// <param name="tag">Tag data transfer object to delete</param>
		void DeleteTag(TagDTO tag);

		/// <summary>
		/// Returns tag data transfer object
		/// </summary>
		/// <param name="idTag">Id of the tag data transfer object to get</param>
		TagDTO GetTag(int? idTag);

		/// <summary>
		/// Returns enumerable collection of tag data transfer objects
		/// </summary>
		IEnumerable<TagDTO> GetTags();

		/// <summary>
		/// Disposes resources
		/// </summary>
		void Dispose();
	}
}