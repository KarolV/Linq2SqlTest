using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Linq2SqlTestApp.Model
{
	[Table(Name = "Group")]
	public sealed class Group
	{
		private Guid _groupID;
		private readonly EntitySet<Affiliate> _affiliates;
		private string _name;

		public Group()
		{
			_affiliates = new EntitySet<Affiliate>();
		}

		[Column(IsPrimaryKey = true, Storage = "_groupID", IsDbGenerated = true)]
		public Guid GroupID
		{
			get { return _groupID; }
			set { _groupID = value; }
		}

		[Column(Storage = "_name", DbType = "nvarchar(50)")]
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		[Association(Storage = "_affiliates", OtherKey = "AffiliateID")]
		public EntitySet<Affiliate> Affiliates
		{
			get { return _affiliates; }
			set { _affiliates.Assign(value); }
		}
	}
}