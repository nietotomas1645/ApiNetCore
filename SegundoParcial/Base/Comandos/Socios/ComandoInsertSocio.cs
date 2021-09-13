using System;

using Base.Models;

namespace Base.Comandos.Socios
{
    public class ComandoInsertSocio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int IdDeporte { get; set; }

    }
}
