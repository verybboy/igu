using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AnimacionesListView
{
    internal class Figura
    {
        private double X, Y;
        private double despX, despY;
        private Shape fig;
        public Figura()
        {
            Random rand = new Random();


            int tipo = rand.Next(1);
            if (tipo > 0)
            {
                fig = new Ellipse();
            }
            else
            {
                fig = new Rectangle();
            }

            X = rand.Next(100);
            Y = rand.Next(100);

            fig.Width = rand.Next(40);
            fig.Height = rand.Next(40);

            fig.Stroke = Brushes.Black;
            fig.StrokeThickness = 3F;
            Color clr = Color.FromRgb((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
            fig.Fill = new SolidColorBrush(clr);

            despX = rand.Next(5);
            despY = rand.Next(5);
        }

        public Figura(double limX, double limY)
        {
            Random rand = new Random();


            int tipo = rand.Next(2);
            Debug.WriteLine("tipo: " + tipo.ToString());
            if (tipo > 0)
            {
                fig = new Ellipse();
            }
            else
            {
                fig = new Rectangle();
            }


            double min = rand.Next((int)limX / 5);
            fig.Width = (min < 20 ? 20 : min);
            min = rand.Next((int)limY / 5);
            fig.Height = (min < 20 ? 20 : min);

            X = rand.Next((int)(limX - fig.Width));
            Y = rand.Next((int)(limY - fig.Height));


            fig.Stroke = Brushes.Black;
            fig.StrokeThickness = 3F;
            Color clr = Color.FromRgb((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256));
            fig.Fill = new SolidColorBrush(clr);

            min = rand.Next(5);
            despX = (min < 1) ? 1 : min;
            min = rand.Next(5);
            despY = (min < 1) ? 1 : min;
        }

        public void mueve(double limiteX, double limiteY)
        {
            X += despX;
            Y += despY;
            if ((X + fig.Width + despX) > limiteX || X < 0)
            {
                despX = -despX;
            }
            if ((Y + fig.Height + despY) > limiteY || Y < 0)
            {
                despY = -despY;
            }

        }

        public double posX
        {
            get
            {
                return X;
            }
        }

        public double posY
        {
            get
            {
                return Y;
            }
        }

        public string strLaFig
        {
            get
            {
                string[] parseada = fig.GetType().ToString().Split('.');
                return parseada[parseada.Length - 1];
            }
        }

        public Shape laFig
        {
            get
            {
                return fig;
            }
        }
        public override string ToString()
        {
            string[] parseada = fig.GetType().ToString().Split('.');

            return "Figura: " + parseada[parseada.Length - 1] + " Posición: (" + X.ToString() + "," + Y.ToString() + ") Tamaño: (" + fig.Width.ToString() + "," + fig.Height.ToString() + ")";
        }
    }
}
