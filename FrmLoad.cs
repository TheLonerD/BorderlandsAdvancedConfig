using System.Windows.Forms;

namespace BorderlandsAdvancedConfig
{
    public partial class FrmLoad : Form
    {
        public FrmLoad()
        {
            InitializeComponent();
        }

        public void setProgress(int percent, string text)
        {
            progressBar1.Value = percent;
            lblLoad.Text = text;

            this.Text = text;
        }
    }
}
