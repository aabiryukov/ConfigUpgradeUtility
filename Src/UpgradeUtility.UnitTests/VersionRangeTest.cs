using System.Diagnostics;
using Sitronics.Installer.StsUpgradeUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UpgradeUtility.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for VersionRangeTest and is intended
    ///to contain all VersionRangeTest Unit Tests
    ///</summary>
    [TestClass]
    public class VersionRangeTest
    {
    	/// <summary>
    	///Gets or sets the test context which provides
    	///information about and functionality for the current test run.
    	///</summary>
    	public TestContext TestContext { get; set; }

    	#region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for VersionRange Constructor
        ///</summary>
        [TestMethod]
        public void VersionRangeSomeTests()
        {
            {
                var target = VersionRange.Parse("1.2.3.4-2.0.0");
                Assert.IsTrue(target.VersionFrom == InstallerVersion.Parse("1.2.3.4"));
                Assert.IsTrue(target.VersionTo == InstallerVersion.Parse("2.0.0"));
            }
            {
                var target = VersionRange.Parse("-2.0.0");
                Assert.IsNull(target.VersionFrom);
                Assert.IsTrue(target.VersionTo == InstallerVersion.Parse("2.0.0"));
            }
            {
                var target = VersionRange.Parse("1 - 2.0.0.333");
                Assert.IsTrue(target.VersionFrom == InstallerVersion.Parse("1.0.0"));
                Assert.IsTrue(target.VersionTo == InstallerVersion.Parse("2.0.0.333"));
                
                Assert.IsTrue(target.Contains(InstallerVersion.Parse("1.0")));
                Assert.IsTrue(target.Contains(InstallerVersion.Parse("1.0.1")));
                Assert.IsFalse(target.Contains(InstallerVersion.Parse("2.1")));
            }

			{
				try
				{
					var target = VersionRange.Parse("2 - 1");
					Debug.WriteLine(target);
					Assert.Fail("Must be thrown exception - Invalid range");
				}
				catch (UpgradeException ex)
				{
					// Ok. Invalid version range (left is newer than right).
					Debug.WriteLine(ex.Message);
				}
			}

			{
				try
				{
					var target = VersionRange.Parse("1 - 1");
					Debug.WriteLine(target);
					Assert.Fail("Must be thrown exception - Invalid range");
				}
				catch (UpgradeException ex)
				{
					// Ok. Invalid version range (left and right must be different).
					Debug.WriteLine(ex.Message);
				}
			}
		}
    }
}
