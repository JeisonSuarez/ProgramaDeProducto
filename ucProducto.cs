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
    public partial class ucProducto : UserControl
    {
        public Producto producto { get; set; }
        public ProductosModel productoModel { get; set; }
        
        public ucProducto()
        {
            InitializeComponent();
            producto = new Producto();
                                                             
        }

        private void ucEmpleado_Load(object sender, EventArgs e)
        {
            pcbProductoImage.Image = Image.FromFile(producto.imagen);
            lblId.Text += producto.id;
            lblNombre.Text += producto.nombre;
            lblNExistencia.Text += producto.existencia;
            lblMarca.Text += producto.marca;
            lblModel.Text += producto.modelo;
            lblPrecio.Text += producto.precio;
            lblDescripcion.Text += producto.descripcion;
        }

        private void pcbProductoImage_Click(object sender, EventArgs e)
        {

        }

        private void lblId_Click(object sender, EventArgs e)
        {   Productos p = new Productos();
            int id = 1;
            

            producto = productoModel.GetProducto(id);
            
            p.productoModel = productoModel;
            
            
            p.editar = true;
            p.Show();
        }
    }
}
