using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaffeeGame
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            //blende StartForm vorübergehend aus
            this.Visible = false;
            form.ShowDialog();
            this.Visible = true;
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HighscoreVerwaltung.ZeigeHighscoreAn();
        }
    }
}
