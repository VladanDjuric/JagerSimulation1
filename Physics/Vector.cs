using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagerSimulation1.Physics
{
    public class Vector
    {
        private double x;
        private double y;

        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector(Vector v)
            :this(v.x, v.y)
        {
        }

        public Vector(int x)
            :this(x,x)
        {
        }

        public double X
        {
            get { return this.x; }
        }

        public double Y
        {
            get { return this.y; }
        }

        public Vector Normalize()
        {
            double distance = Math.Sqrt(this.x * this.x + this.y * this.y);

            this.x = this.x / distance;
            this.y = this.y / distance;

            return this;
        }

        public double GetScalarValue()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y);
        }

        public static Vector operator + (Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector operator - (Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector operator * (Vector v1, double d)
        {
            return new Vector(v1.x * d, v1.y * d);
        }

        public static implicit operator System.Drawing.Point(Vector v)
        {
            return new System.Drawing.Point((int)Math.Round(v.x), (int)Math.Round(v.y));
        }
    }
}
