using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Sitronics.Installer.StsUpgradeUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UpgradeUtility.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for StageUpgradeTest and is intended
    ///to contain all StageUpgradeTest Unit Tests
    ///</summary>
	[TestClass]
	public class StageUpgradeTest
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

		private static void RunUpgrade(string testXmlFile, string testNewXmlFile, bool expectedSuccessResult = true)
		{
			var fileList = new List<TargetFileInfo>
				               	{
				               		new TargetFileInfo(
				               			testXmlFile,
				               			testXmlFile + ".upgrade"
				               			)
				               	};

			var parameters = new RunParameters("TestProduct", new InstallerVersion("1.10.1"), new InstallerVersion("1.2.0"),
				fileList);
            parameters.DumpToLog();

			{
				var stageBackup = new StageBackup(parameters);
				var retCode = stageBackup.Run();
				Assert.AreEqual(0, retCode);
			}

			File.Copy(testNewXmlFile, testXmlFile, true);

			{
				var definedMsiProperties = new Dictionary<string, string>
				                           	{
				                           		{"ComputerName", "msk-app-0839"}
				                           	};
				var stageUpgrade = new StageUpgrade(parameters, definedMsiProperties);
				var retCode = stageUpgrade.Run();

				if (expectedSuccessResult)
				{
					Assert.AreEqual(0, retCode);
				}
				else
				{
					Assert.AreNotEqual(0, retCode);
				}
			}
		}

		private static void WarningUpgrade()
		{
			// WARNING: Target file not found in backup.
			var testXmlFile = Path.Combine(Directory.GetCurrentDirectory(), @"Web.config");
			var fileList = new List<TargetFileInfo>
				               	{
				               		new TargetFileInfo(
				               			testXmlFile,
				               			testXmlFile + ".upgrade"
				               			)
				               	};

			var parameters = new RunParameters("TestProduct", new InstallerVersion("1.10.1"), new InstallerVersion(String.Empty),
				fileList);
            parameters.DumpToLog();

			{
				var stageUpgrade = new StageUpgrade(parameters, null);
				var retCode = stageUpgrade.Run();
				Assert.AreEqual(0, retCode);
			}
			
			// WARNING: Target file not found: NotExist.config
			testXmlFile = @"NotExist.config";
			var upgradeFile = Path.Combine(Directory.GetCurrentDirectory(), @"Config1.xml.upgrade");
			fileList = new List<TargetFileInfo>
				               	{
				               		new TargetFileInfo(
				               			testXmlFile,
				               			upgradeFile
				               			)
				               	};

			parameters = new RunParameters("TestProduct", new InstallerVersion("1.10.1"), new InstallerVersion("1.0.1"), fileList);
			
			{
				var stageUpgrade = new StageUpgrade(parameters, null);
				var retCode = stageUpgrade.Run();
				Assert.AreEqual(0, retCode);
			}

			// WARNING: Upgrade file info not found.
			fileList = new List<TargetFileInfo>
				               	{
				               		new TargetFileInfo(
				               			testXmlFile,
				               			testXmlFile + ".upgrade"
				               			)
				               	};

			parameters = new RunParameters("TestProduct", new InstallerVersion("1.10.1"), new InstallerVersion("1.0.1"), fileList);

			{
				var stageUpgrade = new StageUpgrade(parameters, null);
				var retCode = stageUpgrade.Run();
				Assert.AreEqual(0, retCode);
			}
		}

		/// <summary>
		///A test for Run
		///</summary>
		[TestMethod]
		[TestCategory("Regress")]
		[DeploymentItem(@"TestData\InstallDir\")]
		public void UpgradeTest()
		{
			var testXmlFile = Path.Combine(Directory.GetCurrentDirectory(), @"Web.config");
			var testNewXmlFile = Path.Combine(Directory.GetCurrentDirectory(), @"New.Web.config");

			RunUpgrade(testXmlFile, testNewXmlFile);
		}

		/// <summary>
		///A test for Run
		///</summary>
		[TestMethod]
		[TestCategory("Regress")]
//		[DeploymentItem(@"TestData\RegressData\TestsForSuccess\Config1.xml")]
		[DeploymentItem(@"TestData\RegressData\")]
		public void RegressUpgradeTest()
		{
			System.Diagnostics.Trace.WriteLine(UpgradeUtilityInformation.Version);
			Assert.IsNotNull(UpgradeUtilityInformation.Version);
			Assert.IsTrue(UpgradeUtilityInformation.Version.Major >= 1);

			ProcessTestsOnModelData(Path.Combine(Directory.GetCurrentDirectory(), "TestsForSuccess"), true);
			ProcessTestsOnModelData(Path.Combine(Directory.GetCurrentDirectory(), "TestsForFail"), false);

			WarningUpgrade();
		}

		private void ProcessTestsOnModelData(string testDataDirectory, bool expectedSuccessResult)
		{
			var dir = new DirectoryInfo(testDataDirectory);
			var files = dir.GetFiles("config*.xml");
			foreach (var file in files)
			{
				System.Diagnostics.Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Testing for {0} by config: {1}", expectedSuccessResult ? "Success" : "Fail", file));

				var testXmlFile = Path.Combine(testDataDirectory, file.Name);
				var testNewXmlFile = Path.Combine(testDataDirectory, file.Name + ".new");

				RunUpgrade(testXmlFile, testNewXmlFile, expectedSuccessResult);

				if (expectedSuccessResult)
				{
					var etalonXmlFile = testXmlFile + ".etalon";
					var retCode = Compare(testXmlFile, etalonXmlFile);
					Assert.AreEqual(true, retCode, String.Format(CultureInfo.InvariantCulture,
					                                             "Updated configuration file {0} does not match the etalon {1}",
					                                             testXmlFile, etalonXmlFile));
				}
			}
		}


		/// <summary>
		/// This method compares the modified file with a etalon file
		/// </summary>
		/// <param name="sourceFile">modified file</param>
		/// <param name="etalonFile">etalon file</param>
		/// <returns></returns>
		public bool Compare(string sourceFile, string etalonFile)
		{
			var fs1 = new FileStream(sourceFile, FileMode.Open);
			var fs2 = new FileStream(etalonFile, FileMode.Open);

			if (fs1.Length != fs2.Length)
			{
				fs1.Close();
				fs2.Close();
				return false;
			}
			var filebyte1 = fs1.ReadByte();
			var filebyte2 = fs2.ReadByte();
			while (filebyte1 == filebyte2 && filebyte1 != -1)
			{
				filebyte1 = fs1.ReadByte();
				filebyte2 = fs2.ReadByte();
			}
			fs1.Close();
			fs2.Close();

			return ((filebyte1 - filebyte2) == 0);
		}
	}
}
