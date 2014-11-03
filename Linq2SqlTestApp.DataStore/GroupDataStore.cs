using System;
using System.Data.Linq;
using System.Linq;

using Linq2SqlTestApp.Entity.DataEntity;

namespace Linq2SqlTestApp.DataStore
{
	public sealed class GroupDataStore : BaseDataStore<Group>
	{
		public GroupDataStore(string dbConnectionString)
			: base(dbConnectionString)
		{
		}

		#region Overrides of BaseDataStore<Group>

		/// <summary>
		/// Retrieve data entities of type <see cref="IQueryable{T}"/>
		/// </summary>
		/// <returns>Data entitiees of type <see cref="IQueryable{T}"/></returns>
		public override IQueryable<Group> GetDataEntities()
		{
			var loadOptions = new DataLoadOptions();
			loadOptions.LoadWith(GetExpressionForTableLoad(obj => obj.Affiliates));
			this.dbContext.LoadOptions = loadOptions;

			return this.dbContext.GetTable<Group>();
		}

		/// <summary>
		/// Persist the instances of <see cref="IQueryable{T}"/> to data storage
		/// </summary>
		/// <typeparam name="T"><see cref="IQueryable{T}"/> collection of being persisted</typeparam>
		/// <param name="entities"><see cref="IQueryable{T}"/> collection of being persisted</param>
		public override void SaveDataEntities(IQueryable<Group> entities)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}