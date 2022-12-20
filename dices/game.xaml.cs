using System;
using System.Collections.Generic;
using System.IO;
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

namespace dices
{
    /// <summary>
    /// Interaction logic for game.xaml
    /// </summary>
    public partial class game : Window
    {
        Random random = new Random();
        Image image;
        int[] array;
        bool picked;
        List<int> list = new List<int>();
        public game()
        {
            array = new int[6];
            InitializeComponent();
            showDices();                
        }

        private ImageSource GetImage(byte[] resource)
        {
            MemoryStream memoryStream = new MemoryStream(resource);
            BitmapFrame bitmapFrame = BitmapFrame.Create(memoryStream);
            Image image = new Image();
            image.Source = bitmapFrame;
            return image.Source;
        }
        public void showDices()
        {
            for (int i = 0; i < 6; i++)
            {
                int x = random.Next(1,7);
                image = new Image();
                image.Source = new BitmapImage(new Uri($@"/pictures/dice{x}.png", UriKind.Relative));
                array[i] = x;
                image.Tag = i;
                image.MouseDown += GridMouse;
                PlayerGrid.Children.Add(image);
                Grid.SetRow(image,2);
                Grid.SetColumn(image,i);

            }
        }

        public void GridMouse(object sender, MouseButtonEventArgs e)
        {

            Image image = sender as Image;
            int exos = int.Parse(image.Tag.ToString());
            int x = exos;
            image.Tag = image.Tag += "picked";
            Border border = new Border();
            border.BorderThickness = new Thickness(2);
            border.BorderBrush = Brushes.White;
            border.CornerRadius = new CornerRadius(200);
            PlayerGrid.Children.Add(border);
            Grid.SetRowSpan(border, 3);
            Grid.SetColumnSpan(border, 1);
            Grid.SetRow(border,1);
            Grid.SetColumn(border,x);
            if (true)
            {
                switch (array[x])
                {
                    case 1:
                        list.Add(1);
                        break;
                    case 2:
                        list.Add(2);
                        break;
                    case 3:
                        list.Add(3);
                        break;
                    case 4:
                        list.Add(4);
                        break;
                    case 5:
                        list.Add(5);
                        break;
                    case 6:
                        list.Add(6);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
