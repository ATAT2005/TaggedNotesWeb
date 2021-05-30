using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaggedNotesWeb.DataAccess.Interfaces
{
	/// <summary>
	/// Interface for CRUD operations
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRepository<T> where T : class
	{
		/// <summary>
		/// Returns all repository items one by one
		/// </summary>
		/// <returns>IEnumerable collection of items</returns>
		IEnumerable<T> ReadAll();
		
		/// <summary>
		/// Returns a specific item by its id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		T Read(int? id);
		
		/// <summary>
		/// Adds a new item to repository
		/// </summary>
		/// <param name="item">Item to add</param>
		void Create(T item);
		
		/// <summary>
		/// Updates an item in repository
		/// </summary>
		/// <param name="item">Item to update</param>
		void Update(T item);
		
		/// <summary>
		/// Deletes a specific item from repository
		/// </summary>
		/// <param name="id">Id of the item to delete</param>
		void Delete(int? id);
	}
}