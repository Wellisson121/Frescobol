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
        private MainForm MainForm;

        public NotasJuiz (MainForm mainForm)
        {
            MainForm = mainForm;
            InitializeComponent();
        }

        //checar se o cara nao fechou a janela sem digitar as notas
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!", "Nota inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nota1 = Convert.ToInt32(textBox1.Text);
            int nota2 = Convert.ToInt32(textBox2.Text);

            if(nota1 >= 0 && nota1 <= 100 && nota2 >= 0 && nota2 <= 100)
            {
                MainForm.NotaJuizAtleta1 = (int)Double.Parse(textBox1.Text);
                MainForm.NotaJuizAtleta2 = (int)Double.Parse(textBox2.Text);

                this.Dispose();
            }
            else
            {
                MessageBox.Show("As notas devem estar entre 0 e 100!");
            }
        }
    }
}
