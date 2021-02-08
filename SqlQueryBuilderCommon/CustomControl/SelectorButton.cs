using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlQueryBuilderCommon.CustomControl
{
    public partial class SelectorButton : UserControl
    {
        public Color DefaultColor { get; set; }

        public Color ActiveColor { get; set; }

        public Image Icon { get; set; }

        public override string Text { get; set; }

        public SelectorButton()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            label1.Text = Text;

            panel1.BackColor = DefaultColor;
            pictureBox1.Image = Icon;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public void Active()
        {
            panel1.BackColor = ActiveColor;
        }

        public void DeActive()
        {
            panel1.BackColor = DefaultColor;
        }

        
    }
}
