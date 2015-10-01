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
using IO;
namespace PhoneApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void button1_plus_Click(object sender, RoutedEventArgs e)
        {
            double x1, x2, y;
            x1 = Convert.ToDouble(textBox_l1.Text);
            x2 = Convert.ToDouble(textBox_l2.Text);
            y = x1 + x2;
            textBox_wynik.Text = Convert.ToString(y);
        }

        private void button2_minus_Click(object sender, RoutedEventArgs e)
        {
            double x1, x2, y;
            x1 = Convert.ToDouble(textBox_l1.Text);
            x2 = Convert.ToDouble(textBox_l2.Text);
            y = x1 - x2;
            textBox_wynik.Text = Convert.ToString(y);
        }

        private void button3_razy_Click(object sender, RoutedEventArgs e)
        {
            double x1, x2, y;
            x1 = Convert.ToDouble(textBox_l1.Text);
            x2 = Convert.ToDouble(textBox_l2.Text);
            y = x1 * x2;
            textBox_wynik.Text = Convert.ToString(y);
        }

        private void button4_dziel_Click(object sender, RoutedEventArgs e)
        {
            double x1, x2, y;
            x1 = Convert.ToDouble(textBox_l1.Text);
            x2 = Convert.ToDouble(textBox_l2.Text);
            y = x1 / x2;
            textBox_wynik.Text = Convert.ToString(y);
        }

       
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Value 1";
            textBlock1.Text = "Value 2";
            textBlock2.Text = "Result";
            KALKULATOR.Text = "CALCULATOR";
            ApplicationTitle.Text = "Application";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Liczba 1";
            textBlock1.Text = "Liczba 2";
            textBlock2.Text = "Wynik";
            KALKULATOR.Text = "KALKULATOR";
            ApplicationTitle.Text = "Aplikacja";
        }
    }
}