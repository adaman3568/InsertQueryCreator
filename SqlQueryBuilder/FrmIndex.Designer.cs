
namespace SqlQueryBuilder
{
    partial class FrmIndex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIndex));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.formPanel = new System.Windows.Forms.Panel();
            this.selectorButton1 = new SqlQueryBuilderCommon.CustomControl.SelectorButton();
            this.selectorButton2 = new SqlQueryBuilderCommon.CustomControl.SelectorButton();
            this.selectorButton3 = new SqlQueryBuilderCommon.CustomControl.SelectorButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1582, 80);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 80);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.flowLayoutPanel1.Controls.Add(this.selectorButton1);
            this.flowLayoutPanel1.Controls.Add(this.selectorButton2);
            this.flowLayoutPanel1.Controls.Add(this.selectorButton3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 80);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(204, 677);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 757);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1582, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // formPanel
            // 
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formPanel.Location = new System.Drawing.Point(204, 80);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(1378, 677);
            this.formPanel.TabIndex = 3;
            // 
            // selectorButton1
            // 
            this.selectorButton1.ActiveColor = System.Drawing.Color.Maroon;
            this.selectorButton1.DefaultColor = System.Drawing.Color.WhiteSmoke;
            this.selectorButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectorButton1.Icon = null;
            this.selectorButton1.Location = new System.Drawing.Point(3, 3);
            this.selectorButton1.Name = "selectorButton1";
            this.selectorButton1.Size = new System.Drawing.Size(201, 50);
            this.selectorButton1.TabIndex = 0;
            this.selectorButton1.Click += new System.EventHandler(this.SelectorBtnClick);
            // 
            // selectorButton2
            // 
            this.selectorButton2.ActiveColor = System.Drawing.Color.Maroon;
            this.selectorButton2.DefaultColor = System.Drawing.Color.WhiteSmoke;
            this.selectorButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectorButton2.Icon = null;
            this.selectorButton2.Location = new System.Drawing.Point(3, 59);
            this.selectorButton2.Name = "selectorButton2";
            this.selectorButton2.Size = new System.Drawing.Size(201, 50);
            this.selectorButton2.TabIndex = 1;
            this.selectorButton2.Click += new System.EventHandler(this.SelectorBtnClick);
            // 
            // selectorButton3
            // 
            this.selectorButton3.ActiveColor = System.Drawing.Color.Maroon;
            this.selectorButton3.DefaultColor = System.Drawing.Color.WhiteSmoke;
            this.selectorButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectorButton3.Icon = null;
            this.selectorButton3.Location = new System.Drawing.Point(3, 115);
            this.selectorButton3.Name = "selectorButton3";
            this.selectorButton3.Size = new System.Drawing.Size(201, 50);
            this.selectorButton3.TabIndex = 2;
            this.selectorButton3.Click += new System.EventHandler(this.SelectorBtnClick);
            // 
            // FrmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 779);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmIndex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmIndex";
            this.Load += new System.EventHandler(this.FrmIndex_Load_1);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel formPanel;
        private SqlQueryBuilderCommon.CustomControl.SelectorButton selectorButton1;
        private SqlQueryBuilderCommon.CustomControl.SelectorButton selectorButton2;
        private SqlQueryBuilderCommon.CustomControl.SelectorButton selectorButton3;
    }
}