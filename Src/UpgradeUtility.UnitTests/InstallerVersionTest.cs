using Sitronics.Installer.StsUpgradeUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UpgradeUtility.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for InstallerVersionTest and is intended
    ///to contain all InstallerVersionTest Unit Tests
    ///</summary>
    [TestClass]
    public class InstallerVersionTest
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
        ///A test for Suffix
        ///</summary>
        [TestMethod]
        [DeploymentItem("StsUpgradeUtility.exe")]
        public void SuffixTest()
        {
            {
                var target = new InstallerVersion("1.2.3034.45.2233.9");
                Assert.AreEqual(target.Suffix, "2233.9");
            }
            {
                var target = new InstallerVersion("1.2.3034.45");
                Assert.IsNull(target.Suffix);
            }
        }

        /// <summary>
        ///A test for Revision
        ///</summary>
        [TestMethod]
        [DeploymentItem("StsUpgradeUtility.exe")]
        public void RevisionTest()
        {
            var target = new InstallerVersion("1.2.3034.45");
            const int expected = 45;
            var actual = target.Revision;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Minor
        ///</summary>
        [TestMethod]
        [DeploymentItem("StsUpgradeUtility.exe")]
        public void MinorTest()
        {
            var target = new InstallerVersion("1.09.3034.45");
            const int expected = 9;
            var actual = target.Minor;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Major
        ///</summary>
        [TestMethod]
        [DeploymentItem("StsUpgradeUtility.exe")]
        public void MajorTest()
        {
            var target = new InstallerVersion("2.9.3034");
            const int expected = 2;
            var actual = target.Major;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsEmpty
        ///</summary>
        [TestMethod]
        public void IsEmptyTest()
        {
            var version = string.Empty;
            var target = new InstallerVersion(version);
            var actual = target.IsEmpty;
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for Build
        ///</summary>
        [TestMethod]
        [DeploymentItem("StsUpgradeUtility.exe")]
        public void BuildTest()
        {
            {
                var target = new InstallerVersion("1.2.3034.45");
                Assert.AreEqual(target.Build, 3034);
            }
            {
                var target = new InstallerVersion("1.2.3034.45");
                Assert.AreEqual(target.Build, 3034);
            }
            {
                var target = new InstallerVersion("1.2");
                Assert.AreEqual(target.Build, 0);
            }
            {
                var target = new InstallerVersion("01");
                Assert.AreEqual(target.Build, 0);
            }
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod]
        public void ToStringTest()
        {
            var target = new InstallerVersion("1.2.3034.45.2233.9");
            Assert.AreEqual(target.ToString(), "1.2.3034.45.2233.9");
        }

        /// <summary>
        ///A test for op_LessThanOrEqual
        ///</summary>
        [TestMethod]
        public void CompareVersionsTest()
		{
			{
				var version1 = new InstallerVersion("1.2.3");
				var version2 = new InstallerVersion("1.2.3.0");
				Assert.AreEqual(version1 <= version2, true);
			}

			{
				var version1 = new InstallerVersion("1.2.3");
				var version2 = new InstallerVersion("1.2.3.4");
				Assert.AreEqual(version1 < version2, true);
			}

			{
				var version1 = new InstallerVersion("1.2.3");
				var version2 = new InstallerVersion("1.2.3.4");
				Assert.AreEqual(version1 >= version2, false);
			}

			{
				var version1 = new InstallerVersion("1.2.3.4");
				var version2 = new InstallerVersion("5.2.3.4");
				Assert.AreEqual(version1 > version2, false);
			}

			// Equals test
			{
				var version1 = new InstallerVersion("1.2.3");
				var version2 = new InstallerVersion("1.2.3");
				Assert.IsTrue(version1 == version2);
			}
			{
				var version1 = new InstallerVersion("1");
				var version2 = new InstallerVersion("1");
				Assert.IsTrue(version1 == version2);
			}
			{
				var version1 = new InstallerVersion("1.3.4.5");
				var version2 = new InstallerVersion("1.3.4.5.EEE");
				Assert.IsTrue(version1 == version2);
			}
			{
				var version = InstallerVersion.Parse("1.0.2.4");
				Assert.IsTrue(version.Equals(version));

				Assert.IsTrue(InstallerVersion.Parse("10.0.2.4").Equals(InstallerVersion.Parse("10.0.2.4")));
			}
			{
				var version1 = new InstallerVersion("33.11.234.0");
				var version2 = new InstallerVersion("1.222");
				Assert.IsTrue(version1 > version2);
				Assert.IsTrue(version2 < version1);
			}
		}

        /// <summary>
        ///A test for GetHashCode
        ///</summary>
        [TestMethod]
        public void GetHashCodeTest()
        {
            {
                var version1 = new InstallerVersion("1.2.3");
                var version2 = new InstallerVersion("1.2.3.4");
                Assert.IsTrue(version1.GetHashCode() != version2.GetHashCode());
            }
            {
                var version1 = new InstallerVersion("1.2.3.4");
                var version2 = new InstallerVersion("1.2.3.4");
                Assert.IsTrue(version1.GetHashCode() == version2.GetHashCode());
            }
        }

        /// <summary>
        ///A test for InstallerVersion Constructor
        ///</summary>
        [TestMethod]
        public void InstallerVersionConstructorTest()
        {
            var target = new InstallerVersion("15.2.3405.45.2233.9");
            Assert.IsTrue(target.Major == 15);
            Assert.IsTrue(target.Minor == 2);
            Assert.IsTrue(target.Build == 3405);
            Assert.IsTrue(target.Revision == 45);
            Assert.IsTrue(target.Suffix == "2233.9");
        }
    }
}
