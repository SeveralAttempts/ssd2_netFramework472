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
        SchemeOne so;
        SchemeTwo st;
        public MainWindow()
        {
            InitializeComponent();
            so = null;
            st = null;
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
            if (linePickerOne.SelectedItem.ToString() == "Line")
            {
                so = new SchemeOne(new Line(new Point(rand.NextDouble() * 500, rand.NextDouble() * 500),
                new Point(rand.NextDouble() * 500, rand.NextDouble() * 500)));
                so.N = 4;
                so.Draw(new GreenContext());
            }
            if (linePickerOne.SelectedItem.ToString() == "Bezier")
            {
                so = new SchemeOne(new Bezier(new Point(rand.NextDouble() * 500, rand.NextDouble() * 500),
                new Point(rand.NextDouble() * 500, rand.NextDouble() * 500),
                new Point(rand.NextDouble() * 500, rand.NextDouble() * 500),
                new Point(rand.NextDouble() * 500, rand.NextDouble() * 500)));
                so.N = 4;
                so.Draw(new GreenContext());
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
            if (linePickerTwo.SelectedItem.ToString() == "Line")
            {
                st = new SchemeTwo(new Line(new Point(rand.NextDouble() * 500, rand.NextDouble() * 500),
                new Point(rand.NextDouble() * 500, rand.NextDouble() * 500)));
                st.N = 4;
                st.Draw(new BlackContext());
            }
            if (linePickerTwo.SelectedItem.ToString() == "Bezier")
            {
                st = new SchemeTwo(new Bezier(new Point(rand.NextDouble() * 500, rand.NextDouble() * 500),
                new Point(rand.NextDouble() * 500, rand.NextDouble() * 500),
                new Point(rand.NextDouble() * 500, rand.NextDouble() * 500),
                new Point(rand.NextDouble() * 500, rand.NextDouble() * 500)));
                st.N = 4;
                st.Draw(new BlackContext());
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
            so.SaveSVG();
        }

        void OnButtonSVGClickedTwo(object sender, EventArgs args)
        {
            st.SaveSVG();
        }
    }
}
