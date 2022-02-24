using curzi.lorenzo._5H.EsercitazioneGestioneAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace curzi.lorenzo._5H.EsercitazioneGestioneAPI
{
    /// <summary>
    /// Logica di interazione per AdviceWindow.xaml
    /// </summary>
    public partial class AdviceWindow : Window
    {
        public AdviceWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Main Page button (it brings the user back to MainWidnow.xaml)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPageButton_Click(object sender, RoutedEventArgs e) 
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

        /// <summary>
        /// Makes a HTTP call to Advice Slip JSON API and shows the advice to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetAdvice_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://api.adviceslip.com/advice"); //URL da contattare

                var getResult = client.GetAsync(endpoint).Result;

                var getResultJson = getResult.Content.ReadAsStringAsync().Result;

                Advice advice = JsonConvert.DeserializeObject<Advice>(getResultJson);

                TextAdvice.Text = advice.slip.advice.ToString();
            }
        }
    }
}
