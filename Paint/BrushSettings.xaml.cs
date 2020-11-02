using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Paint
{
    public partial class BrushSettings : Window
    {
        private SolidColorBrush color = Brushes.Black;
        private int strokeThickness = 5;
        private MainWindow window;

        public BrushSettings(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }

        public SolidColorBrush Color { get { return color; } }
        public int StrokeThickness { get { return strokeThickness; } }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            strokeThickness++;
            ThicknessBox.Text = "" + strokeThickness;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            strokeThickness--;
            ThicknessBox.Text = "" + strokeThickness;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            ThicknessBox.Text = "" + strokeThickness;
        }

        private void Color_Click(object sender, RoutedEventArgs e)
        {
            color = (SolidColorBrush)((Button)sender).Background;
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            window.MyCanvas.Children.Clear();
        }
    }
}