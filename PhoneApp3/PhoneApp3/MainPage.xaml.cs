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

namespace PhoneApp3
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            StreamReader sr;
            string[] files, dirs;
            using (IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                dirs = isoFile.GetDirectoryNames("Shared\\*");
                if (isoFile.DirectoryExists("Shared\\g"))
                {
                    files = isoFile.GetFileNames("Shared\\g\\*.txt");
                    //isoFile.CreateFile("Shared\\g\\test.txt");
                    IsolatedStorageFileStream txtFile = new IsolatedStorageFileStream("Shared\\g\\" + files[0], FileMode.Open, isoFile);
                    sr = new StreamReader(txtFile);
                    textBox1.Text = sr.ReadLine();
                    sr.Close();
                    txtFile.Close();
                    isoFile.Dispose();
                }
            }
        }
    }
}