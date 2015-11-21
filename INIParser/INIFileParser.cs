///Borderlands Advanced Settings Tool
///Developed By Babak B. MDKv4
///Code Release Date: 9/12/2010

///Based on work by ShadowLocke
///http://bytes.com/topic/net/insights/797169-reading-parsing-ini-file-c

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace BorderlandsAdvancedConfig.INIParser
{

    public class INIFileParser
    {
        private Dictionary<string, ConfigSection> configSections;
        private String iniFilePath;

        /// <summary>
        /// Opens the INI file at the given path and enumerates the values in the IniParser.
        /// </summary>
        /// <param name="iniPath">Full path to INI file.</param>
        public INIFileParser(String iniPath)
        {
            configSections = new Dictionary<string, ConfigSection>();

            TextReader iniFile = null;
            string strLine = null;
            ConfigSection currentSection = null;
            string[] keyValuePair = null;

            iniFilePath = iniPath;

            if (File.Exists(iniPath))
            {
                try
                {
                    iniFile = new StreamReader(iniPath);

                    strLine = iniFile.ReadLine();

                    while (strLine != null)
                    {
                        strLine = strLine.Trim();

                        if (!string.IsNullOrEmpty(strLine))
                        {
                            if (strLine.StartsWith("[") && strLine.EndsWith("]"))
                            {
                                currentSection = new ConfigSection(strLine.Substring(1, strLine.Length - 2), configSections.Count);
                                configSections.Add(strLine.Substring(1, strLine.Length - 2), currentSection);
                            }
                            else
                            {
                                string key = null;
                                String value = null;
                                string commentString = GetLineCommentChars(strLine);

                                keyValuePair = strLine.Split(new char[] { '=' }, 2);

                                if (string.IsNullOrEmpty(commentString))
                                {
                                    key = keyValuePair[0];
                                }
                                else
                                {
                                    key = keyValuePair[0].Substring(commentString.Length, keyValuePair[0].Length - commentString.Length);
                                }

                                if (keyValuePair.Length > 1)
                                {
                                    value = keyValuePair[1];
                                }

                                currentSection.AddEntry(key, value, commentString);
                            }

                        }

                        strLine = iniFile.ReadLine();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (iniFile != null)
                        iniFile.Close();
                }
            }
            else
                throw new FileNotFoundException("Unable to locate " + iniPath);
        }

        private string GetLineCommentChars(string line)
        {
            if (line.StartsWith("#"))
                return "#";

            if (line.StartsWith(";"))
                return ";";

            if (line.StartsWith("//"))
                return "//";

            return string.Empty;
        }

        /// <summary>
        /// Returns the value for the given section, key pair.
        /// </summary>
        /// <param name="sectionName">Section name.</param>
        /// <param name="settingName">Key name.</param>
        public ConfigEntry GetSetting(String sectionName, String settingName, int settingOrder)
        {
            ConfigSection section = configSections[sectionName];

            if (section != null)
            {
                ConfigEntry entry = section.GetEntry(settingName, settingOrder);
                return entry;
            }
            else
            {
                throw new InvalidOperationException("Section not found");
            }
        }

        public IList<ConfigEntry> GetAllSettings(String sectionName, String settingName)
        {
            ConfigSection section = configSections[sectionName];

            if (section != null)
            {
                return section.Entries.Where(x => x.key.name.Equals(settingName)).ToList();
            }
            else
            {
                throw new InvalidOperationException("Section not found");
            }
        }

        public void CopyReplaceSection(String sourceSection, String destSectionName)
        {
            ConfigSection clone = new ConfigSection(configSections[sourceSection]);

            clone.OrderInFile = configSections[destSectionName].OrderInFile;
            clone.SectionName = configSections[destSectionName].SectionName;

            configSections.Remove(destSectionName);
            configSections.Add(destSectionName, clone);
        }

        public void SetSetting(String sectionName, String settingName, int settingOrder, string value)
        {
            ConfigSection section = configSections[sectionName];

            if (section != null)
            {
                section.SetEntryValue(settingName, settingOrder, value);
            }
            else
            {
                throw new InvalidOperationException("Section not found");
            }
        }

        /// <summary>
        /// Enumerates all lines for given section.
        /// </summary>
        /// <param name="sectionName">Section to enum.</param>
        public String[] EnumSection(String sectionName)
        {
            ConfigSection section = configSections[sectionName];

            if (section == null)
            {
                throw new InvalidOperationException("Section not found");
            }

            ArrayList tmpArray = new ArrayList();

            foreach (ConfigEntry entry in section.Entries)
            {
                tmpArray.Add(entry.ToString());
            }

            return (String[])tmpArray.ToArray();
        }

        /// <summary>
        /// Adds or replaces a setting to the table to be saved.
        /// </summary>
        /// <param name="sectionName">Section to add under.</param>
        /// <param name="settingName">Key name to add.</param>
        /// <param name="settingValue">Value of key.</param>
        public void AddSetting(String sectionName, String settingName, String settingValue, string commentString)
        {
            ConfigSection section = configSections[sectionName];

            if (section == null)
            {
                section = new ConfigSection(sectionName, configSections.Count);
                configSections.Add(sectionName, section);
            }

            section.AddEntry(settingName, settingValue, commentString);
        }

        internal void AddSettings(String sectionName, IList<ConfigEntry> Entries)
        {
            ConfigSection section = configSections[sectionName];

            if (section == null)
            {
                section = new ConfigSection(sectionName, configSections.Count);
                configSections.Add(sectionName, section);
            }

            foreach (ConfigEntry entry in Entries)
            {
                section.AddEntry((ConfigEntry)entry.Clone());
            }
        }

        /// <summary>
        /// Remove a setting.
        /// </summary>
        /// <param name="sectionName">Section to add under.</param>
        /// <param name="settingName">Key name to add.</param>
        public void DeleteSetting(String sectionName, String settingName, int settingOrder)
        {
            ConfigSection section = configSections[sectionName];

            if (section == null)
            {
                throw new InvalidOperationException("Section not found");
            }

            section.RemoveEntry(settingName, settingOrder);
        }

        public void DeleteSetting(String sectionName, ConfigEntry entry)
        {
            ConfigSection section = configSections[sectionName];

            if (section != null)
            {
                section.Entries.Remove(entry);
            }
        }

        public void SetSettingComment(String sectionName, String settingName, int settingOrder, string commentString)
        {
            ConfigSection section = configSections[sectionName];

            if (section != null)
            {
                section.SetEntryComment(settingName, settingOrder, commentString);
            }
        }

        /// <summary>
        /// Save settings to new file.
        /// </summary>
        /// <param name="newFilePath">New file path.</param>
        public void SaveSettings(String newFilePath)
        {
            String tmpValue = "";
            String strToSave = "";

            IList<ConfigSection> ConfigSectionsList = new List<ConfigSection>(configSections.Values.OrderBy(x => x.OrderInFile));

            foreach (ConfigSection section in ConfigSectionsList)
            {
                strToSave += ("[" + section.SectionName + "]\r\n");

                foreach (ConfigEntry configEntry in section.Entries)
                {

                    tmpValue = configEntry.ToString();
                    strToSave += (tmpValue + "\r\n");

                }

                strToSave += "\r\n";
            }

            try
            {
                FileInfo iniFile = new FileInfo(newFilePath);

                if (iniFile.IsReadOnly)
                {
                    iniFile.IsReadOnly = false;
                }

                TextWriter tw = new StreamWriter(newFilePath);
                tw.Write(strToSave);
                tw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save settings back to ini file.
        /// </summary>
        public void SaveSettings()
        {
            SaveSettings(iniFilePath);
        }

        public void DebugSections()
        {
            foreach (KeyValuePair<string, ConfigSection> section in configSections)
            {
                Debug.WriteLine(section.Value.SectionName + " " + section.Value.OrderInFile);
            }
        }
    }
}