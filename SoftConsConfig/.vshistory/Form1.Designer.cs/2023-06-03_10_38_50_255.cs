namespace SoftConsConfig
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002134 File Offset: 0x00001134
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

		// Token: 0x06000005 RID: 5 RVA: 0x0000216C File Offset: 0x0000116C
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1009, 376);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoftConsoleConfig";
            this.ResumeLayout(false);

		}

		// Token: 0x04000006 RID: 6
		private global::System.ComponentModel.Container components = null;
	}
}
