using Sitronics.Installer.StsUpgradeUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UpgradeUtility.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for VersionRangesTest and is intended
    ///to contain all VersionRangesTest Unit Tests
    ///</summary>
    [TestClass]
    public class VersionRangesTest
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
        ///A test for Contains
        ///</summary>
        [TestMethod]
        public void ContainsTest()
        {
            var target = new VersionRanges("1.0; 2.1.3-3.0.0; 4.1.1.2.3");

            Assert.IsTrue(target.Contains(InstallerVersion.Parse("1")));
            Assert.IsTrue(target.Contains(InstallerVersion.Parse("2.1.3")));
            Assert.IsTrue(target.Contains(InstallerVersion.Parse("2.2")));
            Assert.IsTrue(target.Contains(InstallerVersion.Parse("3")));
            Assert.IsTrue(target.Contains(InstallerVersion.Parse("4.1.1.2")));

            Assert.IsFalse(target.Contains(InstallerVersion.Parse("0.99")));
            Assert.IsFalse(target.Contains(InstallerVersion.Parse("3.0.0.1")));
            Assert.IsFalse(target.Contains(InstallerVersion.Parse("4.1.1.0")));
            Assert.IsFalse(target.Contains(InstallerVersion.Parse("55")));
		}
    }
}
