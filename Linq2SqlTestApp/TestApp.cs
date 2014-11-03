using System.Configuration;
using System.Linq;

using Linq2SqlTestApp.DataStore;
using Linq2SqlTestApp.Entity.DataEntity;

namespace Linq2SqlTestApp
{
	public sealed class TestApp
	{
		private readonly BaseDataStore<Affiliate> affiliatesDataStore;
		private IQueryable<Affiliate> _affiliates;

		private readonly BaseDataStore<Group> groupDataStore;
		private IQueryable<Group> _groups;

		public TestApp()
		{
			var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

			this.groupDataStore = new GroupDataStore(connectionString);
			this.affiliatesDataStore = new AffiliateDataStore(connectionString);
		}

		public IQueryable<Affiliate> Affiliates
		{
			get { return _affiliates ?? (_affiliates = affiliatesDataStore.GetDataEntities()); }
		}

		public IQueryable<Group> Groups
		{
			get { return _groups ?? (this._groups = groupDataStore.GetDataEntities()); }
		}
	}
}