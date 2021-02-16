using PruebaCamiloBautista.Datos;
using PruebaCamiloBautista.Dominio.Interface;
using PruebaCamiloBautista.Dominio.Modelos.Respuesta;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PruebaCamiloBautista.Dominio.Modelos.Request;

namespace PruebaCamiloBautista.Dominio.Service
{
    public class VuelosService:IVuelosService
    {
        public Reply GetVuelos()
        {
            using (DigitalWareContext db = new DigitalWareContext())
            {
                Reply oReply = new Reply();
                try
                {


                    var lst = (from d in db.Vuelos
                                       join h in db.Aeronaves on d.IdAeronave equals h.Id
                                          select new 
                                          {
                                            Id=d.Id,
                                            Destino=d.Destino,
                                            FechaLlegada=d.FechaLlegada,
                                            FechaSalida=d.FechaSalida,
                                            IdAeronave=d.IdAeronave,
                                            Estado=d.Estado,
                                            Aeronave=h.Marca+" - "+h.Modelo
                                          }).OrderByDescending(d => d.Id).ToList();


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

        public Reply AddVuelo(VuelosRequest model)
        {
            using (DigitalWareContext db = new DigitalWareContext())
            {
                Reply oReply = new Reply();
                oReply.Success = 0;
                try
                {
                    var vuelo = new Vuelo();
                    vuelo.Destino = model.Destino;
                    vuelo.FechaLlegada = model.FechaLlegada;
                    vuelo.FechaSalida = model.FechaSalida;
                    vuelo.IdAeronave = model.IdAeronave;
                    vuelo.IdUsuario = 1;
                    vuelo.Estado = 1;
                    db.Vuelos.Add(vuelo);
                    db.SaveChanges();
                    oReply.Success = 1;

                }
                catch (Exception ex)
                {
                    oReply.Message = ex.Message;
                }

                return oReply;
            }

        }
        public Reply EditVuelo(VuelosRequest model)
        {
            using (DigitalWareContext db = new DigitalWareContext())
            {
                Reply oReply = new Reply();
                oReply.Success = 0;
                try
                {
                    Vuelo vuelo = db.Vuelos.Find(model.Id);
                    vuelo.Destino = model.Destino;
                    vuelo.FechaLlegada = model.FechaLlegada;
                    vuelo.FechaSalida = model.FechaSalida;
                    vuelo.IdAeronave = model.IdAeronave;
                    db.Entry(vuelo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oReply.Success = 1;

                }
                catch (Exception ex)
                {
                    oReply.Message = ex.Message;
                }

                return oReply;
            }

        }
        public Reply DeleteVuelo(VuelosRequest model)
        {
            using (DigitalWareContext db = new DigitalWareContext())
            {
                Reply oReply = new Reply();
                oReply.Success = 0;
                try
                {
                    Vuelo vuelo = db.Vuelos.Find(model.Id);
                    db.Remove(vuelo);
                    db.SaveChanges();
                    oReply.Success = 1;
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
