using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagerSimulation1.Physics
{
    public class SmallPlane : FlyingObject
    {
        //TODO Iskoristiti Zastupnik-a koji ce odredjivati koji elementi se iscrvataju!
        private Size size;

        public SmallPlane(Vector location, Vector direction, int size, long startAt = 0)
            :base(location, direction, startAt)
        {
            this.size = new Size(size, size);
        }

        public override void Fly(IList<FlyingObject> objects, int frameCount = 1)
        {
            base.Fly(objects, frameCount);

            if (hasColided)
                this.direction = new Vector(this.direction.X / 1.05, this.direction.Y - 0.1);
        }

        public override void Draw(Graphics g, Rectangle border)
        {
            Rectangle r = new Rectangle(this.GetDrawLocation(border), this.size);
            g.FillEllipse(Brushes.Green, r);
        }
    }
}
