using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PruebaCamiloBautista.Dominio.Modelos.Request
{
  public class AeronaveRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public int Capacidad { get; set; }


    }
}
