using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp;
using System.Drawing.Printing;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace Plateia
{
    public partial class MainForm : Form
    {
        private Stopwatch cronometro;
        private Timer cronTimer;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized; //inicializa maximizado

            this.cronometro = new Stopwatch();
            this.cronTimer = new Timer();
            this.cronTimer.Interval = 10; //10 ms
            this.cronTimer.Tick += updateCronometroText;
            /* PrintDocument p = new PrintDocument();
             p.DocumentName = "Radar Ball";
             this.printPreviewDialog1.Document = p;
             this.printPreviewDialog1.ShowDialog();
             */
            //Estatisticas_Partida(); //Estudar como fazer o documento
        }

        private void Estatisticas_Partida ()
        {
            Document document = new Document();
            document.Info.Title = "Radar Ball - Registro de Partida";
            document.Info.Subject = "Relatório da partida.";

            Style style = document.Styles["Normal"];
            style.Font.Name = "Helvetica";

            Section section = document.AddSection();
            Table table = section.AddTable();
            table.Style = "Normal";
            table.Borders.Width = 0.25;
            table.Rows.LeftIndent = 0;

            Column column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("3.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;

            row.Cells[0].AddParagraph("Item");
            row.Cells[1].AddParagraph("Item2");
            row.Cells[2].AddParagraph("Item3");

            //table.SetEdge(0, 0, 6, 2, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75, MigraDoc.DocumentObjectModel.Color.Empty);

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();

            pdfRenderer.PdfDocument.Save("teste.pdf");
            Process.Start("teste.pdf");
        }

        private void updateCronometroText(object sender, EventArgs e)
        {
            if(this.cronometro.IsRunning)
            {
                this.label2.Text = new DateTime(this.cronometro.Elapsed.Ticks).ToString("mm:ss.ff");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //start / stop cronometro
            if(this.cronometro.IsRunning == true)
            {
                this.cronTimer.Stop();
                this.cronometro.Stop();
                SoundPlayer s = new SoundPlayer(Plateia.Properties.Resources.pausa);
                s.Play();
            } else
            {
                this.cronTimer.Start();
                this.cronometro.Start();
                SoundPlayer s = new SoundPlayer(Plateia.Properties.Resources.inicio);
                s.Play();

                this.textBox8.Text = ((Int32.Parse(this.textBox8.Text) + 1) + "").PadLeft(2, '0');
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void teste1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void teste1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
