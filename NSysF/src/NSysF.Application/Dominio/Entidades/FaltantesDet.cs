using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSysF.Application.Dominio.Entidades
{
    public class FaltantesDet 
    {
        public FaltantesDet(int id, string estatus, DateTime? fechaCreacion, DateTime? fechaModificacion, int clienteId, int empleadoId, decimal cantidad, int prodMaestroId, int marcaId, bool esCadaUno, string notas)
        {
            Id = id;
            Estatus = estatus;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
            ClienteId = clienteId;
            EmpleadoId = empleadoId;
            Cantidad = cantidad;
            ProdMaestroId = prodMaestroId;
            MarcaId = marcaId;
            EsCadaUno = esCadaUno;
            Notas = notas;
        }

        public int Id { get; set; }
        public string Estatus { get; private set; } = string.Empty;
        public DateTime? FechaCreacion { get; private set; }
        public DateTime? FechaModificacion { get; private set; }
        public int ClienteId { get; private set; }
        public int EmpleadoId { get; private set; }
        public decimal Cantidad { get; private set; }
        public int ProdMaestroId { get; private set; }
        public int MarcaId { get; private set; }
        public bool EsCadaUno { get; private set; }
        public string Notas { get; private set; } = string.Empty;
    }
}
