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

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInvertir_Click(object sender, RoutedEventArgs e)
        {
            TextBox tb = txtEntrada;
            Label etiq = lblSalida;
            int i;
            string aux = "";
            for (i = 0; i < tb.Text.Length; i++)
                aux += tb.Text[tb.Text.Length - i - 1];
            etiq.Content = aux;
        }

        private void btnMayusculas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRojo_Click(object sender, RoutedEventArgs e)
        {
            if (this.Background == Brushes.Red)
            {
                this.Background = Brushes.White;
            }
            else
            {
                this.Background = Brushes.Red; //Mirar como funcionan las brochas
            }
        }

        private void btnVerde_Click(object sender, RoutedEventArgs e)
        {
            if (this.Background == Brushes.Green)
            {
                this.Background = Brushes.White;
            }else
            {
                this.Background = Brushes.Green;
            }
        }
    }
}
