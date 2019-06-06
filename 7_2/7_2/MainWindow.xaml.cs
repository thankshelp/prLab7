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
using System.Windows.Media.Media3D;

namespace _7_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PerspectiveCamera camera = new PerspectiveCamera();
        MeshGeometry3D geometry = new MeshGeometry3D();
        public MainWindow()
        {
            InitializeComponent();

            camera.Position = new Point3D(0, 2, 0.1);
            Vector3D lookAt = new Vector3D(0, 0, 0);
            camera.LookDirection = Vector3D.Subtract(lookAt, new Vector3D(0, 2, 0.1));

            camera.FarPlaneDistance = 1000;
            camera.NearPlaneDistance = 1;
            camera.UpDirection = new Vector3D(0, 1, 0);
            camera.FieldOfView = 75;

            scene.Camera = camera;

            grd.Background = Brushes.Magenta;

           
        }

        private void Figure_Click(object sender, RoutedEventArgs e)
        {
            geometry.Positions.Add(new Point3D(-0.5, 0, -0.5));
            geometry.Positions.Add(new Point3D(-0.5, 0, 0.5));
            geometry.Positions.Add(new Point3D(0.5, 0, 0.5));

            geometry.TriangleIndices.Add(0);
            geometry.TriangleIndices.Add(1);
            geometry.TriangleIndices.Add(2);

            geometry.TextureCoordinates.Add(new Point(1, 0));
            geometry.TextureCoordinates.Add(new Point(1, 1));
            geometry.TextureCoordinates.Add(new Point(0, 1));

            ImageBrush ib = new ImageBrush();

            ib.ImageSource = new BitmapImage(new Uri(@"D://Программирование//2 семестр//Lab7//7_2//7_2//image//kirpichnaya-stena-na-balkone.jpg", UriKind.Absolute));
            DiffuseMaterial mat = new DiffuseMaterial(ib);
            
            GeometryModel3D model = new GeometryModel3D(geometry, mat);

            ModelVisual3D triangle = new ModelVisual3D();
            triangle.Content = model;
            
            scene.Children.Add(triangle);
        }
    }
}
