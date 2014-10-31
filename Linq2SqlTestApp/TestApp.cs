using System.Data.Linq;
using System.Linq;

using Linq2SqlTestApp.Entity;

namespace Linq2SqlTestApp
{
	public sealed class TestApp
	{
		private readonly DataContext dbContext;
		private IQueryable<Affiliate> _affiliates;
		private IQueryable<Group> _groups;

		public TestApp()
		{
			this.dbContext =
				new DataContext(
					@"Data Source=(LocalDb)\v12.0;Initial Catalog=AZBE_NALG;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
		}

		public IQueryable<Affiliate> Affiliates
		{
			get { return _affiliates ?? (_affiliates = dbContext.GetTable<Affiliate>()); }
		}

		public IQueryable<Group> Groups
		{
			get { return _groups ?? (this._groups = dbContext.GetTable<Group>()); }
		}
	}
}