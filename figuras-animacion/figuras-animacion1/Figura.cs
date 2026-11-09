using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace figuras_animacion1
{
    class Figura
    {

        private double X, Y; //Coordenadas reales de la figura
        private double despX, despY; //Pixeles que se desplaza la figura
        private Shape fig; //Este atributo es realmente la primitiva que se va a añadir al children del canvas

        public Figura()
        {
            Random rand = new Random();

            int tipo = rand.Next(2);
            if(tipo > 0)
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
            fig.StrokeThickness = 1F;
            Color clr = Color.FromRgb((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
            fig.Fill = new SolidColorBrush(clr);

            /*min = rand.Next(5);
            despX = (min < 1) ? 1 : min;
            min = rand.Next(5);
            despY = (min < 1) ? 1 : min;*/
        }

        public Figura(double limX, double limY)
        {
            Random rand = new Random();

            int tipo = rand.Next(2);
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

            fig.Width = rand.Next(40);
            fig.Height = rand.Next(40);

            fig.Stroke = Brushes.Black;
            fig.StrokeThickness = 1F;
            Color clr = Color.FromRgb((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
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
            if((X + fig.Width + despX) > limiteX || X < 0)
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
            get { return X; }
        }
        public double posY
        {
            get { return Y; }
        }
        public Shape laFig
        {
            get { return fig; }
        }

        public override string ToString()
        {
            string res = "Figura: " + this.laFig.GetType() + this.posX + ", " + this.posY;
            return res;
        }
    }
}
