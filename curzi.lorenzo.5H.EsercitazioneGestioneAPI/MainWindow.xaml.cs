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

namespace curzi.lorenzo._5H.EsercitazioneGestioneAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When this button is clicked it will being to the weather window and will hidden the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e) //GetWeather
        {
            //Source: https://www.youtube.com/watch?v=RNeOZU1Efh8

            ThronesWindow thronesWindow = new ThronesWindow();
            this.Visibility = Visibility.Hidden;
            thronesWindow.Show();  
        }

        /// <summary>
        /// When this button is clicked it will being to the advice window and will hidden the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e) //GetAdvice
        {
            AdviceWindow adviceWindow = new AdviceWindow();
            this.Visibility= Visibility.Hidden;
            adviceWindow.Show();
        }
    }
}
