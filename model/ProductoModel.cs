using System;
using Sistematico1.pojo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistematico1.model
{
    public class ProductosModel
    {
        private Producto[] productos;
        int id = 1;

        public ProductosModel()
        {

        }

        public void add(Producto empleado)
        {
            empleado.id = id;
            if (productos == null)
            {
                productos = new Producto[1];
                productos[0] = empleado;
                id++;
                return;
            }

            Producto[] temp = new Producto[productos.Length + 1];
            Array.Copy(productos, temp, productos.Length);
            temp[temp.Length - 1] = empleado;

            productos = temp;
            id++;
        }

        public void remove(int id)
        {
            /*if (index < 0)
                return;

            if (productos == null)
                return;

            if (index >= productos.Length)
                throw new IndexOutOfRangeException($"El index {index} esta fuera de rango");

            if (index == 0 && productos.Length == 1)
            {
                productos = null;
                return;
            }*/

            Producto[] temp = new Producto[productos.Length - 1];
            int index = 0;
            foreach (Producto p in productos)
            {
                if(p.id != id)
                {
                    temp[index] = p;
                    index++;
                }
            }
            productos = temp;
            /*
            if (index == 0)
            {
                Array.Copy(productos, index + 1, temp, 0, temp.Length);
                productos = temp;
                return;
            }

            if (index == productos.Length - 1)
            {
                Array.Copy(productos, 0, temp, 0, temp.Length);
                productos = temp;
                return;
            }

            Array.Copy(productos, 0, temp, 0, index);
            Array.Copy(productos, index + 1, temp, index, temp.Length - index);
            productos = temp;*/
        }

        public Producto[] getAll()
        {
            return productos;
        }

        public Producto GetProducto(int id)
        {
            foreach(Producto p in productos)
                if(p.id == id)
                    return p;
            return null;
        }

        public void Acutalizar(int id, Producto e)
        {
            foreach(Producto p in productos)
            {
                if(p.id == id)
                {
                    p.nombre = e.nombre;
                    p.existencia = e.existencia;
                    p.marca = e.marca;
                    p.modelo = e.modelo;
                    p.precio = e.precio;
                    p.descripcion = e.descripcion;
                    p.imagen = e.imagen;
                }
            }
        }

        public Producto[] GetProductos()
        {
            return productos;
        }
    }
}
