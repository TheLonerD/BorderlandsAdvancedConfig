///Borderlands Advanced Settings Tool
///Developed By Babak B. MDKv4
///Code Release Date: 9/12/2010

///Based on work by ShadowLocke
///http://bytes.com/topic/net/insights/797169-reading-parsing-ini-file-c
using System;

namespace BorderlandsAdvancedConfig.INIParser
{
    public class ConfigEntry : IEquatable<ConfigEntry>, ICloneable
    {
        public ConfigEntryKey key;
        public string value { get; set; }

        public bool isCommented
        {
            get
            {
                return !string.IsNullOrEmpty(commentString);
            }
        }

        public string commentString { get; set; }

        public ConfigEntry() { }

        public ConfigEntry(string name, int order)
        {
            key.name = name;
            key.order = order;
        }

        public ConfigEntry(string name, int order, string value)
            : this(name, order)
        {
            this.value = value;
        }

        public ConfigEntry(string name, int order, string value, string commentString)
            : this(name, order, value)
        {
            this.commentString = commentString;
        }

        public override string ToString()
        {
            if (!isCommented)
            {
                return key.name + "=" + value;
            }
            else
            {
                return commentString + key.name + "=" + value;
            }
        }

        #region IEquatable<ConfigEntry> Members

        public bool Equals(ConfigEntry other)
        {
            return (key.Equals(other.key));
        }

        #endregion


        public object Clone()
        {
            ConfigEntry clone = new ConfigEntry();
            clone.key.name = this.key.name;
            clone.key.order = this.key.order;

            clone.value = this.value;
            clone.commentString = this.commentString;

            return clone;
        }
    }
}
