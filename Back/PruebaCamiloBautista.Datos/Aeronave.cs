using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaCamiloBautista.Datos
{
    public partial class Aeronave
    {
        public Aeronave()
        {
            Vuelos = new HashSet<Vuelo>();
        }

        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Capacidad { get; set; }

        public virtual ICollection<Vuelo> Vuelos { get; set; }
    }
}
