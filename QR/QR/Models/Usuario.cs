using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace QR.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }
        [NotNull]
        public string RolUsuario { get; set; }
        [NotNull, MaxLength(50)]
        public string NombreUsuario { get; set; }
        [NotNull, MaxLength(50)]
        public string ApellidoPUsuario { get; set; }
        [NotNull, MaxLength(50)]
        public string ApellidoMUsuario { get; set; }

        [NotNull, MaxLength(50)]
        public string NombreCuenta { get; set; }
        [NotNull]
        public string CorreoUsuario { get; set; }
        [NotNull]
        public string Contraseña { get; set; }
        [NotNull]
        public string NoControlUsuario { get; set; }
        [NotNull]

        public bool Estado { get; set; }
    }
}
