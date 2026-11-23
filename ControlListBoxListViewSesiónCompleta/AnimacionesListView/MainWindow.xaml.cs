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

namespace AnimacionesListView
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Figura> listaFiguras;
        Shape seleccionada;
        private DispatcherTimer temporizador;

        public MainWindow()
        {
            InitializeComponent();
            listaFiguras = new List<Figura>();
            temporizador = new DispatcherTimer();
            temporizador.Tick += Temporizador_Tick;
            temporizador.Interval = new TimeSpan(0, 0, 0, 0, 40);
            seleccionada = null;
        }

        private void Temporizador_Tick(object sender, EventArgs e)
        {
            foreach (Figura figura in listaFiguras)
            {
                figura.mueve(miCanvas.ActualWidth, miCanvas.ActualHeight);
                Canvas.SetLeft(figura.laFig, figura.posX);
                Canvas.SetTop(figura.laFig, figura.posY);
            }
            TablaListView.Items.Refresh();
        }

        private void BotonCrear_Click(object sender, RoutedEventArgs e)
        {
            Figura f;
            if ((string)BotonCrear.Content == "Crear figura")
            {                
                f = new Figura(miCanvas.ActualWidth, miCanvas.ActualHeight);
                listaFiguras.Add(f);
                f.laFig.Tag = f;
                miCanvas.Children.Add(f.laFig);
                TablaListView.Items.Add(f);
                f.laFig.MouseDown += LaFig_MouseDown;
                Canvas.SetLeft(f.laFig, f.posX);
                Canvas.SetTop(f.laFig, f.posY);
            }
            else
            {
                if (TablaListView.SelectedIndex >= 0)
                {
                    f = (Figura)TablaListView.Items[TablaListView.SelectedIndex];
                    TablaListView.Items.Remove(f);
                    listaFiguras.Remove(f);
                    miCanvas.Children.Remove(f.laFig);
                }
                
            }
            
        }

        private void LaFig_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Shape elShape = sender as Shape;
            /*foreach (Figura figura in listaFiguras)
            {
                if (figura.laFig == sender)
                {
                    miCanvas.Children.Remove(figura.laFig);
                    listaFiguras.Remove(figura);
                    TablaListView.Items.Remove(figura);
                    return;
                }
            }*/

            
            listaFiguras.Remove(elShape.Tag as Figura);
            TablaListView.Items.Remove(elShape.Tag as Figura);
            miCanvas.Children.Remove(elShape);
            
            if (listaFiguras.Count <= 0)
            {
                if ((string)BotonAnimar.Content == "Parar")
                {
                    BotonAnimar.Content = "Animar";
                    temporizador.Stop();
                }
            }

        }

        private void BotonAnimar_Click(object sender, RoutedEventArgs e)
        {
            if ((string)BotonAnimar.Content == "Animar")
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
        

        private void TablaListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (seleccionada != null)
            {
                seleccionada.Stroke = Brushes.Black;
                seleccionada = null;
            }
            if (TablaListView.SelectedIndex >= 0)
            {
                BotonCrear.Content = "Eliminar figura";
                Shape laFig = ((Figura)TablaListView.SelectedItem).laFig;
                laFig.Stroke = Brushes.Red;
                seleccionada = laFig;
            }
            else
            {
                BotonCrear.Content = "Crear figura";
            }
        }
    }
}
