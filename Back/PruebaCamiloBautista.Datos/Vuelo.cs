using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaCamiloBautista.Datos
{
    public partial class Vuelo
    {
        public Vuelo()
        {
            Pasajeros = new HashSet<Pasajero>();
            VueloUsuarios = new HashSet<VueloUsuario>();
        }

        public int Id { get; set; }
        public int IdAeronave { get; set; }
        public int IdUsuario { get; set; }
        public string Destino { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public int? Estado { get; set; }

        public virtual Aeronave IdAeronaveNavigation { get; set; }
        public virtual ICollection<Pasajero> Pasajeros { get; set; }
        public virtual ICollection<VueloUsuario> VueloUsuarios { get; set; }
    }
}
