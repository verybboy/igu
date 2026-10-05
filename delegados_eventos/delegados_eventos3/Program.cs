//---------------------------------------
//Esta sesión va sobre el desacoplamiento
//---------------------------------------
//SOLUCIÓN 3 pág. 15 MODIFICADO POR GUILLERMO

namespace ClasesAcopladas
{
    delegate void Aviso(object sender, ProcesandoEventArgs e); //Delegado

    class ProcesandoEventArgs : EventArgs
    {
        public int X { get; set; } //Lo llama con X mayuscula porque es propiedad

        public ProcesandoEventArgs(int x)  //Constructor
        { 
            X = x; 
        }
    }
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
            tb.aviso += InformeAvanceTipo1; //Cambio //Los eventos no pueden recibir una asignacion(=) debe ser (+=)
            tb.aviso += InformeAvanceTipo2; //Cambio
            tb.ATrabajar(); //Cambio
            Console.Write("Terminado\n");
        }
        void InformeAvanceTipo1(object sender, ProcesandoEventArgs e) //Método
        {
            string str = String.Format("Ya llevamos el {0}", e.X);
            Console.WriteLine(str);
        }
        void InformeAvanceTipo2(object sender, ProcesandoEventArgs e)
        {
            Console.Write("***");
        }
    }
    class TrabajoDuro
    {
        int PocentajeHecho;
        //observador eljefe; //Esto es lo que hace que esté acoplado
        //public event Aviso aviso;
        public event EventHandler<ProcesandoEventArgs> aviso; //CAMBIO
        public TrabajoDuro() //Constructor
        {
            PocentajeHecho = 0;
        }

        void OnProcesando(int dato) //Método NUEVO
        {
            //ProcesandoEventArgs e = new ProcesandoEventArgs(dato);
            if (aviso != null)
                aviso(this, e);
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
                        OnProcesando(PocentajeHecho);
                        break;
                    case 250:
                        PocentajeHecho = 50;
                        OnProcesando(PocentajeHecho);
                        break;
                    case 375:
                        PocentajeHecho = 75;
                        OnProcesando(PocentajeHecho);
                        break;
                }
            }
        }
    }
}