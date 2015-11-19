using System;
using System.Windows.Forms;

namespace BorderlandsAdvancedConfig
{
    public partial class FrmEnterIP : Form
    {
        private string _IPAddress;
        public string IPAddress
        {
            get
            {
                if (this.DialogResult == DialogResult.OK)
                {
                    return _IPAddress;
                }
                else
                {
                    throw new InvalidOperationException("Cannot request IP");
                }
            }
        }

        public FrmEnterIP( string defaultIP)
        {
            InitializeComponent();

            _IPAddress = defaultIP;
            txtIP.Text = _IPAddress;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _IPAddress = txtIP.Text;
        }
    }
}
