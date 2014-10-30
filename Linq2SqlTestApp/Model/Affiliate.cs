using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Linq2SqlTestApp.Model
{
	[Table(Name = "Affiliate")]
	public sealed class Affiliate
	{
		#region Private Fields

		private Guid _affiliateID;
		private Guid _groupID;
		private string _name;
		private decimal _currentSalary;
		private decimal _newSalary;
		private EntityRef<Group> _group;

		#endregion

		#region Public properties with DB mapping

		[Column(IsPrimaryKey = true, Storage = "_affiliateID", IsDbGenerated = true)]
		public Guid AffiliateID
		{
			get { return _affiliateID; }
			set { _affiliateID = value; }
		}

		[Column(Storage = "_groupID")]
		public Guid GroupID
		{
			get { return _groupID; }
			set { _groupID = value; }
		}

		[Column(Storage = "_name")]
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		[Column(Storage = "_currentSalary")]
		public decimal CurrentSalary
		{
			get { return _currentSalary; }
			set { _currentSalary = value; }
		}

		[Column(Storage = "_newSalary")]
		public decimal NewSalary
		{
			get { return _newSalary; }
			set { _newSalary = value; }
		}

		[Association(Storage = "_group", OtherKey = "GroupID")]
		public Group Group
		{
			get { return _group.Entity; }
			set { _group.Entity = value; }
		}

		#endregion

		#region ~constructor

		public Affiliate()
		{
			this._group = new EntityRef<Group>();
		}

		#endregion

		#region Overrides of Object

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			return string.Format("Affiliate[{0}]: Name: {1}, Current/New Salary {2} / {3}",
			                     this.AffiliateID,
			                     this.Name,
			                     this.CurrentSalary,
			                     this.NewSalary);
		}

		#endregion
	}
}