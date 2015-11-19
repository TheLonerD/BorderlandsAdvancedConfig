///Borderlands Advanced Settings Tool
///Developed By Babak B. MDKv4
///Code Release Date: 9/12/2010

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using BorderlandsAdvancedConfig.ErrorHandling;

namespace BorderlandsAdvancedConfig
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				Application.Run(new FrmConfig());
			}
			catch (Exception ex)
			{
				FileStream fs = File.Create(GetCrashLogFilePath());
				StreamWriter sw = new StreamWriter(fs);
				sw.Write(ex.Message);
				sw.Write(ex.StackTrace.ToString());
				sw.Close();
				fs.Close();

				ErrorMessageBox msgBox = new ErrorMessageBox(ex.Message + Environment.NewLine + ex.StackTrace, "Unexpected Error", "Sorry, the tool encountered an error. Error log:");
				Application.Run(msgBox);
			}
		}

		private static string GetCrashLogFilePath()
		{
			string fileNameFormatString = "crashlog{0}.log";
			string filePath = string.Empty;
			int num = 0;
			bool fileFound = true;

			while (fileFound)
			{
				filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), string.Format(fileNameFormatString, num));
				fileFound = File.Exists(filePath);
				num++;
			}

			return filePath;
		}
	}
}
