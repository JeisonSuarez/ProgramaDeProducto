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
    public partial class ProductoCatalogo : Form
    {
        public ProductosModel productoModel { get; set; }
        public ProductoCatalogo()
        {
            InitializeComponent();
            
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Productos p = new Productos();
            p.productoModel = productoModel;
            p.dgvP = dgvProductos;
            
            p.Show();
            productoModel = p.productoModel;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
                

        }
        public void Actualizar()
        {
            if (dgvProductos.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar productos a la tabla");
                return;
            }

            if (dgvProductos.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una fila de la tabla");
                return;
            }

            int index = dgvProductos.CurrentCell.RowIndex;
            string id = dgvProductos.Rows[index].Cells[0].Value.ToString();

            Productos p = new Productos();
            p.productoModel = productoModel;
            p.dgvP = dgvProductos;
            p.CargarCamposProducto(int.Parse(id));
            p.editar = true;
            p.Show();

        }
            
            

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count == 0 || dgvProductos.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Tabla sin datos o fila no seleccionada");
                return;
            }

            int index = dgvProductos.CurrentCell.RowIndex;
            string id = dgvProductos.Rows[index].Cells[0].Value.ToString();

            productoModel.remove(int.Parse(id));
            dgvProductos.DataSource = productoModel.getAll();
        }

        private void txtFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            if (dgvProductos.Rows.Count == 0)
                return;

            List<Producto> filtro = new List<Producto>();
            string Clave = txtFiltro.Text.ToUpper();
            foreach (Producto pro in productoModel.getAll())
            {
                if ((pro.id + "").ToUpper().Contains(Clave) || pro.nombre.ToUpper().Contains(Clave) || (pro.existencia + "").ToUpper().Contains(Clave)
                    || pro.marca.ToUpper().Contains(Clave) || pro.modelo.ToUpper().Contains(Clave) || (pro.precio + "").ToUpper().Contains(Clave)
                    || pro.descripcion.ToUpper().Contains(Clave) || pro.imagen.ToUpper().Contains(Clave))
                    filtro.Add(pro);

            }

            if (filtro.Count > 0)
                dgvProductos.DataSource = filtro;
            else
                dgvProductos.DataSource = productoModel.getAll();
        }

        private void DgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TxtFiltro_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProductoCatalogo_Load(object sender, EventArgs e)
        {

        }
    }
}
