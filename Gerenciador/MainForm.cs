using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador
{
    public partial class MainForm : Form
    {
        private TextBox selectedDateBox = null;
        TakePicture picture;
        Bitmap atlFoto;

        public MainForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'frescobol_system_dbDataSet.resultadosevento' table. You can move, or remove it, as needed.
            //this.resultadoseventoTableAdapter.Fill(this.frescobol_system_dbDataSet.resultadosevento);
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
            this.comboBox6.SelectedItem = null;

            this.button7.Enabled = false;
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
            atlFoto.Dispose();
            atlFoto = null;
            pictureBox1.Image = Properties.Resources.no_image;
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

        private void button7_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Você deve preencher nome e apelido antes de tirar uma foto!");
                return;
            }

            if(picture == null || picture.IsDisposed)
            {
                picture = new TakePicture(this);
                picture.Show();
            }
        }

        public void copyTakenPicture ()
        {
            if (atlFoto != null) this.pictureBox1.Image.Dispose();
            atlFoto = picture.getTakenPicture().Clone() as Bitmap;

            this.pictureBox1.Image = atlFoto;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(this.comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Você deve selecionar um evento!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Document document = new Document();
            document.Info.Title = DateTime.Now.ToString("dd-MM-yyyy") + "_" + this.comboBox4.Text + "_duplas";
            document.Info.Subject = "Duplas do evento.";

            Style style = document.Styles["Normal"];
            style.Font.Name = "Helvetica";

            Section section = document.AddSection();

            Paragraph p = section.AddParagraph();
            p.Format.Alignment = ParagraphAlignment.Center;
            p.Format.Font.Bold = true;
            p.Format.Font.Size = 14;
            p.AddText(this.comboBox4.Text + " - Listagem de Jogos");

            section.AddParagraph();
            section.AddParagraph();

            Table t = section.AddTable();
            t.Style = "Normal";
            t.Borders.Width = 0.25;
            t.Format.Font.Size = 10;
            t.Rows.Height = 16;

            t.AddColumn("4cm").Format.Alignment = ParagraphAlignment.Center;
            t.AddColumn("4cm").Format.Alignment = ParagraphAlignment.Center;
            t.AddColumn("4cm").Format.Alignment = ParagraphAlignment.Center;
            t.AddColumn("4cm").Format.Alignment = ParagraphAlignment.Center;

            Row r1 = t.AddRow();
            r1.Format.Font.Bold = true;

            r1.Cells[0].AddParagraph("Data do Jogo");
            r1.Cells[1].AddParagraph("Hora do Jogo");
            r1.Cells[2].AddParagraph("Atleta (id)");
            r1.Cells[3].AddParagraph("Atleta (id)");


            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                int duplaid = Int32.Parse(row.Cells["idduplaDataGridViewTextBoxColumn1"].Value.ToString());
                DataRow dupla = this.duplaTableAdapter.GetDuplaById(duplaid)[0];
                int idatl1 = Int32.Parse(dupla["idatl1"].ToString());
                int idatl2 = Int32.Parse(dupla["idatl2"].ToString());
                DataRowCollection atletas = this.atletaTableAdapter.GetAtletasById(idatl1, idatl2).Rows;

                DateTime date = DateTime.Parse(row.Cells["horainicioDataGridViewTextBoxColumn1"].Value.ToString());

                Row r = t.AddRow();
                r.Cells[0].AddParagraph(date.ToString("dd/MM/yyyy"));
                r.Cells[1].AddParagraph(date.ToString("HH:mm:ss"));
                r.Cells[2].AddParagraph(atletas[0]["apelido"] + " (" + atletas[0]["idatleta"].ToString().PadLeft(3, '0') + ")");
                r.Cells[3].AddParagraph(atletas[1]["apelido"] + " (" + atletas[1]["idatleta"].ToString().PadLeft(3, '0') + ")");
            }
            /*
            r1.Cells[2].MergeRight = 1;
            r1.Cells[2].AddParagraph().AddFormattedText("Pontuação Total: " + string.Format("{0:0.00}", pontuacao));
            */

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();

            string fileName = document.Info.Title + ".pdf";

            //System.IO.Directory.CreateDirectory("relatorios");

            pdfRenderer.PdfDocument.Save(fileName);
            Process.Start(fileName);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            if (cmb.SelectedValue == null) return;
            int selectedValue = (int)cmb.SelectedValue;

            this.resultadoseventoTableAdapter.FillByIdEvento(this.frescobol_system_dbDataSet.resultadosevento, selectedValue);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.comboBox6.SelectedItem == null)
            {
                MessageBox.Show("Você deve selecionar um evento!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(this.dataGridView5.RowCount == 0)
            {
                return;
            }

            Document document = new Document();
            document.Info.Title = DateTime.Now.ToString("dd-MM-yyyy") + "_" + this.comboBox4.Text + "_resultados";
            document.Info.Subject = "Resultados do evento.";

            Style style = document.Styles["Normal"];
            style.Font.Name = "Helvetica";

            Section section = document.AddSection();

            Paragraph p = section.AddParagraph();
            p.Format.Alignment = ParagraphAlignment.Center;
            p.Format.Font.Bold = true;
            p.Format.Font.Size = 13;
            p.AddText(this.comboBox6.Text + " - Resultados");

            section.AddParagraph();
            section.AddParagraph();

            Table t = section.AddTable();
            t.Style = "Normal";
            t.Borders.Width = 0.25;
            t.Format.Font.Size = 9;
            t.Rows.Height = 16;

            t.AddColumn("0.75cm").Format.Alignment = ParagraphAlignment.Center;
            t.AddColumn("6.575cm").Format.Alignment = ParagraphAlignment.Center;
            t.AddColumn("6.575cm").Format.Alignment = ParagraphAlignment.Center;
            t.AddColumn("2cm").Format.Alignment = ParagraphAlignment.Center;

            int i = 1;

            foreach (DataGridViewRow row in this.dataGridView5.Rows)
            {
                Row r = t.AddRow();

                DataRow duplasevento = duplaseventoTableAdapter.GetById(Int32.Parse(row.Cells["idduplasevento"].Value.ToString())).Rows[0];
                DataRow dupla = duplaTableAdapter.GetDuplaById(Int32.Parse(duplasevento["iddupla"].ToString())).Rows[0];
                DataRowCollection jogadores = atletaTableAdapter.GetAtletasById(Int32.Parse(dupla["idatl1"].ToString()), Int32.Parse(dupla["idatl2"].ToString())).Rows;

                //posicao
                r.Cells[0].AddParagraph(i.ToString());

                //nome jogador1
                r.Cells[1].AddParagraph(jogadores[0]["nome"] + " - " + jogadores[0]["apelido"] + " (" + jogadores[0]["idatleta"].ToString().PadLeft(3, '0') + ")");

                //nome jogador2
                r.Cells[2].AddParagraph(jogadores[1]["nome"] + " - " + jogadores[1]["apelido"] + " (" + jogadores[1]["idatleta"].ToString().PadLeft(3, '0') + ")");

                //pontuacao
                r.Cells[3].AddParagraph(string.Format("{0:000.00}", (double)row.Cells["pontuacao"].Value));

                i++;
            }

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();

            string fileName = document.Info.Title + ".pdf";

            //System.IO.Directory.CreateDirectory("relatorios");

            pdfRenderer.PdfDocument.Save(fileName);
            Process.Start(fileName);
        }
    }
}
