using System.Linq;

namespace Linq2SqlTestApp.DataStore.Interface
{
	/// <summary>
	/// Interface for data access layer
	/// </summary>
	public interface IDataInstanceStore<T>
	{
		/// <summary>
		/// Retrieve data entities of type <see cref="IQueryable{T}"/>
		/// </summary>
		/// <returns>Data entitiees of type <see cref="IQueryable{T}"/></returns>
		IQueryable<T> GetDataEntities();

		/// <summary>
		/// Persist the instances of <see cref="IQueryable{T}"/> to data storage
		/// </summary>
		/// <typeparam name="T"><see cref="IQueryable{T}"/> collection of being persisted</typeparam>
		/// <param name="entities"><see cref="IQueryable{T}"/> collection of being persisted</param>
		void SaveDataEntities(IQueryable<T> entities);
	}
}