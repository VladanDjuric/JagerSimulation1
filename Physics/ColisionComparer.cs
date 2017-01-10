using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagerSimulation1.Physics
{
    class ColisionComparer : IEqualityComparer<Vector>
    {
        private double tolerance;

        public ColisionComparer(double tolerance)
        {
            this.tolerance = tolerance;
        }

        public bool Equals(Vector x, Vector y)
        {
            var val = this.IsEqual(x.X, y.X) && this.IsEqual(x.Y, y.Y);
            return val;
        }

        private bool IsEqual(double x, double y)
        {
            return Math.Abs(x - y) <= this.tolerance;
        }

        public int GetHashCode(Vector obj)
        {
            //TODO Napraviti bolje
            return 0;
        }
    }
}
