using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using QR;
namespace QR.Models
{
    public class Eventos
    {
        [PrimaryKey, AutoIncrement]
        public int IdEventos { get; set; }

        [NotNull, MaxLength(50)]
        public string NombreEvento { get; set; }
        [NotNull]

        public DateTime FechaHoraEvento { get; set; }
        public bool Estado {  get; set; }   
    }
}
