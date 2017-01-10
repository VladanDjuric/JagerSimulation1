using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JagerSimulation1
{
    //TODO
    //  Testirati Clone() sa kopi konstruktorima
    //  Testirati serijalizaciju i probati napraviti nesto dobro
    //  Napraviti simulaciju nadletanja leteceg objekta i vodjenih raketa
    public partial class MainForm : Form
    {
        private MainController controller;

        public MainForm()
        {
            InitializeComponent();

            this.controller = new MainController(this.pnlGraphics);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //TODO Deserialize (nove klase, ceo sistem)
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO Serialize
        }

        private void btnStartSAM_Click(object sender, EventArgs e)
        {
            this.controller.TestSAM();
        }

        private void btnHeatSAM_Click(object sender, EventArgs e)
        {
            this.controller.TestHeatSAM();
        }
    }
}
