using System;
using System.Linq;

using Linq2SqlTestApp.Entity.DataEntity;

namespace Linq2SqlTestApp.DataStore
{
	public sealed class AffiliateDataStore : BaseDataStore<Affiliate>
	{
		public AffiliateDataStore(string dbConnectionString)
			: base(dbConnectionString)
		{
		}

		#region Overrides of BaseDataStore<Affiliate>

		/// <summary>
		/// Retrieve data entities of type <see cref="IQueryable{T}"/>
		/// </summary>
		/// <returns>Data entitiees of type <see cref="IQueryable{T}"/></returns>
		public override IQueryable<Affiliate> GetDataEntities()
		{
			return this.dbContext.GetTable<Affiliate>();
		}

		/// <summary>
		/// Persist the instances of <see cref="IQueryable{T}"/> to data storage
		/// </summary>
		/// <param name="entities"><see cref="IQueryable{T}"/> collection of being persisted</param>
		public override void SaveDataEntities(IQueryable<Affiliate> entities)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}