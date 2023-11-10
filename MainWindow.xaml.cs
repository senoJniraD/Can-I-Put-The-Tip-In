using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RetroBattleBoatz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DoSetup();
        }
        List<string> OppPlaces = new List<string>();
        public async void DoSetup()
        {
            main.Visibility = Visibility.Visible;
            playboard.Visibility = Visibility.Hidden;
            int indexNew = 0;
            int index = 0;
            foreach (var child in squaregrid.Children.OfType<Rectangle>())
            {
                child.MouseLeftButtonDown += Rectangle_MouseLeftButtonDown;

                char c = (char)('a' + (index / 10)); // 'a' to 'j'

                indexNew++;
                child.Name = c + (indexNew).ToString();

                if (indexNew == 10)
                {
                    indexNew = 0;
                }

                Debug.WriteLine(child.Name);
                

                index++;
            }

            

            Random rand = new Random();
            List<string> randomValues = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                char column = (char)('A' + rand.Next(0, 10)); // Generate a random column between 'A' and 'J'
                int row = rand.Next(1, 11); // Generate a random row between 1 and 10
                randomValues.Add($"{column}{row}");
            }

            foreach (string value in randomValues)
            {
                OppPlaces.Add(value);
                Debug.WriteLine(value);
            }

        }
        int x = 20;
        bool placed = false;
        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle clickedRectangle = sender as Rectangle;
            if (!placed)
            {
               // Rectangle clickedRectangle = sender as Rectangle;
                clickedRectangle.Fill = new SolidColorBrush(Colors.White);
                x--;
                cntLab.Content = x.ToString();
                if (x == 0)
                {
                    placed = true;
                } 
            }
            else
            {

                if (OppPlaces.Contains(clickedRectangle.Name))
                {
                    clickedRectangle.Fill = new SolidColorBrush(Colors.Yellow);
                }
                Debug.WriteLine(clickedRectangle.Name);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                main.Visibility = Visibility.Hidden;
                playboard.Visibility = Visibility.Visible;
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
