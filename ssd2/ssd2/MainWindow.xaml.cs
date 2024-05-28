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
using System.Drawing;
using System.IO;

namespace ssd2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VisualPNG vp;
        VisualSVG vs;
        (double, double) FirstPoint, SecondPoint, ThirdPoint, ForthPoint;
        public MainWindow()
        {
            InitializeComponent();
            vp = null;
            vs = null;
            linePickerOne.ItemsSource = new String[]
            {
                "Line",
                "Bezier"
            };
            linePickerTwo.ItemsSource = new String[]
            {
                "Line",
                "Bezier"
            };
            linePickerOne.SelectedIndex = 0;
            linePickerTwo.SelectedIndex = 0;
        }

        void OnButtonClickedOne(object sender, EventArgs args)
        {
            Random rand = new Random();
            imgOne.Source = new BitmapImage();
            FirstPoint = (rand.NextDouble() * 500, rand.NextDouble() * 500);
            SecondPoint = (rand.NextDouble() * 500, rand.NextDouble() * 500);
            ThirdPoint = (rand.NextDouble() * 500, rand.NextDouble() * 500);
            ForthPoint = (rand.NextDouble() * 500, rand.NextDouble() * 500);
            if (linePickerOne.SelectedItem.ToString() == "Line")
            {
                vp = new VisualPNG(new Line(new Point(FirstPoint.Item1, FirstPoint.Item2),
                new Point(SecondPoint.Item1, SecondPoint.Item2)));
                vp.N = 4;
                GrapgicsConcreteContext gcg = new GrapgicsConcreteContext(new GreenContext(), "firstschemeimage");
                vp.Draw(gcg);
            }
            if (linePickerOne.SelectedItem.ToString() == "Bezier")
            {
                vp = new VisualPNG(new Bezier(new Point(FirstPoint.Item1, FirstPoint.Item2),
                new Point(SecondPoint.Item1, SecondPoint.Item2),
                new Point(ThirdPoint.Item1, ThirdPoint.Item2),
                new Point(ForthPoint.Item1, ForthPoint.Item2)));
                vp.N = 4;
                GrapgicsConcreteContext gcg = new GrapgicsConcreteContext(new GreenContext(), "firstschemeimage");
                vp.Draw(gcg);
            }

            var res = ImageSourceToByteArrayOne();
            using (MemoryStream stream = new MemoryStream(res))
            {
                imgOne.Source = BitmapFrame.Create(stream,
                                                  BitmapCreateOptions.None,
                                                  BitmapCacheOption.OnLoad);
            }
            GenerateSVGFirstScheme.IsEnabled = true;
        }

        void OnButtonClickedTwo(object sender, EventArgs args)
        {
            Random rand = new Random();
            imgTwo.Source = new BitmapImage();
            FirstPoint = (rand.NextDouble() * 500, rand.NextDouble() * 500);
            SecondPoint = (rand.NextDouble() * 500, rand.NextDouble() * 500);
            ThirdPoint = (rand.NextDouble() * 500, rand.NextDouble() * 500);
            ForthPoint = (rand.NextDouble() * 500, rand.NextDouble() * 500);
            if (linePickerTwo.SelectedItem.ToString() == "Line")
            {
                vp = new VisualPNG(new Line(new Point(FirstPoint.Item1, FirstPoint.Item2),
                new Point(SecondPoint.Item1, SecondPoint.Item2)));
                vp.N = 4;
                GrapgicsConcreteContext gcg = new GrapgicsConcreteContext(new BlackContext(), "secondschemeimage");
                vp.Draw(gcg);
            }
            if (linePickerTwo.SelectedItem.ToString() == "Bezier")
            {
                vp = new VisualPNG(new Bezier(new Point(FirstPoint.Item1, FirstPoint.Item2),
                new Point(SecondPoint.Item1, SecondPoint.Item2),
                new Point(ThirdPoint.Item1, ThirdPoint.Item2),
                new Point(ForthPoint.Item1, ForthPoint.Item2)));
                vp.N = 4;
                GrapgicsConcreteContext gcg = new GrapgicsConcreteContext(new BlackContext(), "secondschemeimage");
                vp.Draw(gcg);
            }

            var res = ImageSourceToByteArrayTwo();
            using (MemoryStream stream = new MemoryStream(res))
            {
                imgTwo.Source = BitmapFrame.Create(stream,
                                                  BitmapCreateOptions.None,
                                                  BitmapCacheOption.OnLoad);
            }
            GenerateSVGSecondScheme.IsEnabled = true;
        }

        public static byte[] ImageSourceToByteArrayOne()
        {
            var stream = File.OpenRead(
                HomePath.HP + "\\firstschemeimage.png");
            byte[] bytesAvailable = new byte[stream.Length];
            stream.Read(bytesAvailable, 0, bytesAvailable.Length);
            stream.Close();
            return bytesAvailable;
        }

        public static byte[] ImageSourceToByteArrayTwo()
        {
            var stream = File.OpenRead(
                HomePath.HP + "\\secondschemeimage.png");
            byte[] bytesAvailable = new byte[stream.Length];
            stream.Read(bytesAvailable, 0, bytesAvailable.Length);
            stream.Close();
            return bytesAvailable;
        }

        void OnButtonSVGClickedOne(object sender, EventArgs args)
        {

            if (linePickerOne.SelectedItem.ToString() == "Line")
            {
                vs = new VisualSVG(new Line(new Point(FirstPoint.Item1, FirstPoint.Item2),
                new Point(SecondPoint.Item1, SecondPoint.Item2)));
                vs.N = 4;
                GrapgicsConcreteContext gcg = new GrapgicsConcreteContext(new GreenContext());
                vs.Draw(gcg);
            }
            if (linePickerOne.SelectedItem.ToString() == "Bezier")
            {
                vs = new VisualSVG(new Bezier(new Point(FirstPoint.Item1, FirstPoint.Item2),
                new Point(SecondPoint.Item1, SecondPoint.Item2),
                new Point(ThirdPoint.Item1, ThirdPoint.Item2),
                new Point(ForthPoint.Item1, ForthPoint.Item2)));
                vs.N = 4;
                GrapgicsConcreteContext gcg = new GrapgicsConcreteContext(new GreenContext());
                vs.Draw(gcg);
            }
        }

        void OnButtonSVGClickedTwo(object sender, EventArgs args)
        {
            if (linePickerTwo.SelectedItem.ToString() == "Line")
            {
                vs = new VisualSVG(new Line(new Point(FirstPoint.Item1, FirstPoint.Item2),
                new Point(SecondPoint.Item1, SecondPoint.Item2)));
                vs.N = 4;
                GrapgicsConcreteContext gcg = new GrapgicsConcreteContext(new BlackContext());
                vs.Draw(gcg);
            }
            if (linePickerTwo.SelectedItem.ToString() == "Bezier")
            {
                vs = new VisualSVG(new Bezier(new Point(FirstPoint.Item1, FirstPoint.Item2),
                new Point(SecondPoint.Item1, SecondPoint.Item2),
                new Point(ThirdPoint.Item1, ThirdPoint.Item2),
                new Point(ForthPoint.Item1, ForthPoint.Item2)));
                vs.N = 4;
                GrapgicsConcreteContext gcg = new GrapgicsConcreteContext(new BlackContext());
                vs.Draw(gcg);
            }
        }
    }
}
