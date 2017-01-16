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
        private TextBox selectedDateBox = null;

        public MainForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'frescobol_system_dbDataSet.duplasevento' table. You can move, or remove it, as needed.
            //this.duplaseventoTableAdapter.Fill(this.frescobol_system_dbDataSet.duplasevento);
            // TODO: This line of code loads data into the 'frescobol_system_dbDataSet.evento' table. You can move, or remove it, as needed.
            this.eventoTableAdapter.Fill(this.frescobol_system_dbDataSet.evento);
            // TODO: This line of code loads data into the 'frescobol_system_dbDataSet.categoria' table. You can move, or remove it, as needed.
            this.categoriaTableAdapter.Fill(this.frescobol_system_dbDataSet.categoria);
            // TODO: This line of code loads data into the 'frescobol_system_dbDataSet.dupla' table. You can move, or remove it, as needed.
            this.duplaTableAdapter.Fill(this.frescobol_system_dbDataSet.dupla);
            // TODO: This line of code loads data into the 'frescobol_system_dbDataSet.atleta' table. You can move, or remove it, as needed.
            this.atletaTableAdapter.Fill(this.frescobol_system_dbDataSet.atleta);

            this.comboBox1.SelectedItem = null;
            this.comboBox2.SelectedItem = null;
            this.comboBox3.SelectedItem = null;
            this.comboBox4.SelectedItem = null;
            this.comboBox5.SelectedItem = null;
        }

        #region atleta
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

            //clean up
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
        }

        #endregion

        #region dupla
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

        //cadastrar dupla
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox4.Text == "" || this.textBox5.Text == "")
            {
                MessageBox.Show("Você deve selecionar dois atletas!");
                return;
            }

            this.duplaTableAdapter.Insert(Int32.Parse(this.textBox4.Text), this.comboBox1.Text, Int32.Parse(this.textBox5.Text), this.comboBox2.Text, this.comboBox1.Text + " x " + this.comboBox2.Text);
            this.duplaTableAdapter.Fill(this.frescobol_system_dbDataSet.dupla);

            //clean up
            this.comboBox1.SelectedItem = null;
            this.comboBox2.SelectedItem = null;
            this.textBox4.Text = "";
            this.textBox5.Text = "";
        }

        #endregion

        #region categoria
        private void button4_Click(object sender, EventArgs e)
        {
            if(this.textBox6.Text == "" || this.textBox7.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!");
                return;
            }

            this.categoriaTableAdapter.Insert(this.textBox6.Text, Int32.Parse(this.textBox7.Text));
            this.categoriaTableAdapter.Fill(this.frescobol_system_dbDataSet.categoria);

            //clean up
            this.textBox6.Text = "";
            this.textBox7.Text = "";
        }

        #endregion

        #region evento
        private void textBox9_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
            this.selectedDateBox = this.textBox9;
        }

        private void textBox10_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
            this.selectedDateBox = this.textBox10;
        }

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if(this.selectedDateBox != null)
            {
                this.selectedDateBox.Text = e.Start.ToString("yyyy-MM-dd");
                this.monthCalendar1.Visible = false;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = false;

            if(this.textBox8.Text == "" || this.textBox9.Text == "" || this.textBox10.Text == "" || this.textBox11.Text == "" || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!");
            }

            //pega o id da categoria selecionada na combobox
            int selectedValue = (int)this.comboBox3.SelectedValue;

            this.eventoTableAdapter.Insert(DateTime.Parse(this.textBox9.Text),
                                           DateTime.Parse(this.textBox10.Text),
                                           DateTime.Parse(this.textBox9.Text + " " + this.textBox11.Text),
                                           this.textBox8.Text,
                                           selectedValue);

            this.eventoTableAdapter.Fill(this.frescobol_system_dbDataSet.evento);

            //fields clean up
            this.textBox8.Text = "";
            this.textBox9.Text = "";
            this.textBox10.Text = "";
            this.textBox11.Text = "";
            this.comboBox3.SelectedItem = null;
            this.comboBox4.SelectedItem = null;
        }

        #endregion

        #region duplas de evento

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            if (cmb.SelectedValue == null) return;
            int selectedValue = (int)cmb.SelectedValue;

            this.duplaseventoTableAdapter.FillBy(this.frescobol_system_dbDataSet.duplasevento, selectedValue);

            foreach(DataGridViewRow row in dataGridView4.Rows)
            {
                //foreach(DataGridViewCell cell in row.Cells)
                //{
                //    MessageBox.Show(cell.)
                //}
                //MessageBox.Show(row.Cells["iddupla"].Value.ToString());
                row.Cells["nomedupla"].Value = this.duplaTableAdapter.getNomeDupla((int)row.Cells["idduplaDataGridViewTextBoxColumn1"].Value);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(this.comboBox4.SelectedValue == null || this.comboBox5.SelectedValue == null)
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!");
                return;
            }

            int idevento = (int)this.comboBox4.SelectedValue;
            int iddupla = (int)this.comboBox5.SelectedValue;

            Object t = this.eventoTableAdapter.getHoraInicio(idevento);
            DateTime horainicio = DateTime.MinValue;

            if (t is DateTime) {
                horainicio = (DateTime)this.eventoTableAdapter.getHoraInicio(idevento);
            }

            if (horainicio == DateTime.MinValue) return; //tivemos um problema aqui na hora de pegar a hora de inicio do evento


            this.duplaseventoTableAdapter.Insert(idevento, iddupla, horainicio.AddMinutes(this.dataGridView4.RowCount * 10));
            this.duplaseventoTableAdapter.FillBy(this.frescobol_system_dbDataSet.duplasevento, idevento);

            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                row.Cells["nomedupla"].Value = this.duplaTableAdapter.getNomeDupla((int)row.Cells["idduplaDataGridViewTextBoxColumn1"].Value);
            }

            this.comboBox5.SelectedItem = null;
            //MessageBox.Show("" + idevento);
            //MessageBox.Show("" + iddupla);
            //MessageBox.Show(horainicio.ToString());
            //MessageBox.Show("" + this.dataGridView4.RowCount);
        }

        #endregion
    }
}
