using PruebaCamiloBautista.Datos;
using PruebaCamiloBautista.Dominio.Modelos.Respuesta;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PruebaCamiloBautista.Dominio.Modelos.Request;
using PruebaCamiloBautista.Dominio.Interface;

namespace PruebaCamiloBautista.Dominio.Service
{
  public class PasajerosService:IPasajerosService
    {
        public Reply GetPasajeros(VuelosRequest model)
        {
            using (DigitalWareContext db = new DigitalWareContext())
            {
                Reply oReply = new Reply();
                try
                {


                    List<Pasajero> lst = (from d in db.Pasajeros
                                          
                                       select new Pasajero
                                       {
                                           Id = d.Id,
                                           Nombres=d.Nombres,
                                           Apellidos=d.Apellidos,
                                           IdSexo=d.IdSexo,
                                           IdVuelo=d.IdVuelo,
                                           

                                       }).Where(d=>d.IdVuelo==model.Id).OrderByDescending(d => d.Id).ToList();


                    oReply.Success = 1;
                    oReply.Data = lst;
                }
                catch (Exception ex)
                {
                    oReply.Message = ex.Message;
                }

                return oReply;
            }
        }

    }
}
