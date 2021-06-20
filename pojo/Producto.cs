using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistematico1.pojo
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int existencia { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public decimal precio { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
    }
}
