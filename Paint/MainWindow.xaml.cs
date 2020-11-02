using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Paint
{
    public partial class MainWindow : Window
    {
        private Polyline polyline;
        private bool connectMode = false;
        private bool forceConnectMode = false;
        private BrushSettings brushSettings;

        public MainWindow()
        {
            InitializeComponent();
            brushSettings = new BrushSettings(this);
        }

        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Draw(e);
        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Draw(e);
            }
        }

        private void Draw(MouseEventArgs e)
        {
            if (MyCanvas.Children.Count == 0 || !connectMode)
            {
                polyline = new Polyline();
                polyline.Stroke = brushSettings.Color;
                polyline.StrokeThickness = brushSettings.StrokeThickness;
                MyCanvas.Children.Add(polyline);
            }
            polyline = (Polyline)MyCanvas.Children[MyCanvas.Children.Count - 1];
            polyline.Stroke = brushSettings.Color;
            polyline.StrokeThickness = brushSettings.StrokeThickness;

            polyline.Points.Add(e.GetPosition(MyCanvas));
            connectMode = true;
        }

        private void MyCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            forceConnectMode = !forceConnectMode;
            MyCanvas_MouseLeftButtonUp(sender, e);
        }

        private void MyCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!forceConnectMode)
                connectMode = false;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            brushSettings.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            brushSettings.Close();
        }
    }
}