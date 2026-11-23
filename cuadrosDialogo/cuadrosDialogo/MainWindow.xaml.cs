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
        private CDNoModal cdnm;
        public MainWindow()
        {
            InitializeComponent();
            cdm = null;
            cdnm = null;
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
                    if (cdnm != null)
                    {
                        cdnm.Opacidad = br.Opacity;
                    }
                }
            }
            else if (sender == CDNoModal)
            {
                if (cdnm != null)
                {
                    return;
                }
                cdnm = new CDNoModal();
                cdnm.Owner = this; //Para que se superponga a la ventana principal y para que se cierre si la ventana principal se cierra

                cdnm.Closed += Cdnm_Closed;

                CDNoModal.IsEnabled = false;
                Brush br = MiCanvas.Background;
                cdnm.Opacidad = br.Opacity;
                cdnm.CambioOpacidad += cdCambioOpacidad;
                cdnm.Show();
            }
        }

        private void Cdnm_Closed(object sender, EventArgs e)
        {
            CDNoModal.IsEnabled = true;
            cdnm = null;
        }

        private void cdCambioOpacidad(object sender, CambioOpacidadEventArgs e)
        {
            Brush br = MiCanvas.Background.Clone();
            br.Opacity = e.ValorOpacidad;
            MiCanvas.Background = br;
        }
    }
}
