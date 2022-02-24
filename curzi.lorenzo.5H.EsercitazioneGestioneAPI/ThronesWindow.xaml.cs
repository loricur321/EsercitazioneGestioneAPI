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
    /// Logica di interazione per ThronesWindow.xaml
    /// </summary>
    public partial class ThronesWindow : Window
    {
        public ThronesWindow()
        {
            InitializeComponent();
        }

        private void characterNumber_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// Method that will check the number texted by the user and show the result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int number;
            //If the conversion of the number goes wrong i will print an error message to the user
            if((characterNumber.Text == "") || !Int32.TryParse(characterNumber.Text, out number) || number < 0 || number > 52)
            {
                CharacterTextBox.Focus();
                CharacterTextBox.Text = "There has been an error with the number you have texted!!";
                CharacterImage.Source = SetImage("https://bit.ly/3t6qCCV");
            }
            else
            {
                characterNumber.Text = "";

                using (var client = new HttpClient())
                {
                    var endpoint = new Uri($"https://thronesapi.com/api/v2/Characters/{number}"); //URL da contattare

                    var getResult = client.GetAsync(endpoint).Result;

                    var getResultJson = getResult.Content.ReadAsStringAsync().Result;

                    CharacterThrones characterThrones = JsonConvert.DeserializeObject<CharacterThrones>(getResultJson);

                    CharacterTextBox.Text = $"You are the character {characterThrones.fullName} of the {characterThrones.family} family!";

                    CharacterImage.Source = SetImage(characterThrones.imageUrl);
                }
            }
        }

        /// <summary>
        /// Return the bitmap image given it's URL
        /// </summary>
        /// <param name="url">URL of the image to show</param>
        /// <returns>Bitmpa object</returns>
        private BitmapImage SetImage(string url)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(url);
            bitmap.EndInit();
            return bitmap;
        }

        /// <summary>
        /// Main Page Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }
    }
}
