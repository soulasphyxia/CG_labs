using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace lab12
{
    internal class Planet
    {
        private ModelVisual3D _planet;
        private double angle;
        private AxisAngleRotation3D axisYRotation;
        public Planet(ModelVisual3D _planet, double angle)
        {
            this.angle = angle;
            RotateTransform3D rotateY = new RotateTransform3D();
            axisYRotation = new AxisAngleRotation3D();
            axisYRotation.Angle = 0;
            axisYRotation.Axis = new Vector3D(0, 1, 0);
            rotateY.CenterZ = -10;
            rotateY.CenterX = 4.5;
            rotateY.Rotation = axisYRotation;
            Transform3DGroup transform = new Transform3DGroup();
            _planet.Transform = transform;
            transform.Children.Add(rotateY);
        }

        public ModelVisual3D getPlanet
        {
            get { return _planet; }

        }
        public double getAngle
        {
            get
            {
                return angle;
            }
        }


        public void Rotate()
        {
            axisYRotation.Angle += angle;
        }

    }
}
