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
using System.Device.Location;
using System.Threading;
using System.IO;
using System.IO.IsolatedStorage;

namespace GPS
{
    public partial class MainPage : PhoneApplicationPage
    {
        GeoCoordinateWatcher gcw;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (gcw == null)
            {
                gcw = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
                gcw.MovementThreshold = 5;
                gcw.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(gcw_StatusChanged);
                gcw.PositionChanged +=new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(gcw_PositionChanged);
                gcw.Start();
                button1.Content = "Stop";

            }

            else
            {
                gcw.Stop();
                gcw.Dispose();
                gcw = null;
                button1.Content = "Start";
            }
        }

        void gcw_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            textBox1.Text = "Status" + e.Status.ToString();
        }

        void gcw_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            textBox2.Text = e.Position.Location.Latitude.ToString();
            textBox3.Text = e.Position.Location.Longitude.ToString();
        }

         

            private void button2_Click(object sender, RoutedEventArgs e)
         {
             StreamReader sr;
             string[] files, dirs;
             using (IsolatedStorageFile isoFiles = IsolatedStorageFile.GetUserStoreForApplication())
            
              {
                 dirs = isoFiles.GetDirectoryNames("Shared\\*");
                 if (isoFiles.DirectoryExists("Shared\\g"))
           
                 {
                     
                     files = isoFiles.GetFileNames("Shared\\g\\*.txt");
                     IsolatedStorageFileStream txtFile = new IsolatedStorageFileStream("Shared\\g\\" + files[0], FileMode.Open, isoFiles);
                     sr = new StreamReader(txtFile);
                     textBox2.Text = sr.ReadLine();
                     textBox3.Text = sr.ReadLine();
                     sr.Close();
                     txtFile.Close();
                     isoFiles.Dispose();
                 }
             }
         }
    }
}
