using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSVenta.Models.Request
{
    public class VentaRequest
    {
        [Required]
        [Range(1,Double.MaxValue,ErrorMessage ="El valor del idCliente debe ser mayor a cero")] //validar que el id sea mayor a 1
        [ExisteCliente(ErrorMessage ="El cliente no existe")]//esta es la clase ExisteClienteAttribute pero la palabra Attribute la toma automaticamente
        public long IdCliente { set; get; }

        [Required]
        [MinLength(1,ErrorMessage ="Deben existir conceptos")]
        public List<Concepto> Conceptos { set; get; }

        public VentaRequest()
        {
            //inicializar en el constructor la lista aunque no tenga valores paara que no se rompa si devuelve null
            this.Conceptos = new List<Concepto>();
        }

    }
    public class Concepto
    {
        public int Cantidad { set; get; }
        public decimal PrecioUnitario { set; get; }
        public decimal Importe { set; get; }
        public int IdProducto { set; get; }

    }

    #region ValidacionesPersonalizadas

    public class ExisteClienteAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            long idCliente = (long)value;
            using (var db=new Models.VentaRealContext())
            {
                if (db.Clientes.Find(idCliente) == null) return false;
            
            }
                return true;
        }
    }


    #endregion
}
