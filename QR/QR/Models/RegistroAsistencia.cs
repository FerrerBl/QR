using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
using QR.Models;
namespace QR.Models
{
    public class RegistroAsistencia
    {
        [PrimaryKey, AutoIncrement]
        public int IdAsistencia { get; set; }
        public int IdEvento { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public string NombreAlumno { get; set; }
        public string NumeroControlAlumno { get; set; }
        public int IdUsuarioCaptura { get; set; }

        [ForeignKey(nameof(Eventos))] // Corregido aquí
        public int IdEventos { get; set; }

        [ForeignKey(nameof(Usuario))] // Corregido aquí
        public int IdUsuario { get; set; }
    }
}
