using System.IO;
using System.Windows.Forms;

namespace FIASUpdate
{
	internal class FIASManager
	{
		static FIASManager()
		{
			Root = Application.StartupPath;
			DBString = "Data Source=partserver2014;Initial Catalog=master;Integrated Security=True";
			DBName = "FIAS_GAR";
		}

		public static string DBName { get; private set; }
		public static string DBString { get; private set; }
		public static string Root { get; private set; }
	}
}