using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plateia
{
    public partial class NotasJuiz : Form
    {
        private int notaAtleta1;
        private int notaAtleta2;
        private MainForm MainForm;

        public NotasJuiz(MainForm mainForm)
        {
            MainForm = mainForm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!", "Nota inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MainForm.NotaJuizAtleta1 = (int)Double.Parse(textBox1.Text);
            MainForm.NotaJuizAtleta2 = (int)Double.Parse(textBox2.Text);

            this.Dispose();
        }
    }
}
