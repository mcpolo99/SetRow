using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace SoftConsConfig
{
	// Token: 0x02000003 RID: 3
	public partial class PasswordForm : Form
	{
		// Token: 0x0600000A RID: 10 RVA: 0x00003B48 File Offset: 0x00002B48
		public PasswordForm()
		{
			this.InitializeComponent();


		}

		// Token: 0x0600000D RID: 13 RVA: 0x00004150 File Offset: 0x00003150
		private void OkButton_Click(object sender, EventArgs e)
		{
			bool flag = this.textBox1.Text == "serbs" || this.textBox1.Text == "171203" || this.textBox1.Text == "221298";
			if (flag)
			{
				Form1.SetPasswordOk(true);
				base.Close();
			}
			else
			{
				Form1.SetPasswordOk(false);
				this.textBox1.Text = "";
				this.textBox1.Focus();
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000041E0 File Offset: 0x000031E0
		private void QuitButton_Click(object sender, EventArgs e)
		{
			Form1.SetPasswordOk(false);
			base.Close();
		}
	}
}
