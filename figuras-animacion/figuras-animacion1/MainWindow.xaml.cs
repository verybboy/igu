using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace figuras_animacion1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Figura> listaFiguras;

        private DispatcherTimer temporizador;
        public MainWindow()
        {
            InitializeComponent();
            listaFiguras = new List<Figura>();
            temporizador = new DispatcherTimer();
            temporizador.Tick += Temporizador_Tick;

            temporizador.Interval = new TimeSpan(0, 0, 0, 0, 40);
        }

        private void Temporizador_Tick(object sender, EventArgs e)
        {
            foreach (Figura figura in listaFiguras)
            {
                figura.mueve(miCanvas.ActualWidth, miCanvas.ActualHeight);
                Canvas.SetLeft(figura.laFig, figura.posX);
                Canvas.SetTop(figura.laFig, figura.posY);
            }
        }

        private void BotonCrear_Click(object sender, RoutedEventArgs e)
        {
            Figura f;

            f = new Figura(miCanvas.ActualWidth, miCanvas.ActualHeight);
            listaFiguras.Add(f);

            miCanvas.Children.Add(f.laFig);

            f.laFig.Tag = f;

            f.laFig.MouseDown += LaFig_MouseDown;

            Canvas.SetLeft(f.laFig, f.posX);
            Canvas.SetTop(f.laFig, f.posY);
            if(BotonAnimar.IsEnabled == false)
            {
                BotonAnimar.IsEnabled = true;
            }

        }

        private void LaFig_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Shape elShape = sender as Shape;
            /*Figura aEliminar;

            foreach(Figura f in listaFiguras)
            {
                if (f.laFig == elShape)
                {
                    aEliminar = f;
                    break;
                }
            }*/
            //listaFiguras.Remove(aEliminar)
            
            listaFiguras.Remove(elShape.Tag as Figura);
            miCanvas.Children.Remove(elShape);

            if (listaFiguras.Count <= 0)
            {
                if ((string)BotonAnimar.Content == "Parar")
                {
                    BotonAnimar.Content = "Animar";
                    temporizador.Stop();
                }
                BotonAnimar.IsEnabled = false;
            }
        }

        private void BotonAnimar_Click(object sender, RoutedEventArgs e)
        {
            if((string)BotonAnimar.Content == "Animar")
            {
                BotonAnimar.Content = "Parar";
                temporizador.Start();
            }
            else if ((string)BotonAnimar.Content == "Parar")
            {
                BotonAnimar.Content = "Animar";
                temporizador.Stop();
            }
        }
    }
}
