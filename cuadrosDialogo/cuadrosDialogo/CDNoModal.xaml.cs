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
    /// Lógica de interacción para CDNoModal.xaml
    /// </summary>
    /// 
    public class CambioOpacidadEventArgs : EventArgs
    {
        public double ValorOpacidad
        {
            get; set;
        }
    }
    public partial class CDNoModal : Window
    {
        public event EventHandler<CambioOpacidadEventArgs> CambioOpacidad;
        private double opacidad;
        public CDNoModal()
        {
            InitializeComponent();
            opacidad = 0.0;
        }

        public double Opacidad
        {
            get
            {
                return Opacidad;
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
            CambioOpacidadEventArgs coe = new CambioOpacidadEventArgs();
            coe.ValorOpacidad = opacidad;
            OnCambioOpacidad(coe); //Puede ser también CambioOpacidad?.Invoke(this,coe);  pero es mejor esta otra opción
        }

        protected virtual void OnCambioOpacidad(CambioOpacidadEventArgs e)
        {
            if (CambioOpacidad != null)
            {
                this.CambioOpacidad(this, e);
            }
            // Esto sería lo mismo Cambio.Opacidad?.Invoke(this, e);
        }

        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
