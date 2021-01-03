using System;
using System.Collections.Generic;

#nullable disable

namespace WSVenta.Models
{
    public partial class Ventum
    {
        public Ventum()
        {
            ConceptoVenta = new HashSet<ConceptoVentum>();
        }

        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public long IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<ConceptoVentum> ConceptoVenta { get; set; }
    }
}
