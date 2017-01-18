using System;
using System.Data;
using System.Diagnostics;
using System.Media;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using StalkerRadarLib;

namespace Plateia
{
    public partial class MainForm : Form
    {
        private Stopwatch cronometro;
        private Timer cronTimer;
        private ProIISensor radar;
        private EventoForm eventoForm;
        private DuplasForm duplasForm;

        private DataRow eventoAtual;
        private DataRow duplaAtual;
        private DataRow duplasEventoAtual;
        private DataRow categoriaAtual;
        private DataRow atleta1;
        private DataRow atleta2;

        public MainForm()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized; //inicializa maximizado
            KeyPreview = true;

            this.cronometro = new Stopwatch();
            this.cronTimer = new Timer();
            this.cronTimer.Interval = 10; //10 ms
            this.cronTimer.Tick += updateCronometroText;

            radar = new ProIISensor(/*RadarModel.StalkerRadarRS232*/); //we need to add a RadarModel.StalkerRadarRS232 / RadarModel.StalkerRadarRS485 enum
            radar.SpeedReceived += Radar_SpeedReceived;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                radar.openSerialPort("COM4");
            } catch (Exception) {
                MessageBox.Show("O radar não está conectado ou está na porta errada.", "Radar não encontrado...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Radar_SpeedReceived(object sender, RadarSpeedEventArgs e)
        {
            throw new NotImplementedException();
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
                
                if(this.cronometro.ElapsedMilliseconds >= 30)
                {
                    this.cronTimer.Stop();
                    this.cronometro.Stop();
                    SoundPlayer s = new SoundPlayer(Properties.Resources.termino);
                    s.Play();

                    this.duplasEventoAtual["finalizado"] = 1;
                    this.duplaseventoTableAdapter1.Update(this.duplasEventoAtual);

                    //continue


                    //cleanup
                    if(MessageBox.Show("Partida Finalizada!", "Tempo Esgtado", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.cronometro = new Stopwatch();
                        this.label2.Text = "00:00.00";
                        this.label9.Text = "Jogador 1 (ID) x (ID) Jogador 2 - Categoria";
                        this.duplaAtual = null;
                        this.atleta1 = null;
                        this.atleta2 = null;
                        this.duplasEventoAtual = null;
                    }
                }
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

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.F5:
                    //w.o. na dupla selecionada
                    break;
                case Keys.F7:
                    if(eventoForm == null || eventoForm.IsDisposed)
                    {
                        eventoForm = new EventoForm();
                        eventoForm.Show();
                        eventoForm.Disposed += EventoForm_Disposed;
                    }
                    break;
                case Keys.F8:
                    if(duplasForm == null || duplasForm.IsDisposed) {
                        if(eventoAtual == null)
                        {
                            MessageBox.Show("Você deve selecionar um evento antes.", "Evento não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        duplasForm = new DuplasForm(Int32.Parse(eventoAtual["idevento"].ToString()));
                        duplasForm.Show();
                        duplasForm.Disposed += DuplasForm_Disposed;
                    }
                    break;
                case Keys.F9:
                    if(eventoAtual == null || duplaAtual == null)
                    {
                        MessageBox.Show("Você deve selecionar um Evento e Dupla.", "Evento ou Dupla não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    label2_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void DuplasForm_Disposed(object sender, EventArgs e)
        {
            if(duplasForm.getSelectedDuplaId() > 0 && duplasForm.getSelectedDuplaEventoId() > 0)
            {
                duplasEventoAtual = this.duplaseventoTableAdapter1.GetDuplaById(this.duplasForm.getSelectedDuplaEventoId()).Rows[0];
                duplaAtual = this.duplaTableAdapter1.GetDuplaById(this.duplasForm.getSelectedDuplaId()).Rows[0];
                atleta1 = this.atletaTableAdapter1.GetAtletaById(Int32.Parse(duplaAtual["idatl1"].ToString())).Rows[0];
                atleta2 = this.atletaTableAdapter1.GetAtletaById(Int32.Parse(duplaAtual["idatl2"].ToString())).Rows[0];

                this.label9.Text = atleta1["apelido"] + " (" + atleta1["idatleta"].ToString().PadLeft(3, '0') + ") x (" + atleta2["idatleta"].ToString().PadLeft(3, '0') + ") " + atleta2["apelido"] + " - " + categoriaAtual["nome"];
            } else
            {
                duplaAtual = null;
            }
        }

        private void EventoForm_Disposed(object sender, EventArgs e)
        {
            if (eventoForm.GetSelectedEventId() > 0)
            {
                eventoAtual = this.eventoTableAdapter1.GetById(this.eventoForm.GetSelectedEventId()).Rows[0];
                categoriaAtual = this.categoriaTableAdapter1.GetCategoriaById(Int32.Parse(eventoAtual["idcategoria"].ToString())).Rows[0];
            } else
            {
                eventoAtual = null;
            }
        }
    }
}
