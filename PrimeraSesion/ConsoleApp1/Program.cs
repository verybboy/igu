using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ConsoleApp1
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Hola mundo");

            Window w = new Window();
            w.Title = "Hola mundo";

            StackPanel stackPanel = new StackPanel(); //Version 2
            w.Content = stackPanel; //Version 2

            Label etiqueta = new Label();
            etiqueta.Content = "Otra vez: Hola Mundo";
            etiqueta.Foreground = Brushes.Red;
            etiqueta.Background = Brushes.Yellow;

            stackPanel.Children.Add(etiqueta); //Version 2

            //w.Content = etiqueta; //Version 1

            etiqueta = new Label();
            etiqueta.Content = "Otra etiqueta";

            stackPanel.Children.Add(etiqueta); //Version 2
            
            Button btn = new Button(); //Version 3
            btn.Content = "Pulsar";
            btn.Foreground = Brushes.Cyan;
            btn.Background = Brushes.Black;
            btn.Width = 100;
            btn.Height = 100;

            btn.Click += Btn_Click; //Btn_Click crea el método Btn_Click

            stackPanel.Children.Add(btn);
            //w.Content = etiqueta; //Version 1

            w.Show();

            Application app = new Application();
            app.Run(w); //Crea el bucle infinito de eventos
        }

        private static void Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Botón pulsado");
        }
    }
}
