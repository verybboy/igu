using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_amigos
{
    internal class Amigo
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad{ get; set; }
    }

    public Amigo (string nombre, string apellidos)
    {
        this.Nombre = nombre;

    }
}
