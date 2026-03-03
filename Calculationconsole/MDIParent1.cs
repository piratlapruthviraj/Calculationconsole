using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculationconsole
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new supplier();
            childForm.MdiParent = this;
            childForm.Text = "Supplier Window";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            Form childForm = new Products();
            childForm.MdiParent = this;
            childForm.Text = "Product window";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }


        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Orders window";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }
    }
}
