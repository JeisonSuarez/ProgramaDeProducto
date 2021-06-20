using Sistematico1.model;
using Sistematico1.pojo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistematico1
{
    public partial class Productos : Form
    {
        public ProductosModel productoModel { get; set; }
        public Boolean editar = false;
        public Boolean end = false;
        private int FilaEditableIndex = -1;
        private ucProducto ucProducto;
        string imagen;

        public DataGridView dgvP;
        public Productos()
        {
            InitializeComponent();
            ucProducto = new ucProducto();
        }

        public ProductosModel getPM()
        {
            return productoModel;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                string nombre = txtNombre.Text;
                string marca = txtMarca.Text;
                string modelo = txtModelo.Text;
                string descripcion = txtDescripcion.Text;
                string imagen = txtImagen.Text;

                validarProducto(nombre, marca, modelo, descripcion, imagen, out int existencia, out decimal precio);

                Producto product = new Producto()
                {
                    nombre = nombre,
                    existencia = existencia,
                    marca = marca,
                    modelo = modelo,
                    descripcion = descripcion,
                    imagen = imagen,
                    precio = precio
                };
                if (editar && FilaEditableIndex != -1)
                {
                    productoModel.Acutalizar(FilaEditableIndex, product);
                    FilaEditableIndex = -1;
                    MessageBox.Show("Producto actualizado satisfactoriamente");
                }
                else
                {
                    productoModel.add(product);
                    MessageBox.Show("Producto agregado satisfactoriamente");
                }

                dgvP.DataSource = productoModel.getAll();
                dgvP.Refresh();
                end = true;
                this.Dispose(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            end = false;
            this.Dispose(true);
        }

        private void validarProducto(string nombre, string marca, string modelo, string descripcion, string imagen,
            out int existencia, out decimal precio)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es requerido");
            
            if (string.IsNullOrWhiteSpace(marca))
                throw new ArgumentException("La marca es requerida");

            if (string.IsNullOrWhiteSpace(modelo))
                throw new ArgumentException("El modelo es requerido");

            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripcion es requerida");

            if (!int.TryParse(txtExistencia.Text, out int existen))
                throw new ArgumentException($"El valor {txtExistencia.Text} es invalido");
            existencia = existen;

            if (!decimal.TryParse(txtPrecio.Text, out decimal pre))
                throw new ArgumentException($"El valor {txtPrecio.Text} es invalido");
            precio = pre;
        }

        public void CargarCamposProducto(int id)
        {
            Producto producto = productoModel.GetProducto(id);

            txtNombre.Text = producto.nombre;
            txtMarca.Text = producto.marca;
            txtModelo.Text = producto.modelo;
            txtDescripcion.Text = producto.descripcion;
            txtImagen.Text = producto.imagen;
            txtExistencia.Text = producto.existencia + "";
            txtPrecio.Text = producto.precio + "";
            FilaEditableIndex = id;
        }

        private void txtImagen_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnExaminarRuta_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucProducto.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    imagen = ucProducto.openFileDialog1.FileName;
                    txtImagen.Text = imagen;
                   ucProducto.pcbProductoImage.Image = Image.FromFile(imagen);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
