using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Linq2SqlTestApp.Entity
{
	[Table(Name = "Group")]
	public sealed class Group
	{
		private int _groupID;
		private readonly EntitySet<Affiliate> _affiliates;
		private string _groupNumber;
		private string _name;

		public Group()
		{
			_affiliates = new EntitySet<Affiliate>();
		}

		[Column(Name = "Identifier", IsPrimaryKey = true, Storage = "_groupID", IsDbGenerated = true)]
		public int GroupID
		{
			get { return _groupID; }
			set { _groupID = value; }
		}

		[Column(Name = "GroupNumber", Storage = "_groupNumber")]
		public string GroupNumber
		{
			get { return _groupNumber; }
			set { _groupNumber = value; }
		}

		[Column(Storage = "_name", DbType = "nvarchar(50)")]
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		[Association(Storage = "_affiliates", OtherKey = "GroupID")]
		public EntitySet<Affiliate> Affiliates
		{
			get { return _affiliates; }
			set { _affiliates.Assign(value); }
		}

		#region Overrides of Object + extended methods of overrides

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			return this.ToString<Group>(null);
		}

		public string ToString(bool deep)
		{
			return deep
				? this.ToString<IQueryable<Affiliate>>(FormatTail)
				: this.ToString<Group>(FormatTail);
		}

		private string ToString<T>(Func<T, string> method)
		{
			return string.Format("Group[{0}]: GroupNumber: '{1}', Name: '{2}'{3}",
			                     this.GroupID,
			                     this.GroupNumber,
			                     this.Name,
			                     this.Affiliates == null
				                     ? string.Empty
				                     : method == null
					                     ? string.Empty
					                     : method((T) this.Affiliates.AsQueryable()));
		}

		private static string FormatTail(Group group)
		{
			return string.Format(", Affiliates.Count: {0}", group.Affiliates.Count);
		}

		private static string FormatTail<T>(IQueryable<T> collection)
		{
			return collection.Aggregate(new StringBuilder(),
			                            (sb, item) => sb.AppendLine(string.Format("\t- {0}", item)))
			                 .Insert(0, "\n")
			                 .ToString();
		}

		#endregion
	}
}