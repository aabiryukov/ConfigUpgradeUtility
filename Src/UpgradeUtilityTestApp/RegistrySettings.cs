using Microsoft.Win32;

namespace UpgradeUtilityTestApp
{
	internal static class RegistrySettings
	{
		private const string RootPath = @"Software\SITRONICS Telecom Solutions\UpgradeUtilityTestApp";


		private static RegistryKey RootKey
		{
			get{ return Registry.CurrentUser; }
			
		}

		public static RegistryKey CreateSubKey(string subKey)
		{
			return RootKey.CreateSubKey(RootPath + '\\' + subKey);
		}

		public static RegistryKey OpenSubKey(string subKey)
		{
			return RootKey.OpenSubKey(RootPath + '\\' + subKey);
		}
/*
		public RegistryKey OpenSubKey(string SubKey, bool writable)
		{
			return RootKey.OpenSubKey(RootPath + '\\' + SubKey, writable);
		}
*/

		public static void SaveValue(string name, string value)
		{
			using(var regKey = RootKey.CreateSubKey(RootPath))
			{
				if (regKey != null)
				{
					regKey.SetValue(name, value, RegistryValueKind.String);
				}
			}
		}

		public static string ReadValue(string name)
		{
			using (var regKey = RootKey.OpenSubKey(RootPath))
			{
				if (regKey != null)
				{
					var value = regKey.GetValue(name);
					if (value != null)
						return (string) value;
				}
			}

			return null;
		}

        public static bool IsFirstRun()
        {
            using (var regKey = RootKey.OpenSubKey(RootPath))
            {
                return regKey == null;
            }
        }
    }
}
