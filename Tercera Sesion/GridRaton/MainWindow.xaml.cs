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

namespace GridTeclado
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
            Keyboard.Focus(elGrid);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // --- Donde está el rectángulo ---
            int fila = Grid.GetRow(elRectangulo);
            int columna = Grid.GetColumn(elRectangulo);
            double escalaY = elRectScale.ScaleY;
            double escalaX = elRectScale.ScaleX;


            if (e.Key == Key.Up)
            {
                if (fila == 0)
                {
                    Grid.SetRow(elRectangulo, elGrid.RowDefinitions.Count() - 1);
                }
                else
                {
                    Grid.SetRow(elRectangulo, --fila);
                }
            }
            else if (e.Key == Key.Down)
            {
                if (fila == elGrid.RowDefinitions.Count() - 1)
                {
                    Grid.SetRow(elRectangulo, 0);
                }
                else
                {
                    Grid.SetRow(elRectangulo, ++fila);
                }
            }
            else if (e.Key == Key.Left)
            {
                if (columna == 0)
                {
                    Grid.SetColumn(elRectangulo, elGrid.ColumnDefinitions.Count() - 1);
                }
                else
                {
                    Grid.SetColumn(elRectangulo, --columna);
                }
            }
            else if (e.Key == Key.Right)
            {
                if (columna == elGrid.ColumnDefinitions.Count() - 1)
                {
                    Grid.SetColumn(elRectangulo, 0);
                }
                else
                {
                    Grid.SetColumn(elRectangulo, ++columna);
                }
            }
            else if (e.Key == Key.Add)
            {
                if (elRectScale.ScaleY != 2 || elRectScale.ScaleX != 2)
                {
                    elRectScale.ScaleY += 0.1;
                    elRectScale.ScaleX += 0.1;
                }
            }
            else if (e.Key == Key.Subtract)
            {
                if (elRectScale.ScaleY != 0.1 || elRectScale.ScaleX != 0.1)
                {
                    elRectScale.ScaleY -= 0.1;
                    elRectScale.ScaleX -= 0.1;
                }
            }
            else if (e.Key == Key.Escape)
            {
                elRectScale.ScaleY = 1;
                elRectScale.ScaleX = 1;
            }

        }

        private void elGrid_MouseMove(object sender, MouseEventArgs e)
        {
            elRecRotar.Angle = (elRecRotar.Angle >= 359 ? 0 : elRecRotar.Angle + 1);
        }

        private void elGrid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if(e.Delta > 0 && (elRectScale.ScaleY < 2 && elRectScale.ScaleX < 2))
            {
                elRectScale.ScaleY += 0.1;
                elRectScale.ScaleX += 0.1;
            }
            else if (e.Delta < 0 && (elRectScale.ScaleY > 0.1 && elRectScale.ScaleX > 0.1))
            {
                elRectScale.ScaleY -= 0.1;
                elRectScale.ScaleX -= 0.1;
            }
        }
    }
}
