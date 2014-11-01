using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linq2SqlTestApp.Test
{
	[TestClass]
	public class TestAppInitialTest
	{
		private string defaultGroupNumber;

		private TestApp testApp;

		[TestInitialize]
		public void Initialize()
		{
			testApp = new TestApp();
			defaultGroupNumber = "BCVR0001308000";
		}

		[TestMethod]
		public void GetAffiliatesChangedDataForGroup_Test()
		{
			var result = testApp.Affiliates.Where(a => a.Group.GroupNumber == defaultGroupNumber)
								.Where(af => af.CurrentSalary != af.NewSalary);

			Assert.IsNotNull(result, ObjectNullMessage(result.GetType()));

			foreach (var aff in result)
			{
				Assert.IsNotNull(aff, ObjectNullMessage(aff.GetType()));
				Console.WriteLine(aff.ToString());
			}
		}

		[TestMethod]
		public void GetAffiliatesNoChangedDataForGroup_Test()
		{
			var result = testApp.Affiliates.Where(a => a.Group.GroupNumber == defaultGroupNumber)
								.Where(af => af.CurrentSalary == af.NewSalary);

			Assert.IsNotNull(result, ObjectNullMessage(result.GetType()));

			foreach (var aff in result)
			{
				Assert.IsNotNull(aff, ObjectNullMessage(aff.GetType()));
				Console.WriteLine(aff.ToString());
			}
		}

		[TestMethod]
		public void GetAffiliates_Test()
		{
			var result = testApp.Affiliates;

			try
			{
				foreach (var item in result)
					Console.WriteLine(item.ToString());
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			CommonAssert(result);
		}

		[TestMethod]
		public void GetGroupAll_Test()
		{
			var result = testApp.Groups.AsEnumerable().ToList();

			try
			{
				foreach (var item in result)
					Console.WriteLine(item.ToString());
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			CommonAssert(result.AsQueryable());
		}

		[TestMethod]
		public void GetGroupWithAffiliates_Test()
		{
			var @default = testApp.Groups
			                      .FirstOrDefault(x => x.GroupNumber == defaultGroupNumber);

			if (@default != null)
			{
				Console.WriteLine(@default.ToString(true));
				CommonAssert(@default.Affiliates.AsQueryable());
				return;
			}

			Assert.Fail("@default Group is NULL");
		}

		private static void CommonAssert<T>(IQueryable<T> result)
		{
			Assert.IsNotNull(result, ObjectNullMessage(result.GetType()));
			Assert.AreNotEqual(0, result.Count(), CollectionCountMessage(result.GetType()));
		}

		private static string ObjectNullMessage(Type objecType)
		{
			return string.Format("Instance of {0} is NULL", objecType.FullName);
		}

		private static string CollectionCountMessage(Type resultType)
		{
			return string.Format("Collecton of {0} contains no data", resultType.FullName);
		}
	}
}
