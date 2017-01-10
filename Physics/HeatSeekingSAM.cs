using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagerSimulation1.Physics
{
    public class HeatSeekingSAM : SAM
    {
        private const int MaximumSeekingDistance = 400;

        //TODO ZIvotni vek
        private int life;

        public HeatSeekingSAM(int xLocation, Vector direction, long startAt = 0) 
            : base(xLocation, direction, startAt)
        {
            this.life = 100;
        }

        public override void Fly(IList<FlyingObject> objects, int frameCount = 1)
        {
            if (this.frameNumber >= this.startFrame && this.frameNumber - this.startFrame < life)
            {
                //TODO Uvesti Plane i Missile bazne klase?
                var distances = new Dictionary<double, SmallPlane>();
                foreach (var obj in objects.OfType<SmallPlane>())
                {
                    var distance = (this.location - obj.Location).GetScalarValue();

                    if (distance > MaximumSeekingDistance)
                        continue;

                    if (!distances.ContainsKey(distance))
                        distances.Add(distance, obj);
                }

                if (distances.Count > 0)
                {
                    double minimalDistance = distances.Min(d => d.Key);
                    SmallPlane target = distances[minimalDistance];

                    //Change distance

                    var intensity = this.direction.GetScalarValue();
                    Vector targetDirection = (target.Location - this.location).Normalize() * intensity;

                    //Jer je kvadratna rapodela odraza, opada sa kvadr rastojanja
                    var constant = Math.Pow(MaximumSeekingDistance, 2); ;
                    var heatReflection = (constant - Math.Pow(minimalDistance, 2)) / constant;
                    //this.direction = this.direction * (0.9 + 0.1 - heatReflection / 10) + targetDirection * (0.1 + heatReflection / 10);
                    this.direction = this.direction * (1 - 0.1 * heatReflection) + targetDirection * (0.1 * heatReflection);

                    //FIX SPEED
                    this.direction = direction.Normalize() * intensity;
                }
            }

            if (this.frameNumber - this.startFrame > 2 * life)
                this.size = new Size(0, 0);

            base.Fly(objects, frameCount);
        }

        public override void Draw(Graphics g, Rectangle border)
        {
            //TODO Sistem brisanja iz sistema umesto ovoga
            if (this.size.Height > 0 && this.size.Width > 0)
            {
                Rectangle r = new Rectangle(this.GetDrawLocation(border), this.size);
                g.FillRectangle(Brushes.Blue, r);
            }
        }
    }
}
