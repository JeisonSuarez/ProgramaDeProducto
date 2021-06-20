using Sistematico1.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistematico1
{
    public partial class FrmMdi : Form
    {
        private ProductosModel productoModel;
        public FrmMdi()
        {
            InitializeComponent();
            productoModel = new ProductosModel();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductoCatalogo frmCP= new ProductoCatalogo();
            frmCP.productoModel = productoModel;
            frmCP.MdiParent = this;
            frmCP.Show();
        }

        private void productosViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductoView prdView = new ProductoView();
            prdView.productoModel = productoModel;
            prdView.MdiParent = this;
            prdView.Show();

            
        }

        private void FrmMdi_Load(object sender, EventArgs e)
        {

        }

        private void catalogoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
