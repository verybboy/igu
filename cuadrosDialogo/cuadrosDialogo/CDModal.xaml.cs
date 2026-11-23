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
using System.Windows.Shapes;

namespace cuadrosDialogo
{
    /// <summary>
    /// Lógica de interacción para CDModal.xaml
    /// </summary>
    public partial class CDModal : Window
    {
        private double opacidad;
        public CDModal()
        {
            InitializeComponent();
            opacidad = 0.0;
        }

        public double Opacidad
        {
            get
            {
                return opacidad;
            }
            set
            {
                opacidad = value;
                SliderOpacidad.Value = opacidad;
            }
        }

        private void SliderOpacidad_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            opacidad = SliderOpacidad.Value;

            if (Leyenda != null)
            {
                Leyenda.Text = opacidad.ToString("F");
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
