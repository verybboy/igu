//---------------------------------------
//Esta sesión va sobre el desacoplamiento
//---------------------------------------
//SOLUCIÓN 2 MODIFICADA POR GUILLERMO

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
            tb.aviso = InformeAvanceTipo1; //Cambio - Si quitamos esto en el switch no falla por los ifs agregados
            tb.aviso += InformeAvanceTipo2; //Cambio
            //PROBAR
            //tb.aviso += InformeAvanceTipo2;
            //tb.aviso -= InformeAvanceTipo2;

            tb.ATrabajar(); //Cambio
            Console.Write("Terminado\n");
        }
        void InformeAvanceTipo1(int x) //Método
        {
            string str = String.Format("Ya llevamos el {0}", x);
            Console.WriteLine(str);
        }
        void InformeAvanceTipo2(int x)
        {
            Console.Write("***");
        }
    }
    class TrabajoDuro
    {
        int PocentajeHecho;
        //observador eljefe; //Esto es lo que hace que esté acoplado
        public Aviso aviso; //Cambio
        public TrabajoDuro() //Constructor
        {
            PocentajeHecho = 0;
        }
        public void ATrabajar() //Método //Cambio
        {
            int i;
            for (i = 0; i < 500; i++)
            {
                System.Threading.Thread.Sleep(1); //Hacemos el trabajo
                switch (i)
                {
                    case 125:
                        PocentajeHecho = 25;
                        //aviso?.Invoke(PocentajeHecho); //Es lo mismo que las dos linas isguientes
                        if(aviso != null) //Si no le pasamos nada no rompe, por eso ponemos estos ifs
                            aviso(PocentajeHecho);
                        break;
                    case 250:
                        PocentajeHecho = 50;
                        if (aviso != null)
                            aviso(PocentajeHecho);
                        break;
                    case 375:
                        PocentajeHecho = 75;
                        if (aviso != null)
                            aviso(PocentajeHecho);
                        break;
                }
            }
        }
    }
}