using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBox2
{
    internal class Amigo
    {
        private string nombre, apellidos;
        private int edad;
        public Amigo(string nombre, string apellidos, int edad)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
        }

        public Amigo()
        {
            nombre = "";
            apellidos = "";
            edad = 30;
        }

        public string Nombre { get { return nombre; } set { nombre = value; } }

        public string Apellidos { get { return apellidos; } set { apellidos = value; } }
        public int Edad { get { return edad; } set { edad = value; } }

        public override string ToString()
        {
            return Nombre + " " + Apellidos + " " + Edad;
        }
    }
}
