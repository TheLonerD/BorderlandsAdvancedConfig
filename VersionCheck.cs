///Borderlands Advanced Settings Tool
///Developed By Babak B. MDKv4
///Code Release Date: 9/12/2010

using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace BorderlandsAdvancedConfig
{
	public class VersionCheck
	{
		public VersionCheck(string updateURL)
		{
			string currentVersion = CheckVersion();

			if (!string.IsNullOrEmpty(currentVersion))
			{
				if (!Assembly.GetExecutingAssembly().GetName().Version.ToString().Equals(currentVersion))
				{
					DialogResult result = MessageBox.Show("There is a new version of Borderlands Advanced Settings available. Click yes to see more information.", "New version", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

					if (result == DialogResult.Yes)
					{
						System.Diagnostics.Process.Start(updateURL);
					}
				}
			}
		}

		public string CheckVersion()
		{
			try
			{
				// used to build entire input
				StringBuilder sb = new StringBuilder();

				// used on each read operation
				byte[] buf = new byte[8192];

				// prepare the web page we will be asking for
				HttpWebRequest request = (HttpWebRequest)
					WebRequest.Create("https://cdn.rawgit.com/TheLonerD/BorderlandsAdvancedConfig/master/CurrentVersion.txt");

				// execute the request
				HttpWebResponse response = (HttpWebResponse)
					request.GetResponse();

				// we will read data via the response stream
				Stream resStream = response.GetResponseStream();

				string tempString = null;
				int count = 0;

				do
				{
					// fill the buffer with data
					count = resStream.Read(buf, 0, buf.Length);

					// make sure we read some data
					if (count != 0)
					{
						// translate from bytes to ASCII text
						tempString = Encoding.ASCII.GetString(buf, 0, count);

						// continue building the string
						sb.Append(tempString);
					}
				}
				while (count > 0); // any more data to read?

				// print out page source
				return sb.ToString().Trim();
			}
			catch
			{
				return null;
			}
		}
	}
}
