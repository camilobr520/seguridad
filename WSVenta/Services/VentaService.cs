using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVenta.Models;
using WSVenta.Models.Request;

namespace WSVenta.Services
{
    public class VentaService:IVentaService
    {
        public void Add(VentaRequest model)
        {
          
                using (VentaRealContext db = new VentaRealContext())
                {
                    //este using encierra toda la transacción, o se hacen todas las inserciones con exito o ninguna
                    //sirve para mantener la integridad de la base de datos ante posibles errores
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var venta = new Ventum();
                            venta.Total = model.Conceptos.Sum(d => d.Cantidad * d.PrecioUnitario);
                            venta.Fecha = DateTime.Now;
                            venta.IdCliente = model.IdCliente;
                            db.Venta.Add(venta);
                            db.SaveChanges();

                            foreach (var model_concepto in model.Conceptos)
                            {
                                var concepto = new ConceptoVentum();
                                concepto.Cantidad = model_concepto.Cantidad;
                                concepto.IdProducto = model_concepto.IdProducto;
                                concepto.PrecioUnitario = model_concepto.PrecioUnitario;
                                concepto.Importe = model_concepto.Importe;
                                concepto.IdVenta = venta.Id; //la venta ya fue guardada y tiene su id
                                db.ConceptoVenta.Add(concepto);
                                db.SaveChanges();

                            }
                            transaction.Commit();//indica el fin de la transacción y desbloquea las tablas
                            
                        }
                        catch (Exception)
                        {
                            //si algo falla deja todo como al inicio(cancela inserciones exitosas)
                            transaction.Rollback();
                            throw new Exception("Ocurrio un error en la inserción");
                        }

                    }
                }
            
    

        }
    }
}
