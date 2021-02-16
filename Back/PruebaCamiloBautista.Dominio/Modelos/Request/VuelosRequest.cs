
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PruebaCamiloBautista.Dominio.Modelos.Request
{
   public class VuelosRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdAeronave { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public string Destino { get; set; }
        [Required]
        public DateTime FechaSalida { get; set; }
        [Required]
        public DateTime FechaLlegada { get; set; }
    }
}
