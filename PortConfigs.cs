///Borderlands Advanced Settings Tool
///Developed By Babak B. MDKv4
///Code Release Date: 9/12/2010

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BorderlandsAdvancedConfig.BaseTypes;

namespace BorderlandsAdvancedConfig
{
    public class PortConfigs
    {
        public PortConfigs() { 
        }

        public IList<PortForwardEntry> GetForwardEntries()
        {
            IList<PortForwardEntry> entries = new List<PortForwardEntry>();

            StreamReader SR;
            string S;
            SR = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "PortConfig.cfg"));
            S = SR.ReadLine();
            while (S != null)
            {
                entries.Add(ParseEntry(S));
                S = SR.ReadLine();
            }
            SR.Close();

            return entries;
        }

        private PortForwardEntry ParseEntry(string line)
        {
            string[] parameters = line.Split(',');
            return new PortForwardEntry(int.Parse(parameters[0]), (Protocol) Enum.Parse(typeof(Protocol), parameters[1]), parameters[2]);
        }
    }
}
