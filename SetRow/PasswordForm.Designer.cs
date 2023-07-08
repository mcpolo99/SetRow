namespace SoftConsConfig
{
	// Token: 0x02000003 RID: 3
	public partial class PasswordForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00003B60 File Offset: 0x00002B60
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				bool flag = this.components != null;
				if (flag)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00003B98 File Offset: 0x00002B98
		private void InitializeComponent()
		{
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::SoftConsConfig.PasswordForm));
			this.label1 = new global::System.Windows.Forms.Label();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.OkButton = new global::System.Windows.Forms.Button();
			this.QuitButton = new global::System.Windows.Forms.Button();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.label1.Font = new global::System.Drawing.Font("Verdana", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(56, 8);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(104, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Insert password: ";
			this.textBox1.Font = new global::System.Drawing.Font("Verdana", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.textBox1.Location = new global::System.Drawing.Point(160, 8);
			this.textBox1.MaxLength = 10;
			this.textBox1.Name = "textBox1";
			this.textBox1.PasswordChar = '*';
			this.textBox1.Size = new global::System.Drawing.Size(72, 21);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			this.OkButton.BackColor = global::System.Drawing.SystemColors.Control;
			this.OkButton.Location = new global::System.Drawing.Point(72, 40);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new global::System.Drawing.Size(64, 24);
			this.OkButton.TabIndex = 2;
			this.OkButton.Text = "OK";
			this.OkButton.Click += new global::System.EventHandler(this.OkButton_Click);
			this.QuitButton.BackColor = global::System.Drawing.SystemColors.Control;
			this.QuitButton.Location = new global::System.Drawing.Point(152, 40);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new global::System.Drawing.Size(64, 24);
			this.QuitButton.TabIndex = 3;
			this.QuitButton.Text = "Quit";
			this.QuitButton.Click += new global::System.EventHandler(this.QuitButton_Click);
			this.label2.Font = new global::System.Drawing.Font("Verdana", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Red;
			this.label2.Location = new global::System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(80, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Attention!!!";
			this.label3.Font = new global::System.Drawing.Font("Verdana", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.label3.Location = new global::System.Drawing.Point(8, 24);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(272, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "This application is ONLY for Biesse technicians.";
			this.panel1.BackColor = global::System.Drawing.Color.MistyRose;
			this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.AddRange(new global::System.Windows.Forms.Control[]
			{
				this.label2,
				this.label3
			});
			this.panel1.Location = new global::System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(288, 48);
			this.panel1.TabIndex = 6;
			this.panel2.BackColor = global::System.Drawing.Color.Khaki;
			this.panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.AddRange(new global::System.Windows.Forms.Control[]
			{
				this.textBox1,
				this.label1,
				this.OkButton,
				this.QuitButton
			});
			this.panel2.Location = new global::System.Drawing.Point(8, 64);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(288, 72);
			this.panel2.TabIndex = 7;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(304, 142);
			base.Controls.AddRange(new global::System.Windows.Forms.Control[]
			{
				this.panel2,
				this.panel1
			});
			//base.Icon = (global::System.Drawing.Icon)resourceManager.GetObject("$this.Icon");
			this.MaximumSize = new global::System.Drawing.Size(312, 176);
			this.MinimumSize = new global::System.Drawing.Size(312, 176);
			base.Name = "PasswordForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Password request";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.Button OkButton;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Button QuitButton;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400000F RID: 15
		private global::System.ComponentModel.Container components = null;
	}
}
