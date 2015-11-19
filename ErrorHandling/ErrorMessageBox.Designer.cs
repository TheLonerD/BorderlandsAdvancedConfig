namespace BorderlandsAdvancedConfig.ErrorHandling
{
	partial class ErrorMessageBox
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblHeader = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.titleBack = new System.Windows.Forms.PictureBox();
			this.txtMsg = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.titleBack)).BeginInit();
			this.SuspendLayout();
			// 
			// lblHeader
			// 
			this.lblHeader.AutoSize = true;
			this.lblHeader.BackColor = System.Drawing.Color.Transparent;
			this.lblHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHeader.ForeColor = System.Drawing.Color.White;
			this.lblHeader.Location = new System.Drawing.Point(9, 7);
			this.lblHeader.Name = "lblHeader";
			this.lblHeader.Size = new System.Drawing.Size(42, 13);
			this.lblHeader.TabIndex = 13;
			this.lblHeader.Text = "[Title]";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(314, 192);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(74, 25);
			this.btnOK.TabIndex = 11;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// titleBack
			// 
			this.titleBack.Dock = System.Windows.Forms.DockStyle.Top;
			this.titleBack.Image = global::BorderlandsAdvancedConfig.Properties.Resources.title_bar;
			this.titleBack.Location = new System.Drawing.Point(0, 0);
			this.titleBack.Name = "titleBack";
			this.titleBack.Size = new System.Drawing.Size(398, 25);
			this.titleBack.TabIndex = 12;
			this.titleBack.TabStop = false;
			// 
			// txtMsg
			// 
			this.txtMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMsg.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMsg.Location = new System.Drawing.Point(12, 31);
			this.txtMsg.Name = "txtMsg";
			this.txtMsg.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.txtMsg.ShowSelectionMargin = true;
			this.txtMsg.Size = new System.Drawing.Size(374, 155);
			this.txtMsg.TabIndex = 14;
			this.txtMsg.Text = "lots of text";
			// 
			// ErrorMessageBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(398, 222);
			this.Controls.Add(this.txtMsg);
			this.Controls.Add(this.lblHeader);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.titleBack);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ErrorMessageBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ErrorMessageBox";
			((System.ComponentModel.ISupportInitialize)(this.titleBack)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblHeader;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.PictureBox titleBack;
		private System.Windows.Forms.RichTextBox txtMsg;
	}
}