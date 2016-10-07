using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace UME
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmSidebar : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private int m_x=0;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private int m_y=0;

		public frmSidebar()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Transparent;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(8, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(176, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.Transparent;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button2.ForeColor = System.Drawing.Color.White;
			this.button2.Location = new System.Drawing.Point(8, 40);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(176, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "button2";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(40, 96);
			this.button3.Name = "button3";
			this.button3.TabIndex = 0;
			// 
			// frmSidebar
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(198, 266);
			this.ControlBox = false;
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSidebar";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			this.Load += new System.EventHandler(this.frmSideBar_Load);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmSidebar_MouseMove);
			this.MouseEnter += new System.EventHandler(this.frmSideBar_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.frmSideBar_MouseLeave);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmSidebar());
		}

		private void frmSideBar_Load(object sender, System.EventArgs e)
		{
			this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
			this.Height = Screen.PrimaryScreen.WorkingArea.Height;
			this.Top = 0;
		}

		private void frmSideBar_MouseEnter(object sender, System.EventArgs e)
		{
			this.Width=200;
			this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
		}

		private void frmSideBar_MouseLeave(object sender, System.EventArgs e)
		{
			if(m_x<20)
			{
				this.Width=20;
				this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
			}
			
			
		}

		private void frmSidebar_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			m_y = e.Y;
			m_x = e.X;
		}
	}
}
