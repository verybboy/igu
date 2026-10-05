//---------------------------------------
//Esta sesión va sobre el desacoplamiento
//---------------------------------------
//SOLUCIÓN 2 pág. 8

namespace ClasesAcopladas
{
    delegate void Aviso(int x); //Delegado
    class Acopladas
    {
        static void Main(string[] args)
        {
            observador obj = new observador();
            obj.funciona();
        }
    }
    class observador
    {
        TrabajoDuro tb;
        //public observador() { tb = new TrabajoDuro(this); } //Constructor
        public observador() { tb = new TrabajoDuro(); }
        public void funciona() //Método
        {
            Console.WriteLine("Vamos a probar el primer tipo de informe");
            tb.ATrabajar(InformeAvanceTipo1);
            Console.Write("Terminado\n");

            Console.WriteLine("Vamos a probar el segundo tipo de informe");
            tb.ATrabajar(InformeAvanceTipo2);
            Console.Write("***");
        }
        void InformeAvanceTipo1(int x) //Método
        {
            string str = String.Format("Ya llevamos el {0}", x);
            Console.WriteLine(str);
        }
        void InformeAvanceTipo2(int x) {
            Console.Write("***");
        }
    }
    class TrabajoDuro
    {
        int PocentajeHecho;
        //observador eljefe; //Esto es lo que hace que esté acoplado
        public TrabajoDuro() //Constructor
        {
            PocentajeHecho = 0;
        }
        public void ATrabajar(Aviso aviso) //Método
        {
            int i;
            for (i = 0; i < 500; i++)
            {
                System.Threading.Thread.Sleep(1); //Hacemos el trabajo
                switch (i)
                {
                    case 125:
                        PocentajeHecho = 25;
                        aviso(PocentajeHecho);
                        break;
                    case 250:
                        PocentajeHecho = 50;
                        aviso(PocentajeHecho);
                        break;
                    case 375:
                        PocentajeHecho = 75;
                        aviso(PocentajeHecho);
                        break;
                }
            }
        }
    }
}