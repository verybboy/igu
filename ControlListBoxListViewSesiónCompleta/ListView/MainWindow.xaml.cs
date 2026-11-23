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

namespace ListView
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Entrada.Focus();
        }

        private void BotonAniadir_Click(object sender, RoutedEventArgs e)
        {
            if ((string)BotonAniadir.Content == "Añadir")
            {
                Amigo nuevo = new Amigo();
                nuevo.Nombre = Entrada.Text;
                if (Entrada2.Text.Length > 0)
                {
                    nuevo.Apellidos = Entrada2.Text;
                }
                TablaListView.Items.Add(nuevo);
                Entrada.Text = "";
                Entrada2.Text = "";
                Entrada.Focus();
            }
            else
            {
                if (TablaListView.SelectedIndex >= 0)
                {
                    TablaListView.Items.RemoveAt(TablaListView.SelectedIndex);
                    TablaListView.UnselectAll();
                }
            }
        }

        private void TablaListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TablaListView.SelectedItem != null)
            {
                Amigo a = (Amigo)(TablaListView.SelectedItem);
                a.Edad += 1;
                Salida.Text = TablaListView.SelectedItem.ToString();
                BotonAniadir.Content = "Eliminar";
                BotonAniadir.IsEnabled = true;
                //TablaListView.Items.Refresh();
            }
            else
            {
                Salida.Text = "";
                BotonAniadir.Content = "Añadir";
                Entrada.Focus();
                if (Entrada.Text.Length > 0)
                {
                    BotonAniadir.IsEnabled = true;
                }
                else
                {
                    BotonAniadir.IsEnabled = false;
                }
            }
        }

        private void Entrada_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Entrada.Text.Length > 0)
            {
                Entrada2.IsEnabled = true;
                BotonAniadir.IsEnabled = true;
            }
            else
            {
                Entrada2.Text = "";
                Entrada2.IsEnabled = false;
                BotonAniadir.IsEnabled = false;
            }
        }
    }
}
