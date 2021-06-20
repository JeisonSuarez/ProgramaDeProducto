using Sistematico1.model;
using Sistematico1.pojo;
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
    public partial class ProductoView : Form
    {
        public ProductosModel productoModel { get; set; }
        private ucProducto ucProducto;
        
        public ProductoView()
        {
            InitializeComponent();
            
        }

        private void ProductoView_Load(object sender, EventArgs e)
        {
            

            if(productoModel.getAll() == null)
            {
                return;
            }

            Producto[] productos = productoModel.getAll();
           
            for(int i = 0; i< productos.Length; i++)
            {
                ucProducto = new ucProducto();
                ucProducto.producto = productos[i];
                this.flowLayoutPanel1.Controls.Add(ucProducto);
            }
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
