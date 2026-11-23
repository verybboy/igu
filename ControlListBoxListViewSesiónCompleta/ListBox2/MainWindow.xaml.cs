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

namespace ListBox2
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
                TablaListBox.Items.Add(nuevo);
                Entrada.Text = "";
                Entrada2.Text = "";
                Entrada.Focus();
                TablaListBox.ScrollIntoView(nuevo);
            }
            else
            {
                if (TablaListBox.SelectedIndex >= 0)
                {
                    TablaListBox.Items.RemoveAt(TablaListBox.SelectedIndex);
                    TablaListBox.UnselectAll();
                }
            }
        }

        private void TablaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TablaListBox.SelectedItem != null)
            {
                Amigo a = (Amigo)(TablaListBox.SelectedItem);
                a.Edad += 1;
                Salida.Text = TablaListBox.SelectedItem.ToString();
                BotonAniadir.Content = "Eliminar";
                BotonAniadir.IsEnabled = true;
                //TablaListBox.Items.Refresh();
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
