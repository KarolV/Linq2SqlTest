using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linq2SqlTestApp.Test
{
	[TestClass]
	public class TestAppTest
	{
		private TestApp testApp;

		[TestInitialize]
		public void Initialize()
		{
			testApp = new TestApp();
		}

		[TestMethod]
		public void GetGroupWithAffiliates_Test()
		{
			var @default = testApp.Groups.AsEnumerable().FirstOrDefault(x => x.GroupNumber == "BCVR0001308000");
			if (@default != null)
			{
				CommonAssert(@default.Affiliates);
				return;
			}

			Assert.Fail("@default Group is NULL");
		}

		[TestMethod]
		public void GetAffiliates_Test()
		{
			var result = testApp.Affiliates.ToList();

			try
			{
				foreach (var item in result)
					Debug.Print(item.ToString());
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			CommonAssert(result);
		}

		[TestMethod]
		public void GetGroups_Test()
		{
			var result = testApp.Groups.AsEnumerable().ToList();

			try
			{
				foreach (var item in result)
					Debug.Print(item.ToString());
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			CommonAssert(result);
		}

		private static void CommonAssert(ICollection result)
		{
			Assert.IsNotNull(result, ObjectNullMessage(result.GetType()));
			Assert.AreNotEqual(0, result.Count, CollectionCountMessage(result.GetType()));
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
