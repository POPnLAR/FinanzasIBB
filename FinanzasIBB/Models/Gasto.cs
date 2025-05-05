using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasIBB.Models
{
    public class Gasto
    {
        public string NombreGasto { get; set; }
        public string? DetalleGasto { get; set; }
        public double ValorGasto { get; set; }
        public DateTime FecVencimientoGasto { get; set; }
        public DateTime FecPagoGasto { get; set; }
        public TipoGasto TipoGasto { get; set; }
    }
}
