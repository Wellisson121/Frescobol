using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'frescobol_system_dbDataSet.categoria' table. You can move, or remove it, as needed.
            this.categoriaTableAdapter.Fill(this.frescobol_system_dbDataSet.categoria);
            // TODO: This line of code loads data into the 'frescobol_system_dbDataSet.dupla' table. You can move, or remove it, as needed.
            this.duplaTableAdapter.Fill(this.frescobol_system_dbDataSet.dupla);
            // TODO: This line of code loads data into the 'frescobol_system_dbDataSet.atleta' table. You can move, or remove it, as needed.
            this.atletaTableAdapter.Fill(this.frescobol_system_dbDataSet.atleta);

            this.comboBox1.SelectedItem = null;
            this.comboBox2.SelectedItem = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "Imagem JPG|*.jpg|Imagem JPEG|*.jpeg|Imagem PNG|*.png|Imagem BMP|*.bmp";

            if(this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox3.Text = this.openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!");
                return;
            }

            this.atletaTableAdapter.Insert(textBox1.Text, textBox2.Text, openFileDialog1.SafeFileName);
            this.atletaTableAdapter.Fill(this.frescobol_system_dbDataSet.atleta);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            if (cmb.SelectedValue == null) return;

            int selectedValue = (int)cmb.SelectedValue;

            this.textBox4.Text = "" + selectedValue;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            if (cmb.SelectedValue == null) return;

            int selectedValue = (int)cmb.SelectedValue;

            this.textBox5.Text = "" + selectedValue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox4.Text == "" || this.textBox5.Text == "")
            {
                MessageBox.Show("Você deve selecionar dois atletas!");
                return;
            }

            this.duplaTableAdapter.Insert(Int32.Parse(this.textBox4.Text), this.comboBox1.Text, Int32.Parse(this.textBox5.Text), this.comboBox2.Text);
            this.duplaTableAdapter.Fill(this.frescobol_system_dbDataSet.dupla);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(this.textBox6.Text == "" || this.textBox7.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!");
                return;
            }

            this.categoriaTableAdapter.Insert(this.textBox6.Text, Int32.Parse(this.textBox7.Text));
            this.categoriaTableAdapter.Fill(this.frescobol_system_dbDataSet.categoria);
        }
    }
}
