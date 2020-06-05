using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using PolygonApp.Model;

namespace PolygonApp.View
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainPolygon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPolygonAlert.Visibility = Visibility.Hidden;
            MainPolygon.Points.Add(e.GetPosition(this));
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MainPolygonAlert.Visibility = Visibility.Visible;
            MainPolygon.Points.Clear();
        }

        private void MainPolygon_MouseMove(object sender, MouseEventArgs e)
        {
            if (!MainPolygon.Points.Any())
            {
                return;
            }

            var mousePoint = e.GetPosition(this);
            var isBelong =
                PolygonChecker.IsPointInsidePolygon(MainPolygon.Points.ToList(), mousePoint);

            BelongStatus.Background = isBelong ? Brushes.LightGreen : Brushes.IndianRed;
        }
    }
}