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
   public class AeronaveService:IAeronaveService
    {
        public Reply GetAeronave()
        {
            using (DigitalWareContext db = new DigitalWareContext())
            {
                Reply oReply = new Reply();
                try
                {

                    List<Aeronave> lst = (from d in db.Aeronaves

                                       select new Aeronave
                                       {
                                           Id=d.Id,
                                           Marca = d.Marca,
                                           Modelo=d.Modelo,
                                           Capacidad=d.Capacidad
                                   
                                       }).OrderByDescending(d=>d.Id).ToList();


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
        public Reply AddAeronave(AeronaveRequest model)
        {
            using (DigitalWareContext db = new DigitalWareContext())
            {
                Reply oReply = new Reply();
                oReply.Success = 0;
                try
                {
                    var aeronave = new Aeronave();
                    aeronave.Marca = model.Marca;
                    aeronave.Modelo = model.Modelo;
                    aeronave.Capacidad = model.Capacidad;
                    db.Aeronaves.Add(aeronave);
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

        public Reply EditAeronave(AeronaveRequest model)
        {
            using (DigitalWareContext db = new DigitalWareContext())
            {
                Reply oReply = new Reply();
                oReply.Success = 0;
                try
                {
                    Aeronave aeronave = db.Aeronaves.Find(model.Id);
                    aeronave.Marca = model.Marca;
                    aeronave.Modelo = model.Modelo;
                    aeronave.Capacidad = model.Capacidad;
                    db.Entry(aeronave).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public Reply DeleteAeronave(AeronaveRequest model)
        {
            using (DigitalWareContext db = new DigitalWareContext())
            {
                Reply oReply = new Reply();
                oReply.Success = 0;
                try
                {
                    Aeronave aeronave = db.Aeronaves.Find(model.Id);
                    db.Remove(aeronave);
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

        public Reply GetAeronaveComp()
        {
            using (DigitalWareContext db = new DigitalWareContext())
            {
                Reply oReply = new Reply();
                try
                {

                    //  var lst = db.Libros.OrderByDescending(d => d.Id).ToList();


                    List<Aeronave> lst = (from d in db.Aeronaves

                                          select new Aeronave
                                          {
                                              Id = d.Id,
                                              Marca = d.Marca + " - " + d.Modelo,

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
    }
}
