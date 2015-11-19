///Borderlands Advanced Settings Tool
///Developed By Babak B. MDKv4
///Code Release Date: 9/12/2010

namespace BorderlandsAdvancedConfig.BaseTypes
{
    public class PortForwardEntry
    {
        public int portNumber { get; set; }
        public Protocol protocol { get; set; }
        public string description { get; set; }

        public PortForwardEntry(int portNumber, Protocol protocol, string description)
        {
            this.portNumber = portNumber;
            this.protocol = protocol;
            this.description = description;
        }
    }
}
