using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PruebaCamiloBautista.Dominio.Modelos.Request
{
   public class PasajerosRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdVuelo { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public int IdSexo { get; set; }
    }
}
