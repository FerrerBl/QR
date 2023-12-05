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
        [ForeignKey(nameof(Eventos))]
        public int IdEvento { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public string NombreAlumno { get; set; }
        public string NumeroControlAlumno { get; set; }


       
    }
}
