using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnnulableClassTest;

namespace UnitTestProject
{
	[TestClass]
	public class UnnullableTTest
	{
		[TestMethod]
		public void NullInitalizeTest()
		{
			try
			{
				Unnullable<object> b = new Unnullable<object>(null);
				Assert.Fail("null initialize successed.");
			}
			catch (NullReferenceException)
			{
				// Success
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public void UnNullInitializeTest()
		{
			try
			{
				Unnullable<int> a = new Unnullable<int>(1);
				// Success.
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public void CompareTest()
		{
			Unnullable<int> a = new Unnullable<int>(1);
			int c = a.Value;

			if (c == a)
			{
				// Success.
			}
			else
			{
				Assert.Fail("Compare failed.");
			}
		}
	}
}
