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
    public partial class NewHighscoreForm : Form
    {
        private int _score = 0;

        public NewHighscoreForm(int score)
        {
            InitializeComponent();
            labelHighscore.Text = $"Dein Highscore: {score}";
            _score = score;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HighscoreVerwaltung.FügeNeuenHighscoreHinzu(textBoxName.Text, _score, DateTime.Now);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
