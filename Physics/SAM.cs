using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagerSimulation1.Physics
{
    public class SAM : FlyingObject
    {
        protected Size size;

        public SAM(int xLocation, Vector direction, long startAt = 0)
            :base(new Vector(xLocation, 0), direction, startAt)
        {
            this.size = new Size(3, 3);
        }

        public override void ColisionDetected()
        {
            //TODO Napraviti sistem brisanja iz sistema!
            base.ColisionDetected();

            this.size = new Size(0, 0);
            this.direction = new Vector(0, 0);
        }

        public override void Draw(Graphics g, Rectangle border)
        {
            //TODO Sistem brisanja iz sistema umesto ovoga
            if (this.size.Height > 0 && this.size.Width > 0)
            {
                Rectangle r = new Rectangle(this.GetDrawLocation(border), this.size);
                g.FillRectangle(Brushes.Red, r);
            }
        }
    }
}
