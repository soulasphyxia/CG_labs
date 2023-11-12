using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace lab12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DispatcherTimer timer;
        private RotateTransform3D rotateY;
        private TranslateTransform3D translateX;
        private Transform3DGroup transform;
        private AxisAngleRotation3D axisYRotation;
        List<Planet> planets = new List<Planet>();

        public MainWindow()
        {
            InitializeComponent();
        }

   

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval += new TimeSpan(10000);
          
            planets.Add(new Planet(Mercury, 1));
            planets.Add(new Planet(Venus, 0.8));
            planets.Add(new Planet(Earth, 0.75));
            planets.Add(new Planet(Mars, 0.6));
            planets.Add(new Planet(Jupiter, 0.3));
            planets.Add(new Planet(Saturn, 0.4));
            planets.Add(new Planet(Uranus, 0.5));
            planets.Add(new Planet(Neptune, 0.55));


            

            timer.Start();

        }


        private void timer_Tick(object sender, EventArgs e)
        {
            foreach(Planet planet in planets)
            {
                planet.Rotate();
            }  
               
        }



        
    }
}
