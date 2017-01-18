using System;
using System.Data;
using System.Diagnostics;
using System.Media;
using System.Collections;
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
        private Pontuacao notas;

        private ArrayList registrosRadar;

        private DataRow eventoAtual;
        private DataRow duplaAtual;
        private DataRow duplasEventoAtual;
        private DataRow categoriaAtual;
        private DataRow atleta1;
        private DataRow atleta2;

        int v = 100;

        private int idAtleta1;
        private int idAtleta2;
        private int idEvento;
        private int idDupla;
        private int idDuplasEvento;

        private int categoriaVelocidadeMinima = 0;
        private int ataquesAtleta1 = 0;
        private int ataquesAtleta2 = 0;
        private int ataquesTotal = 0;
        private int somaAtaquesAtleta1 = 0;
        private int somaAtaquesAtleta2 = 0;
        private int somaAtaquesTotal = 0;
        private double potenciaAtleta1 = 0;
        private double potenciaAtleta2 = 0;
        private double potenciaTotalMedia = 0;

        private int notaJuizAtleta1;
        private int notaJuizAtleta2;

        public MainForm()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized; //inicializa maximizado
            KeyPreview = true;

            this.notas = new Pontuacao();
            this.cronometro = new Stopwatch();
            this.cronTimer = new Timer();
            this.cronTimer.Interval = 10; //10 ms
            this.cronTimer.Tick += updateCronometroText;

            radar = new ProIISensor(/*RadarModel.StalkerRadarRS232*/); //we need to add a RadarModel.StalkerRadarRS232 / RadarModel.StalkerRadarRS485 enum
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                radar.openSerialPort("COM4");
            } catch (Exception) {
                //MessageBox.Show("O radar não está conectado ou está na porta errada.", "Radar não encontrado...", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //IMPORTANT: o atleta1 (esquerda na exibição dos atletas) é o atleta da direção in
        private void Radar_SpeedReceived(object sender, RadarSpeedEventArgs e)
        {
            if (cronometro.IsRunning == false) return;

            SoundPlayer s;
            int velocidade = e.pSpeed;
            int direcao = e.direction;
            long tempo = cronometro.ElapsedTicks;

            if(velocidade >= categoriaVelocidadeMinima)
            {
                if (direcao == 0) //ataque na direcao in
                {
                    ++ataquesAtleta1;
                    somaAtaquesAtleta1 += velocidade;
                    potenciaAtleta1 = (double)somaAtaquesAtleta1 / ataquesAtleta1;

                    registrosRadar.Add(new SpeedRecord(idAtleta1, idDupla, idEvento, idDuplasEvento, velocidade, direcao, tempo));
                } else //ataque na direção out
                {
                    ++ataquesAtleta2;
                    somaAtaquesAtleta2 += velocidade;
                    potenciaAtleta2 = (double)somaAtaquesAtleta2 / ataquesAtleta2;

                    registrosRadar.Add(new SpeedRecord(idAtleta2, idDupla, idEvento, idDuplasEvento, velocidade, direcao, tempo));
                }

                ++ataquesTotal;
                somaAtaquesTotal += velocidade;
                potenciaTotalMedia = (double)somaAtaquesTotal / ataquesTotal;

                UpdateWindowContent(velocidade, direcao);

                if (velocidade < 60)
                {
                    s = new SoundPlayer(Properties.Resources.velocidade50);
                    s.Play();
                }
                else if (velocidade < 70)
                {
                    s = new SoundPlayer(Properties.Resources.velocidade60);
                    s.Play();
                }
                else if (velocidade < 80)
                {
                    s = new SoundPlayer(Properties.Resources.velocidade70);
                    s.Play();
                }
                else if (velocidade < 90)
                {
                    s = new SoundPlayer(Properties.Resources.velocidade80);
                    s.Play();
                }
                else if (velocidade < 150)
                {
                    s = new SoundPlayer(Properties.Resources.velocidade90);
                    s.Play();
                }
            }
        }

        private void UpdateWindowContent(int velocidade, int direcao)
        {
            this.label6.Text = string.Format("{0:000}", ataquesTotal);
            this.label7.Text = string.Format("{0:00.00}", potenciaTotalMedia);
            this.label10.Text = string.Format("{0}", velocidade);
            this.pictureBox3.Image = direcao == 0 ? Properties.Resources.ataque_in : Properties.Resources.ataque_out;
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

        private void Reset_Window_Content ()
        {
            this.cronometro = new Stopwatch();

            this.duplaAtual = null;
            this.duplasEventoAtual = null;
            this.atleta1 = null;
            this.atleta2 = null;

            ataquesAtleta1 = 0;
            ataquesAtleta2 = 0;
            ataquesTotal = 0;
            somaAtaquesAtleta1 = 0;
            somaAtaquesAtleta2 = 0;
            somaAtaquesTotal = 0;
            potenciaAtleta1 = 0;
            potenciaAtleta2 = 0;
            potenciaTotalMedia = 0;

            this.label2.Text = "00:00.00";
            this.label9.Text = "Jogador 1 (ID) x (ID) Jogador 2 - Categoria";
            this.textBox8.Text = "00";
            this.label7.Text = "00,00";
            this.label6.Text = "000";
            this.label10.Text = "000";
            this.pictureBox3.Image = null;
        }

        private void updateCronometroText(object sender, EventArgs e)
        {
            if(this.cronometro.IsRunning)
            {
                this.label2.Text = new DateTime(this.cronometro.Elapsed.Ticks).ToString("mm:ss.ff");
                
                if(this.cronometro.ElapsedMilliseconds >= 30000)
                {
                    this.cronTimer.Stop();
                    this.cronometro.Stop();
                    SoundPlayer s = new SoundPlayer(Properties.Resources.termino);
                    s.Play();

                    this.duplasEventoAtual["finalizado"] = 1;
                    this.duplaseventoTableAdapter1.Update(this.duplasEventoAtual); //marca a dupla como finalizada

                    //continue


                    //cleanup
                    if(MessageBox.Show("Partida Finalizada!", "Tempo Esgtado", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        int sequencias = Int32.Parse(textBox8.Text);
                        int ataques = ataquesTotal;
                        double velocidade = potenciaTotalMedia;

                        double pontuacao = 0;

                        if (sequencias < 8) pontuacao += 150;
                        else if (sequencias > 30) pontuacao -= 200;
                        else pontuacao += notas.Sequencia[sequencias];

                        if (ataques >= 220) pontuacao += 200;
                        else if(ataques >= 1) pontuacao += notas.Ataque[ataques];

                        if (velocidade >= 75) pontuacao += 300;
                        else pontuacao += notas.Velocidade[string.Format("{0:00.0}", velocidade)];

                        int atkmenor, atkmaior;

                        if(ataquesAtleta1 < ataquesAtleta2) { atkmenor = ataquesAtleta1; atkmaior = ataquesAtleta2; }
                        else { atkmenor = ataquesAtleta2; atkmaior = ataquesAtleta1; }

                        if(atkmaior > 0)
                        {
                            pontuacao += ((double)atkmenor / atkmaior) * ataquesTotal * 0.681819;
                        }

                        MessageBox.Show("Nota: " + string.Format("{0:000.00}", pontuacao));
                        Reset_Window_Content();
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (eventoAtual == null || duplaAtual == null)
            {
                MessageBox.Show("Você deve selecionar um Evento e Dupla.", "Evento ou Dupla não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //start / stop cronometro
            if (this.cronometro.IsRunning == true)
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
                    Radar_SpeedReceived(null, new RadarSpeedEventArgs(v--, (byte)(v % 2)));
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
                registrosRadar = new ArrayList();
                duplasEventoAtual = this.duplaseventoTableAdapter1.GetDuplaById(this.duplasForm.getSelectedDuplaEventoId()).Rows[0];

                idDupla = duplasForm.getSelectedDuplaId();
                idDuplasEvento = duplasForm.getSelectedDuplaEventoId();

                duplaAtual = this.duplaTableAdapter1.GetDuplaById(idDupla).Rows[0];

                idAtleta1 = Int32.Parse(duplaAtual["idatl1"].ToString());
                idAtleta2 = Int32.Parse(duplaAtual["idatl2"].ToString());

                atleta1 = this.atletaTableAdapter1.GetAtletaById(idAtleta1).Rows[0];
                atleta2 = this.atletaTableAdapter1.GetAtletaById(idAtleta2).Rows[0];

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
                idEvento = eventoForm.GetSelectedEventId();

                eventoAtual = this.eventoTableAdapter1.GetById(idEvento).Rows[0];
                categoriaAtual = this.categoriaTableAdapter1.GetCategoriaById(Int32.Parse(eventoAtual["idcategoria"].ToString())).Rows[0];
                categoriaVelocidadeMinima = Int32.Parse(categoriaAtual["velocidade"].ToString());
            } else
            {
                eventoAtual = null;
            }
        }
    }
}
