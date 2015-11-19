///Borderlands Advanced Settings Tool
///Developed By Babak B. MDKv4
///Code Release Date: 9/12/2010

///Based on work by ShadowLocke
///http://bytes.com/topic/net/insights/797169-reading-parsing-ini-file-c

using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderlandsAdvancedConfig.INIParser
{
    public class ConfigSection
    {
        public string SectionName { get; set; }
        public int OrderInFile { get; set; }

        public List<ConfigEntry> Entries;

		public ConfigSection(ConfigSection configSection)
		{
			SectionName = configSection.SectionName;
			OrderInFile = configSection.OrderInFile;
			Entries = new List<ConfigEntry>(configSection.Entries);
		}

        public ConfigSection(string name, int orderInFile)
        {
            this.SectionName = name;
            this.OrderInFile = orderInFile;
            Entries = new List<ConfigEntry>();
        }

        public void AddEntry(string name, string value, string commentString)
        {
            ConfigEntry newEntry = new ConfigEntry(name, 0, value, commentString);
            while (Entries.Contains(newEntry)) {
                newEntry.key.order++;
            }

            Entries.Add(newEntry);
        }

		public void AddEntry(ConfigEntry entry)
		{
			Entries.Add(entry);
		}

		public void AddEntries(IList<ConfigEntry> entries)
		{
			Entries.AddRange(entries);
		}

        public void RemoveEntry(string name, int order)
        {
            ConfigEntry tempEntry = new ConfigEntry(name, order);
            ConfigEntry entry = Entries.FirstOrDefault(x => x.key.Equals(tempEntry.key));

            if (entry != null)
            {
                Entries.Remove(entry);
            }
        }

        public void RemoveEntry(ConfigEntry entry)
        {
            Entries.Remove(entry);
        }

        public void SetEntryValue(string name, int order, string value)
        {
            ConfigEntry tempEntry = new ConfigEntry(name, order, value);
            ConfigEntry entry = Entries.FirstOrDefault(x => x.key.Equals(tempEntry.key));

            if (entry != null)
            {
                entry.value = value;
            }
            else
            {
                throw new InvalidOperationException("Entry not found");
            }
        }

        public void SetEntryComment(string name, int order, string commentString)
        {
            ConfigEntry tempEntry = new ConfigEntry(name, order);
            ConfigEntry entry = Entries.FirstOrDefault(x => x.key.Equals(tempEntry.key));

            if (entry != null)
            {
                entry.commentString = commentString;
            }
            else
            {
                throw new InvalidOperationException("Entry not found");
            }
        }

        public ConfigEntry GetEntry(string name, int order)
        {
            ConfigEntry tempEntry = new ConfigEntry(name, order);
            ConfigEntry entry = Entries.FirstOrDefault(x => x.key.Equals(tempEntry.key));

            return entry;
        }
	}
}
