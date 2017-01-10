using JagerSimulation1.Physics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JagerSimulation1
{
    class MainController
    {
        private Control parentControl;
        private List<FlyingObject> objects;

        private BackgroundWorker worker;
        private int redFrame;
        
        public MainController(Control control)
        {
            control.Paint += PaintHandler;
            this.parentControl = control;
            this.objects = new List<FlyingObject>();
            this.worker = new BackgroundWorker();
            this.worker.DoWork += Worker_DoWork;
            this.redFrame = 0;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                foreach (var obj in this.objects)
                    obj.Fly(this.objects, 1);

                this.DetectColisions();

                this.parentControl.Invoke(new Action(() => this.parentControl.Refresh()));
                Thread.Sleep(50);
            }
        }

        private void DetectColisions()
        {
            var colisions = new Dictionary<Vector, List<FlyingObject>>(new ColisionComparer(5));

            var planes = objects.OfType<SmallPlane>().Where(p => p.IsAlive);
            var missiles = objects.OfType<SAM>().Where(p => p.IsAlive && !p.HasColided);

            foreach (var obj in missiles)
                this.AddColisionData(obj, colisions);

            bool detected = false;
            foreach (var obj in planes)
                if (this.AddColisionData(obj, colisions))
                {
                    detected = true;

                    foreach (var colided in colisions[obj.Location])
                        colided.ColisionDetected();
                }

            if (detected)
                this.redFrame = 4;
        }

        private bool AddColisionData(FlyingObject obj, IDictionary<Vector, List<FlyingObject>> dictionary)
        {
            bool hasColision = false;
            if (!dictionary.ContainsKey(obj.Location))
                dictionary.Add(obj.Location, new List<FlyingObject>());
            else
                hasColision = true;

            dictionary[obj.Location].Add(obj);
            return hasColision;
        }

        public void TestSAM()
        {
            this.AddPlanes();
            this.AddSAM();

            this.worker.RunWorkerAsync();
        }

        public void TestHeatSAM()
        {
            this.AddPlanes();
            this.AddHeatSAM();

            this.worker.RunWorkerAsync();
        }

        private void AddPlanes()
        {
            Vector loc1 = new Vector(0, parentControl.Height / 5 * 4);
            Vector dir1 = new Vector(6, 0.4);
            this.objects.Add(new SmallPlane(loc1, dir1, 10));

            Vector loc2 = new Vector(0, parentControl.Height / 5 * 3);
            Vector dir2 = new Vector(5, 0.6);
            this.objects.Add(new SmallPlane(loc2, dir2, 12, 15));
  
            Vector loc3 = new Vector(0, parentControl.Height / 5 * 4.3);
            Vector dir3 = new Vector(4, 0);
            this.objects.Add(new SmallPlane(loc3, dir3, 20, 20));
        }

        private void AddSAM()
        {
            this.objects.Add(new SAM(50, new Vector(5, 15)));
            this.objects.Add(new SAM(50, new Vector(4, 13)));
            this.objects.Add(new SAM(50, new Vector(3, 12)));

            this.objects.Add(new SAM(100, new Vector(5, 12)));
            this.objects.Add(new SAM(150, new Vector(5, 11)));
            this.objects.Add(new SAM(200, new Vector(-15, 10)));
            this.objects.Add(new SAM(225, new Vector(-5, 14)));
            this.objects.Add(new SAM(250, new Vector(-105, 16)));
            this.objects.Add(new SAM(35, new Vector(20, 10)));
            this.objects.Add(new SAM(100, new Vector(-50, 14)));
            this.objects.Add(new SAM(300, new Vector(30, 8)));
        }

        private void AddHeatSAM()
        {
            this.objects.Add(new HeatSeekingSAM(100, new Vector(5, 10)));
            this.objects.Add(new HeatSeekingSAM(200, new Vector(5, 10), 15));
            this.objects.Add(new HeatSeekingSAM(500, new Vector(4, 8), 25));

            this.objects.Add(new HeatSeekingSAM(200, new Vector(3, 10), 25));
            this.objects.Add(new HeatSeekingSAM(400, new Vector(4, 10), 30));
            this.objects.Add(new HeatSeekingSAM(700, new Vector(5, 8), 35));
        }

        private void PaintHandler(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (this.redFrame > 0)
            {
                this.redFrame--;

                if (this.redFrame % 2 == 0)
                    g.Clear(Color.DarkRed);
                else
                    g.Clear(Color.IndianRed);
            }
            else
                g.Clear(Color.White);

            foreach (var obj in this.objects)
                obj.Draw(g, this.parentControl.DisplayRectangle);
        }
    }
}
