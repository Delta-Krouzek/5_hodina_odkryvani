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

namespace _5_hodina_odkryvani
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Random rnd = new Random();
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri("pack://application:,,,/obr/obr" + rnd.Next(1, 4) + ".jpg"));
            myBrush.ImageSource = image.Source;
            plocha.Background = myBrush;
            VytvoreniCtvercu(poleRec);
        }
        Rectangle[,] poleRec = new Rectangle[10, 10];

        private void VytvoreniCtvercu(Rectangle[,] pole)
        {
            Random rnd = new Random();

            for (int i = 0; i < pole.GetLength(0); i++)
            {
                plocha.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < pole.GetLength(1); i++)
            {
                plocha.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    byte barva = (byte)rnd.Next(1, 255);
                    pole[i, j] = new Rectangle();
                    pole[i, j].Fill = new SolidColorBrush(Color.FromRgb(barva, barva, barva));
                    pole[i, j].StrokeThickness = 0;
                    pole[i, j].Height = plocha.Height / pole.GetLength(0);
                    pole[i, j].Width = plocha.Width / pole.GetLength(1);
                    Grid.SetColumn(pole[i, j], j);
                    Grid.SetRow(pole[i, j], i);
                    Grid.SetZIndex(pole[i, j], 3);
                    plocha.Children.Add(pole[i, j]);
                    pole[i, j].MouseDown += MainWindow_MouseDown;
                }
            }
        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rtg = (Rectangle)sender;
            rtg.Fill = Brushes.Transparent;
        }
    }
}
