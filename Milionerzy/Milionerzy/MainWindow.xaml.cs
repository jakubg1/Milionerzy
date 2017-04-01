using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Milionerzy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // lokalizacja
        private static string lokalizacja = Environment.CurrentDirectory;
        // setup zmiennych
        private int pytanie = 11;
        string[] ustawienieWygrana = new string[12];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            wczytywanieUstawien();
            losujPytanie();
        }

        private void wczytywanieUstawien()
        {
            // wczytywanie ustawień
            var dic = File.ReadLines(lokalizacja + @"\ustawienia.txt")
                  .Select(l => l.Split(new[] { '=' }))
                  .ToDictionary(s => s[0].Trim(), s => s[1].Trim());
            // wyprowadzanie do zmiennych
            for (int ustawienieWygranaNr = 0; ustawienieWygranaNr <= 12; ustawienieWygranaNr++)
            {
                if (ustawienieWygranaNr == 12)
                {
                    break;
                }
                ustawienieWygrana[ustawienieWygranaNr] = dic["wygrana" + ustawienieWygranaNr];
            }
            playSimpleSound();
        }

        private void losujPytanie()
        {
            System.Random numerPytania = new Random();
            numerPytania.Next(1, 5); // losowanie numeru pytania

            //nazwaodpowiedz1.Content = numerPytania;
        }

        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(lokalizacja + @"\sound\" + ustawienieWygrana[pytanie-1]);
            simpleSound.Play();
        }
    }
}
