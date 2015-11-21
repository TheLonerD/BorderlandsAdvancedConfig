using System;
using System.Windows.Forms;

namespace BorderlandsAdvancedConfig.ErrorHandling
{
    public partial class ErrorMessageBox : Form
    {
        static ErrorMessageBox newMessageBox;

        public ErrorMessageBox(string txtMessage, string txtTitle, string header)
        {
            InitializeComponent();

            lblHeader.Parent = titleBack;

            this.lblHeader.Text = header;
            this.Text = txtTitle;
            this.txtMsg.Text = txtMessage;
        }

        public static void ShowBox(string txtMessage, string txtTitle, string header)
        {
            newMessageBox = new ErrorMessageBox(txtMessage, txtTitle, header);

            newMessageBox.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
