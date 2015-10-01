using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO;
using System.IO.IsolatedStorage;
using System.Device.Location;
using System.Threading;

namespace PhoneApp2
{
    public partial class MainPage : PhoneApplicationPage
    {
        GeoCoordinateWatcher gcw;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        // Text textBoxów ustawione.
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            textBlock3.Text = "Status GPS:";
            textBlock1.Text = "Szerokość Geograficzna:";
            textBlock2.Text = "Długość Geograficzna:";
        }

        // Uruchomienie Pozycji GPS
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (gcw == null)
            {
                gcw = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
                gcw.MovementThreshold = 5;
                gcw.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(gcw_StatusChanged);
                gcw.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(gcw_PositionChanged);
                gcw.Start();
                button2.Content = "Stop";
            }
            else
            {
                gcw.Stop();
                gcw.Dispose();
                gcw = null;
                button2.Content = "Start";
            }
        }

        // Status GPS.
        void gcw_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            textBlock3.Text = "Status GPS:" + e.Status.ToString();
        }

        // Długość i Szerokość Geograficzna
        void gcw_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            textBox1.Text = e.Position.Location.Latitude.ToString();
            textBox2.Text = e.Position.Location.Longitude.ToString();

            string[] files, dirs;
            using (IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                dirs = isoFile.GetDirectoryNames("shared\\g*");
                if (isoFile.DirectoryExists("shared\\g"))
                {
                    files = isoFile.GetFileNames("shared\\g\\*.txt");
                    IsolatedStorageFileStream txtFile = new IsolatedStorageFileStream("shared\\g\\" + files[1], FileMode.Open, isoFile);
                    StreamWriter wr = new StreamWriter(txtFile);
                    wr.WriteLine(textBox1.Text);
                    wr.WriteLine(textBox2.Text);
                    wr.Close();
                    txtFile.Close();
                }
            }
        }

        // Zpisz Pozycji GPS
        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}