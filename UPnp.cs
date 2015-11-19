///Borderlands Advanced Settings Tool
///Developed By Babak B. MDKv4
///Code Release Date: 9/12/2010

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using BorderlandsAdvancedConfig.BaseTypes;
using NATUPNPLib;

namespace BorderlandsAdvancedConfig
{
    public class UPnp
    {
        private FrmConfig mainWindow;
        private UPnPNATClass upnpnat;
		private PortConfigs PortConfigs = new PortConfigs();
        IStaticPortMappingCollection staticMappings;


		public void SetupUpnp()
		{
			if (!ShowUpnpNotice())
			{
				log("> Upnp: Setup aborted.");
				return;
			}

			log("> UPnp: Discovering UPNP devices...");
			log("> UPnp: Done Discovery");

			IList<PortForwardEntry> forwardPorts = PortConfigs.GetForwardEntries();

			string lanIP = GetLanIP();

			if (string.IsNullOrEmpty(lanIP))
			{
				log("> UPnp: Could not detect your lan network card.");
				return;
			}

			if (!lanIP.Substring(0, 3).Equals("192"))
			{
				DialogResult result = MessageBox.Show(string.Format(LocalizedStrings.UPnpWierdLanIP, lanIP), "Unrecongnized Lan IP", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

				if (result == DialogResult.Yes)
				{
					//Continue
				}
				else if (result == DialogResult.No)
				{
					FrmEnterIP enterIP = new FrmEnterIP(lanIP);
					enterIP.ShowDialog();

					if (enterIP.DialogResult == DialogResult.OK)
					{
						lanIP = enterIP.IPAddress;
					}
					else
					{
						log("> UPnp: Setup aborted");
						return;
					}

				}
				else if (result == DialogResult.Cancel)
				{
					log("> UPnp: Setup aborted");
					return;
				}
			}

			if (!RefreshMappings())
			{
				MessageBox.Show(LocalizedStrings.UPnpNull, "Could not get mappings", MessageBoxButtons.OK, MessageBoxIcon.Error);
				log("> Upnp: Failed to obtain mappings");
				return;
			}

			log("> UPnp: Remove Previous Mappings and add new ones");

			foreach (PortForwardEntry entry in forwardPorts)
			{
				RemoveMapping(entry.portNumber, entry.protocol);
				AddMapping(entry.portNumber, entry.protocol, lanIP, entry.description);
			}

			log("> UPnp: Done. Current Mappings:");
			GetStaticMappings();
			log(">>> All Done. Let's hope it works.");
		}

		private void log(string p)
		{
			throw new NotImplementedException();
		}


		private bool ShowUpnpNotice()
		{
			DialogResult result = MessageBox.Show(LocalizedStrings.UPnpNotice, "UPnp forward notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);

			return (result == DialogResult.Yes);
		}


        public UPnp(FrmConfig frmConfig)
        {
            mainWindow = frmConfig;
        }

        public bool RefreshMappings()
        {
            upnpnat = new UPnPNATClass();
            staticMappings = upnpnat.StaticPortMappingCollection;

            return (staticMappings != null);
        }

        public void GetStaticMappings()
        {
            mainWindow.log(">> Static Mappings");
            foreach (IStaticPortMapping portMapping in staticMappings)
            {
                mainWindow.log(GetMappingString(portMapping));
            }
        }

        public void AddMapping(int portNum, Protocol protocol, string lanIP, string description)
        {
            staticMappings.Add(portNum, protocol.ToString(), portNum, lanIP, true, description);
        }

        public void RemoveMapping(int portNum, Protocol protocol)
        {
            mainWindow.log("> UPnp: Removing mapping: " + portNum + " " + protocol.ToString());
            try
            {
                staticMappings.Remove(portNum, protocol.ToString());
            }
            catch
            {
                return;
            }
        }

        private string GetMappingString(IStaticPortMapping portMapping)
        {
            string res = "> Mapping:" + Environment.NewLine;
            res += " > Description: " + portMapping.Description + Environment.NewLine;
            res += " > " + portMapping.ExternalIPAddress + ":" + portMapping.ExternalPort + " => " + portMapping.InternalClient + ":" + portMapping.InternalPort + Environment.NewLine;
            res += " > Protocol: " + portMapping.Protocol + Environment.NewLine;

            return res;
        }

        internal string GetLanIP()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            if (nics == null || nics.Length < 1)
            {
                return string.Empty;
            }

            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();

                if (adapter.OperationalStatus == OperationalStatus.Up && adapter.NetworkInterfaceType.ToString() != "Loopback" && adapter.NetworkInterfaceType.ToString() != "Tunnel")
                {
                    foreach (IPAddressInformation uniCast in properties.UnicastAddresses)
                    {
                        // Ignore loop-back addresses & IPv6
                        if (!IPAddress.IsLoopback(uniCast.Address) && uniCast.Address.AddressFamily != AddressFamily.InterNetworkV6)
                        {
                            return uniCast.Address.ToString();
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}
