using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagerSimulation1.Physics
{
    public abstract class FlyingObject
    {
        protected Vector location;
        protected Vector direction;
        protected long frameNumber;
        protected long startFrame;
        protected bool hasColided;

        public FlyingObject(Vector location, Vector direction, long startAt = 0)
        {
            this.location = location;
            this.direction = direction;
            this.frameNumber = 0;
            this.startFrame = startAt;
            this.hasColided = false;
        }

        public bool IsAlive
        {
            get { return this.frameNumber >= this.startFrame; }
        }

        public bool HasColided
        {
            get { return this.hasColided; }
        }

        public Vector Location
        {
            get { return this.location; }
        }

        //TODO Ovo overrideovati ako treba da se menja Direction posle kolizije!
        public virtual void Fly(IList<FlyingObject> objects, int frameCount = 1)
        {
            if (this.IsAlive)
                this.location += this.direction;

            this.frameNumber += frameCount;
        }

        public Point GetDrawLocation(Rectangle border)
        {
            return new Vector(this.location.X, border.Height - this.location.Y);
        }

        public abstract void Draw(Graphics g, Rectangle border);

        //TODO Na detektovanje kolizije avion pada
        //a SAM moze da se obrise. Posle kontroler moze da preskace sve destroy-ovane objekte
        //Ili da postoji referenca na kontroler, pa da se izbacuje... ili neki event, to nije lose
        public virtual void ColisionDetected()
        {
            this.hasColided = true;
        }
    }
}
