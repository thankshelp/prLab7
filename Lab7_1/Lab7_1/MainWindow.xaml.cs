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

namespace Lab7_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer Timer;
        Line myLine = new Line();
        Ellipse myEllipse = new Ellipse();
        Rectangle myRect = new Rectangle();
        Polygon myPolygon = new Polygon();
        Path path = new Path();
        SolidColorBrush mySolidColorBrush = new SolidColorBrush();
        Rectangle viky = new Rectangle();
        int currentFrame;
        int currentRow;



        public MainWindow()
        {
            InitializeComponent();

            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var frameCount = 56;
            var frameW = 100;
            var frameH = 100;

            if (currentFrame != 6) 
            {
                if (currentRow == 8)
                {
                    currentFrame = 0;
                    currentRow = 0;
                }
                currentFrame = (currentFrame + 1 + frameCount) % frameCount;
            }
            else
            {
                currentFrame = 0;
                currentRow++;
            }

            var frameLeft = currentFrame * frameW;
            var frameTop = currentRow * frameH;
            (viky.Fill as ImageBrush).Viewbox = new Rect(frameLeft, frameTop, frameLeft + frameW, frameTop + frameH);
        }
            private void Line_Click(object sender, RoutedEventArgs e)
        {
            myLine.Stroke = System.Windows.Media.Brushes.DeepPink;

            myLine.X1 = 0;
            myLine.Y1 = 0;
            myLine.X2 = 792;
            myLine.Y2 = 419;

            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;

            myLine.StrokeThickness = 10;
            myLine.Margin = new Thickness(0, 0, 0, 0);

            scene.Children.Add(myLine);
        }

        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            scene.Children.Remove(myLine);
            scene.Children.Remove(myEllipse);
            scene.Children.Remove(myRect);
            scene.Children.Remove(myPolygon);
            scene.Children.Remove(path);
            scene.Children.Remove(viky);
            Timer.Stop();
        }

        private void Ellipse_Click(object sender, RoutedEventArgs e)
        {
            mySolidColorBrush.Color = Color.FromArgb(255, 140, 230, 150);
            myEllipse.Fill = mySolidColorBrush;
            myEllipse.StrokeThickness = 5;
            myEllipse.Stroke = Brushes.BlueViolet;

            myEllipse.Width = 100;
            myEllipse.Height = 100;
            myEllipse.Margin = new Thickness(350, 170, 0, 0);

            scene.Children.Add(myEllipse);
        }

        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            myRect.Stroke = Brushes.DarkOliveGreen;
            myEllipse.StrokeThickness = 2.5;
            myRect.Fill = Brushes.Gold;

            myRect.HorizontalAlignment = HorizontalAlignment.Left;
            myRect.VerticalAlignment = VerticalAlignment.Center;

            myRect.Height = 70;
            myRect.Width = 70;
            myRect.Margin = new Thickness(240, 100, 0, 0);
            
            scene.Children.Add(myRect);
        }

        private void Polygon_Click(object sender, RoutedEventArgs e)
        {
            myPolygon.Stroke = Brushes.LemonChiffon;
            myPolygon.Fill = Brushes.LightSeaGreen;
            myPolygon.StrokeThickness = 3.5;

            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;

            Point Point1 = new Point(0, 0);
            Point Point2 = new Point(100, 0);
            Point Point3 = new Point(100, 50);
            Point Point4 = new Point(50, 100);
            Point Point5 = new Point(0, 50);

            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPointCollection.Add(Point4);
            myPointCollection.Add(Point5);

            myPolygon.Points = myPointCollection;

            scene.Children.Add(myPolygon);
        }

        private void Paths_Click(object sender, RoutedEventArgs e)
        {
            path.Stroke = Brushes.DeepSkyBlue;
            path.StrokeThickness = 1.5;
            
            BezierSegment bezierCurve1 = new BezierSegment(new Point(100, 100), new Point(100, 150), new Point(150, 190),true);
            BezierSegment bezierCurve2 = new BezierSegment(new Point(200, 150), new Point(200, 100), new Point(150, 130), true);

            PathSegmentCollection psc = new PathSegmentCollection();
            psc.Add(bezierCurve1);
            psc.Add(bezierCurve2);

            PathFigure pf = new PathFigure();
            pf.Segments = psc;
            pf.StartPoint = new Point(150, 130);

            PathFigureCollection pfc = new PathFigureCollection();
            pfc.Add(pf);

            PathGeometry pg = new PathGeometry();
            pg.Figures = pfc;

            GeometryGroup pathGeometryGroup = new GeometryGroup();
            pathGeometryGroup.Children.Add(pg);

            path.Data = pathGeometryGroup;

            scene.Children.Add(path);
        }

        private void ImE_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush ib = new ImageBrush();

            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;

            myEllipse.RenderTransform = new SkewTransform(-45, 0); 

            ib.ImageSource = new BitmapImage(new Uri(@"D://Программирование//2 семестр//Lab7//Lab7_1//Lab7_1//image//slCrEJqEQoY.jpg", UriKind.Absolute));
            myEllipse.Fill = ib;
        }

        private void ImR_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush ib = new ImageBrush();

            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;

            myRect.RenderTransform = new TranslateTransform(50, 50);
            myRect.RenderTransform = new RotateTransform(45, 50, 50);

            ib.ImageSource = new BitmapImage(new Uri(@"D://Программирование//2 семестр//Lab7//Lab7_1//Lab7_1//image//Al7PUEaW6G0.jpg", UriKind.Absolute));
            myRect.Fill = ib;
        }

        private void ImP_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush ib = new ImageBrush();

            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;

            myPolygon.RenderTransform = new ScaleTransform(2, 0.5);

            ib.ImageSource = new BitmapImage(new Uri(@"D://Программирование//2 семестр//Lab7//Lab7_1//Lab7_1//image//XPq4gVoApG0.jpg", UriKind.Absolute));
            
            myPolygon.Fill = ib;
        }

        private void Anim_Click(object sender, RoutedEventArgs e)
        {
            viky.Height = 100;
            viky.Width = 100;

            ImageBrush ib = new ImageBrush();

            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;
            ib.Stretch = Stretch.None;

            ib.Viewbox = new Rect(0, 0, 200, 100);
            ib.ViewboxUnits = BrushMappingMode.Absolute;

            currentFrame = 0;
            currentRow = 0;

            ib.ImageSource = new BitmapImage(new Uri(@"D://Программирование//2 семестр//Lab7//Lab7_1//Lab7_1//image//VictoriaSprites.gif", UriKind.Absolute));
            viky.Fill = ib;

            viky.Margin = new Thickness(300, 200, 0, 0);

            scene.Children.Add(viky);
            Timer.Start();
        }
    }
}
