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

namespace cuadrosDialogo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CDModal cdm;
        public MainWindow()
        {
            InitializeComponent();
            cdm = null;
        }

        public void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender == CDModal)
            {
                cdm = new CDModal();
                cdm.Owner = this;

                double opacidad = MiCanvas.Background.Opacity;

                cdm.Opacidad = opacidad;
                cdm.ShowDialog(); //Aqui para la ejecucion y se ejecuta el Cuadro Modal y luego cuando se cierra, sigue por aquí

                if(cdm.DialogResult == true)
                {
                    Brush br = MiCanvas.Background.Clone();
                    br.Opacity = cdm.Opacidad;
                    MiCanvas.Background = br;
                }
            }
        }
    }
}
