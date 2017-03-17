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
using System.Globalization;
using MigraDoc.DocumentObjectModel.Shapes;
using System.Collections.Generic;
using System.Text;

namespace Plateia
{
    public partial class MainForm : Form
    {
        private static string plateia_version = "1.1.21";

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

        private DataRow atk_start, atk_end, seq_start, seq_end, pot_start, pot_end;

        int v = 400;

        private int idAtleta1;
        private int idAtleta2;
        private int idEvento;
        private int idDupla;
        private int idDuplasEvento;

        private int sequencias;
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

        private double equilibrio = 0;
        private int notaJuizAtleta1;
        private int notaJuizAtleta2;
        private double pontuacao;
        private double pontosAtaques;
        private double pontosSequencias;
        private double pontosPotencia;

        internal Dictionary<string, System.Drawing.Image> ImagensAtletas;

        public int NotaJuizAtleta1
        {
            set
            {
                notaJuizAtleta1 = value;
            }
        }

        public int NotaJuizAtleta2
        {
            set
            {
                notaJuizAtleta2 = value;
            }
        }

        public bool FinalizarEvento { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized; //inicializa maximizado
            //FormBorderStyle = FormBorderStyle.None;
            //TopMost = true;
            KeyPreview = true;

            this.notas = new Pontuacao();
            this.cronometro = new Stopwatch();
            this.cronTimer = new Timer();
            this.cronTimer.Interval = 10; //10 ms
            this.cronTimer.Tick += updateCronometroText;

            radar = new ProIISensor(/*RadarModel.StalkerRadarRS232*/); //we need to add a RadarModel.StalkerRadarRS232 / RadarModel.StalkerRadarRS485 enum
            radar.SpeedReceived += Radar_SpeedReceived;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Double d = Double.Parse("51.0", new CultureInfo("en-US"));
            try
            {

                radar.openSerialPort("COM4");
            }
            catch (Exception)
            {
                MessageBox.Show("O radar não está conectado ou está na porta errada. O programa será executado sem leituras do Radar.", "Radar não encontrado...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //IMPORTANT: o atleta1 (esquerda na exibição dos atletas) é o atleta da direção in
        private void Radar_SpeedReceived(object sender, RadarSpeedEventArgs e)
        {
            if (cronometro.IsRunning == false) return;

            SoundPlayer s;
            int velocidade = e.pSpeed;
            int direcao = e.direction;
            long tempo = cronometro.Elapsed.Ticks;

            if (velocidade >= categoriaVelocidadeMinima)
            {
                if (direcao == 0) //ataque na direcao in
                {
                    ++ataquesAtleta1;
                    somaAtaquesAtleta1 += velocidade;
                    potenciaAtleta1 = (double)somaAtaquesAtleta1 / ataquesAtleta1;

                    registrosRadar.Add(new SpeedRecord(idAtleta1, idDupla, idEvento, idDuplasEvento, velocidade, direcao, tempo));
                }
                else //ataque na direção out
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
            CrossThreadUtiliy.InvokeControlAction<Label>(label6, lbl => lbl.Text = string.Format("{0:000}", ataquesTotal));
            CrossThreadUtiliy.InvokeControlAction<Label>(label7, lbl => lbl.Text = string.Format("{0:00.00}", potenciaTotalMedia));
            CrossThreadUtiliy.InvokeControlAction<Label>(label10, lbl => lbl.Text = string.Format("{0:000}", velocidade));
            CrossThreadUtiliy.InvokeControlAction<PictureBox>(pictureBox3, pct => pct.Image = direcao == 0 ? Properties.Resources.ataque_in : Properties.Resources.ataque_out);
            //this.label6.Text = string.Format("{0:000}", ataquesTotal);
            //this.label7.Text = string.Format("{0:00.00}", potenciaTotalMedia);
            //this.label10.Text = string.Format("{0}", velocidade);
            //this.pictureBox3.Image = direcao == 0 ? Properties.Resources.ataque_in : Properties.Resources.ataque_out;
        }

        private void Estatisticas_Partida()
        {
            Document document = new Document();
            document.Info.Title = DateTime.Now.ToString("dd-MM-yyyy") + "_" + eventoAtual["nome"].ToString() + "_" + duplaAtual["nomedupla"].ToString();
            document.Info.Subject = "Relatório da partida.";

            Style style = document.Styles["Normal"];
            style.Font.Name = "Helvetica";

            Section section = document.AddSection();

            Paragraph paragraph = new Paragraph();
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.AddText("Página ");
            paragraph.AddPageField();
            paragraph.AddText(" de ");
            paragraph.AddNumPagesField();

            section.Headers.Primary.Add(paragraph);

            Paragraph title = section.AddParagraph();
            title.Format.Alignment = ParagraphAlignment.Center;
            title.AddFormattedText(eventoAtual["nome"].ToString(), TextFormat.Bold);

            section.AddParagraph();

            title = section.AddParagraph();
            title.Format.Alignment = ParagraphAlignment.Center;

            title.AddFormattedText("Data: ", TextFormat.Bold);
            title.AddText(DateTime.Now.ToString("dd/MM/yyyy"));
            title.AddFormattedText("\t\tHora: ", TextFormat.Bold);
            title.AddText(DateTime.Now.ToString("HH:mm:ss"));
            title.AddFormattedText("\t\tCategoria: ", TextFormat.Bold);
            title.AddText(categoriaAtual["nome"].ToString());

            section.AddParagraph();

            #region tabela de cabeçalho
            //Tabela de Cabeçalho
            Table t = section.AddTable();
            t.Style = "Normal";
            t.Borders.Width = 0.25;
            t.Format.Font.Size = 10;
            t.Rows.Height = 14;

            t.AddColumn("4cm").Format.Alignment = ParagraphAlignment.Center;
            t.AddColumn("4cm").Format.Alignment = ParagraphAlignment.Center;
            t.AddColumn("4cm").Format.Alignment = ParagraphAlignment.Center;
            t.AddColumn("4cm").Format.Alignment = ParagraphAlignment.Center;

            Row r1 = t.AddRow();

            r1.VerticalAlignment = VerticalAlignment.Center;

            r1.Cells[0].Format.Font.Color = Colors.Red;
            r1.Cells[0].AddParagraph("In: " + atleta1["apelido"].ToString());
            r1.Cells[1].AddParagraph("Out: " + atleta2["apelido"].ToString());
            r1.Cells[2].MergeRight = 1;
            r1.Cells[2].AddParagraph().AddFormattedText("Pontuação Total: " + string.Format("{0:0.00}", pontuacao));

            Row r2 = t.AddRow();

            r2.Cells[0].AddParagraph("Tempo de Jogo: " + label2.Text);
            r2.Cells[0].MergeRight = 1;
            r2.Cells[2].AddParagraph("Equilíbrio: " + string.Format("{0:0.00}", equilibrio));
            r2.Cells[3].AddParagraph("Pontos: " + string.Format("{0:0.00}", equilibrio));

            Row r3 = t.AddRow();

            r3.Cells[0].Format.Font.Color = Colors.Red;
            r3.Cells[0].AddParagraph("Ataques In: " + ataquesAtleta1);
            r3.Cells[1].AddParagraph("Ataques Out: " + ataquesAtleta2);
            r3.Cells[2].AddParagraph("Total de Ataques: " + ataquesTotal);
            r3.Cells[3].AddParagraph("Pontos: " + string.Format("{0:0.00}", pontosAtaques));

            Row r4 = t.AddRow();

            r4.Cells[0].Format.Font.Color = Colors.Red;
            r4.Cells[0].AddParagraph("Potência In: " + string.Format("{0:0.00}", potenciaAtleta1));
            r4.Cells[1].AddParagraph("Potência Out: " + string.Format("{0:0.00}", potenciaAtleta2));
            r4.Cells[2].AddParagraph("Potência Média: " + string.Format("{0:0.00}", potenciaTotalMedia));
            r4.Cells[3].AddParagraph("Pontos: " + string.Format("{0:0.00}", pontosPotencia));

            Row r5 = t.AddRow();

            r5.Cells[0].Format.Font.Color = Colors.Red;
            r5.Cells[0].AddParagraph("Nota Juiz In: " + notaJuizAtleta1);
            r5.Cells[1].AddParagraph("Nota Juiz Out: " + notaJuizAtleta2);
            r5.Cells[2].AddParagraph("Nota Juiz Total: " + (notaJuizAtleta1 + notaJuizAtleta2));
            r5.Cells[3].AddParagraph("Pontos: " + (notaJuizAtleta1 + notaJuizAtleta2));

            Row r6 = t.AddRow();

            r6.Cells[1].MergeRight = 1;
            r6.Cells[1].AddParagraph("Número de Sequências: " + sequencias);
            r6.Cells[3].AddParagraph("Pontos: " + pontosSequencias);

            section.AddParagraph();
            section.AddParagraph();

            #endregion

            #region tabela de registros
            //Tabela de registros
            t = section.AddTable();

            t.Style = "Normal";
            t.Format.Font.Size = 10;
            t.Rows.Height = 14;

            t.AddColumn("5.33cm").Format.Alignment = ParagraphAlignment.Center;
            t.AddColumn("5.33cm").Format.Alignment = ParagraphAlignment.Center;
            t.AddColumn("5.33cm").Format.Alignment = ParagraphAlignment.Center;

            Row r = t.AddRow();
            Table t1 = r.Cells[0].AddTextFrame().AddTable();
            Table t2 = r.Cells[1].AddTextFrame().AddTable();
            Table t3 = r.Cells[2].AddTextFrame().AddTable();

            Table[] tables = new Table[3] { t1, t2, t3 };

            foreach (Table tab in tables)
            {
                tab.Borders.Width = 0.25;

                tab.AddColumn("1.77cm").Format.Alignment = ParagraphAlignment.Center;
                tab.AddColumn("1.77cm").Format.Alignment = ParagraphAlignment.Center;
                tab.AddColumn("1.77cm").Format.Alignment = ParagraphAlignment.Center;

                r = tab.AddRow();
                r.VerticalAlignment = VerticalAlignment.Center;

                r.Cells[0].AddParagraph("Tempo");
                r.Cells[1].AddParagraph("In/Out");
                r.Cells[2].AddParagraph("Km/h");
            }

            int start = 0;
            int i = 0;
            int pagelimit = 44;
            int numberofpages = 0;
            bool newpage = false;

            foreach (SpeedRecord s in registrosRadar)
            {
                if (i != 0 && i % pagelimit == 0) { start++; newpage = true; }

                if (start != 0 && start % 3 == 0 && newpage == true)
                {
                    numberofpages++;
                    pagelimit = 55;
                    i = (pagelimit * numberofpages);
                    newpage = false;
                    section.AddPageBreak();

                    t = section.AddTable();

                    t.Style = "Normal";
                    t.Format.Font.Size = 10;
                    t.Rows.Height = 14;

                    t.AddColumn("5.33cm").Format.Alignment = ParagraphAlignment.Center;
                    t.AddColumn("5.33cm").Format.Alignment = ParagraphAlignment.Center;
                    t.AddColumn("5.33cm").Format.Alignment = ParagraphAlignment.Center;

                    r = t.AddRow();
                    t1 = r.Cells[0].AddTextFrame().AddTable();
                    t2 = r.Cells[1].AddTextFrame().AddTable();
                    t3 = r.Cells[2].AddTextFrame().AddTable();

                    tables[0] = t1; tables[1] = t2; tables[2] = t3;

                    foreach (Table tab in tables)
                    {
                        tab.Borders.Width = 0.25;

                        tab.AddColumn("1.77cm").Format.Alignment = ParagraphAlignment.Center;
                        tab.AddColumn("1.77cm").Format.Alignment = ParagraphAlignment.Center;
                        tab.AddColumn("1.77cm").Format.Alignment = ParagraphAlignment.Center;

                        r = tab.AddRow();
                        r.VerticalAlignment = VerticalAlignment.Center;

                        r.Cells[0].AddParagraph("Tempo");
                        r.Cells[1].AddParagraph("In/Out");
                        r.Cells[2].AddParagraph("Km/h");
                    }
                }

                Row x = tables[start % 3].AddRow();

                if (s.IdEvento == -1)
                {
                    x.Cells[0].AddParagraph("---");
                    x.Cells[1].AddParagraph("---");
                    x.Cells[2].AddParagraph("---");
                }
                else
                {   
                    if(s.Direcao == 0)
                    {
                        x.Cells[0].Format.Font.Color = Colors.Red;
                        x.Cells[1].Format.Font.Color = Colors.Red;
                        x.Cells[2].Format.Font.Color = Colors.Red;
                        x.Cells[1].AddParagraph("In");
                    } else
                    {
                        x.Cells[1].AddParagraph("Out");
                    }

                    x.Cells[0].AddParagraph(new DateTime(s.Ticks).ToString("mm:ss.ff"));
                    x.Cells[2].AddParagraph(s.Velocidade.ToString());
                }

                i++;
            }

            #endregion

            //table.SetEdge(0, 0, 6, 2, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.75, MigraDoc.DocumentObjectModel.Color.Empty);

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();

            string fileName = "relatorios\\" + document.Info.Title + ".pdf";

            System.IO.Directory.CreateDirectory("relatorios");

            pdfRenderer.PdfDocument.Save(fileName);
            Process.Start(fileName);
        }

        private void Reset_Window_Content()
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
            notaJuizAtleta1 = 0;
            notaJuizAtleta2 = 0;
            sequencias = 0;
            pontuacao = 0;
            pontosAtaques = 0;
            pontosSequencias = 0;
            pontosPotencia = 0;
            equilibrio = 0;

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
            if (this.cronometro.IsRunning)
            {
                this.label2.Text = new DateTime(this.cronometro.Elapsed.Ticks).ToString("mm:ss.ff");

                if (this.cronometro.ElapsedMilliseconds >= 300000)
                {
                    this.cronTimer.Stop();
                    this.cronometro.Stop();
                    SoundPlayer s = new SoundPlayer(Properties.Resources.termino);
                    s.Play();

                    //continue


                    //cleanup
                    if (MessageBox.Show("Partida Finalizada!", "Tempo Esgtado", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        NotasJuiz notas = new NotasJuiz(this);
                        notas.Disposed += Notas_Disposed;
                        notas.Show();
                    }
                }
            }
        }

        private void Notas_Disposed(object sender, EventArgs e)
        {
            pontuacao = Calcula_Pontuacao(sequencias, ataquesTotal, potenciaTotalMedia, notaJuizAtleta1, notaJuizAtleta2);

            Salvar_SpeedRecords_Database();

            Estatisticas_Partida();

            Do_Finalize_Dupla();

            Salvar_Resultado_Database();

            Reset_Window_Content();
        }

        private void Do_Finalize_Dupla ()
        {
            this.duplasEventoAtual["finalizado"] = 1;
            this.duplaseventoTableAdapter1.Update(this.duplasEventoAtual); //marca a dupla como finalizada

            if (this.FinalizarEvento == true)
            {
                this.eventoAtual["finalizado"] = 1;
                this.eventoTableAdapter1.Update(this.eventoAtual);
                this.eventoAtual = null;
            }
        }

        private void Grava_WO ()
        {
            Do_Finalize_Dupla();
            this.resultadoseventoTableAdapter1.Insert(idEvento, idDuplasEvento, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Reset_Window_Content();
        }

        private void Salvar_SpeedRecords_Database()
        {
            List<string> Rows = new List<string>();

            foreach (SpeedRecord s in registrosRadar)
            {
                if (s.IdEvento > 0)
                {
                    Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", s.IdEvento, s.IdDuplasEvento, s.IdDupla, s.IdAtleta, s.Direcao, s.Velocidade, (int)s.Ticks));
                }
            }

            string connectionStr = "server=localhost;user id=system;password=Sys_4dm1n@;database=frescobol_system_db";
            StringBuilder sCommand = new StringBuilder("INSERT INTO `speedrecords` (`idevento`, `idduplasevento`, `iddupla`, `idatleta`, `direcao`, `velocidade`, `ticks`) VALUES ");

            using(MySql.Data.MySqlClient.MySqlConnection mconn = new MySql.Data.MySqlClient.MySqlConnection(connectionStr))
            {
                if(Rows.Count == 0)
                {
                    return;
                }

                sCommand.Append(string.Join(",", Rows));
                sCommand.Append(";");

                mconn.Open();

                using (MySql.Data.MySqlClient.MySqlCommand mycmd = new MySql.Data.MySqlClient.MySqlCommand(sCommand.ToString(), mconn))
                {
                    mycmd.CommandType = CommandType.Text;
                    mycmd.ExecuteNonQuery();
                    mconn.Close();
                }
            }

            //speedrecordsTableAdapter1.Insert(s.IdEvento, s.IdDuplasEvento, s.IdDupla, s.IdAtleta, s.Direcao, s.Velocidade, (int)s.Ticks);
        }

        private void Salvar_Resultado_Database()
        {
            if (sequencias == 0 || potenciaTotalMedia == 0 || ataquesTotal == 0)
            {
                this.resultadoseventoTableAdapter1.Insert(idEvento, idDuplasEvento, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }
            else
            {
                this.resultadoseventoTableAdapter1.Insert(idEvento, idDuplasEvento, sequencias, potenciaTotalMedia, ataquesTotal, ataquesAtleta1, ataquesAtleta2, potenciaAtleta1, potenciaAtleta2, notaJuizAtleta1, notaJuizAtleta2, pontuacao);
            }
        }

        private int objToInt (object obj)
        {
            return Int32.Parse(obj.ToString());
        }

        private double objToDouble(object obj)
        {
            var s = obj.ToString();
            return Double.Parse(obj.ToString());
        }

        private double Calcula_Pontuacao(int sequencias, int ataques, double velocidade, int notajuizatleta1, int notajuizatleta2)
        {
            double pontuacao = 0d;

            int min_seq = objToInt(seq_start["sequencias"]), max_seq = objToInt(seq_end["sequencias"]);
            int min_seq_points = objToInt(seq_start["pontuacao"]), max_seq_points = objToInt(seq_end["pontuacao"]);

            int min_atk = objToInt(atk_start["ataques"]), max_atk = objToInt(atk_end["ataques"]);
            int atkpmax = objToInt(atk_end["pontuacao"]);

            double vmin = Double.Parse(pot_start["velocidade"].ToString(), new CultureInfo("en-US")), vmax = objToDouble(pot_end["velocidade"]);
            double pvmin = objToDouble(pot_start["pontuacao"]), pvmax = objToDouble(pot_end["pontuacao"]);

            //sequencias
            if (sequencias < min_seq) pontosSequencias = min_seq_points;
            else if (sequencias > max_seq) pontosSequencias = max_seq_points;
            else if (sequencias >= 1) pontosSequencias = notas.Sequencia[sequencias];

            //ataques
            if (ataques >= max_atk) pontosAtaques = atkpmax;
            else if (ataques >= min_atk) pontosAtaques = notas.Ataque[ataques];

            //potencia
            if (velocidade <= vmin) pontosPotencia = 0;
            else if (velocidade >= vmax) pontosPotencia = pvmax;
            else pontosPotencia = notas.Velocidade[string.Format(new CultureInfo("en-US"), "{0:00.0}", velocidade)];

            //equilibrio
            int atkmenor, atkmaior;

            if (ataquesAtleta1 < ataquesAtleta2) { atkmenor = ataquesAtleta1; atkmaior = ataquesAtleta2; }
            else { atkmenor = ataquesAtleta2; atkmaior = ataquesAtleta1; }

            if (atkmaior > 0)
            {
                equilibrio = ((double)atkmenor / atkmaior) * ataquesTotal * 0.681819;
                if (equilibrio > 150) equilibrio = 150;
            }

            //subjetivo
            pontuacao = pontosAtaques + pontosSequencias + pontosPotencia + equilibrio + notajuizatleta1 + notajuizatleta2;

            return pontuacao;
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
            }
            else
            {
                this.cronTimer.Start();
                this.cronometro.Start();
                SoundPlayer s = new SoundPlayer(Plateia.Properties.Resources.inicio);
                s.Play();

                this.textBox8.Text = ((Int32.Parse(this.textBox8.Text) + 1) + "").PadLeft(2, '0');
                sequencias++;
                registrosRadar.Add(new SpeedRecord(-1, -1, -1, -1, -1, -1, -1));
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    ShowHelpPage();
                    break;
                case Keys.F5:
                    if(duplaAtual == null || eventoAtual == null)
                    {
                        MessageBox.Show("Nenhuma dupla ou evento selecionados.", "Erro");
                        return;
                    }

                    if(ataquesTotal != 0 || potenciaTotalMedia != 0 || cronometro.ElapsedMilliseconds != 0)
                    {
                        return;
                    }

                    if(MessageBox.Show("Você está prestes a desclassificar uma dupla por W.O. Tem certeza?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Grava_WO();
                    }
                    break;
                case Keys.F6:
                    //Radar_SpeedReceived(this, new RadarSpeedEventArgs(--v, (byte)(v % 2)));
                    break;
                case Keys.F7:
                    if (eventoForm == null || eventoForm.IsDisposed)
                    {
                        eventoForm = new EventoForm();
                        eventoForm.Show();
                        eventoForm.Disposed += EventoForm_Disposed;
                    }
                    break;
                case Keys.F8:
                    if (duplasForm == null || duplasForm.IsDisposed)
                    {
                        if (eventoAtual == null)
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
                case Keys.F10:
                    Inverter_Cores();
                    break;
                default:
                    break;
            }
        }

        private void ShowHelpPage()
        {
            
        }

        private void Inverter_Cores ()
        {
            //9 10 2 7 6 8 - 1 5 4 3
            this.label9.ForeColor = Inverse_Color(label9.ForeColor);
            this.label10.ForeColor = Inverse_Color(label10.ForeColor);
            this.label2.ForeColor = Inverse_Color(label2.ForeColor);
            this.label7.ForeColor = Inverse_Color(label7.ForeColor);
            this.label6.ForeColor = Inverse_Color(label6.ForeColor);
            this.textBox8.ForeColor = Inverse_Color(textBox8.ForeColor);

            this.label1.ForeColor = Inverse_Color(label1.ForeColor);
            this.label5.ForeColor = Inverse_Color(label5.ForeColor);
            this.label4.ForeColor = Inverse_Color(label4.ForeColor);
            this.label3.ForeColor = Inverse_Color(label3.ForeColor);

            this.BackColor = Inverse_Color(this.BackColor);

            //this.Refresh();
        }

        private System.Drawing.Color Inverse_Color (System.Drawing.Color color)
        {
            return color == System.Drawing.SystemColors.ControlText ? System.Drawing.Color.White : System.Drawing.SystemColors.ControlText;
        }

        private void DuplasForm_Disposed(object sender, EventArgs e)
        {
            if (duplasForm.getSelectedDuplaId() > 0 && duplasForm.getSelectedDuplaEventoId() > 0)
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

                if(duplasForm.ultimaDupla == true)
                {
                    this.FinalizarEvento = true;
                } else {
                    this.FinalizarEvento = false;
                }
            }
            else
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
                int tabelapont = Int32.Parse(categoriaAtual["idtabelapontuacao"].ToString());

                AtualizaInfoPontuacao(tabelapont);
            }
            else
            {
                eventoAtual = null;
                Reset_Window_Content();
            }
        }

        private void AtualizaInfoPontuacao(int tabelapont)
        {
            this.notas.Ataque = new Dictionary<int, double>();
            this.notas.Sequencia = new Dictionary<int, int>();
            this.notas.Velocidade = new Dictionary<string, double>();

            this.tabelaataqueTableAdapter1.FillBy(frescobol_system_dbDataSet.tabelaataque, tabelapont);
            this.tabelasequenciaTableAdapter1.FillBy(frescobol_system_dbDataSet.tabelasequencia, tabelapont);
            this.tabelapotenciaTableAdapter1.FillBy(frescobol_system_dbDataSet.tabelapotencia, tabelapont);

            seq_start = frescobol_system_dbDataSet.tabelasequencia.Rows[0];
            seq_end = frescobol_system_dbDataSet.tabelasequencia.Rows[frescobol_system_dbDataSet.tabelasequencia.Rows.Count - 1];

            atk_start = frescobol_system_dbDataSet.tabelaataque.Rows[0];
            atk_end = frescobol_system_dbDataSet.tabelaataque.Rows[frescobol_system_dbDataSet.tabelaataque.Rows.Count - 1];

            pot_start = frescobol_system_dbDataSet.tabelapotencia.Rows[0];
            pot_end = frescobol_system_dbDataSet.tabelapotencia.Rows[frescobol_system_dbDataSet.tabelapotencia.Rows.Count - 1];

            foreach (DataRow row in frescobol_system_dbDataSet.tabelaataque.Rows)
            {
                notas.Ataque.Add(Int32.Parse(row["ataques"].ToString()), Double.Parse(row["pontuacao"].ToString()));
            }

            foreach (DataRow row in frescobol_system_dbDataSet.tabelasequencia.Rows)
            {
                notas.Sequencia.Add(Int32.Parse(row["sequencias"].ToString()), Int32.Parse(row["pontuacao"].ToString()));
            }

            foreach (DataRow row in frescobol_system_dbDataSet.tabelapotencia.Rows)
            {
                notas.Velocidade.Add(row["velocidade"].ToString(), Double.Parse(row["pontuacao"].ToString()));
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja encerrar a aplicação?", "Encerrar aplicação", MessageBoxButtons.YesNo);

            e.Cancel = (result == DialogResult.No);
        }
    }

    public static class CrossThreadUtiliy
    {
        public static void InvokeControlAction<T>(T cont, Action<T> action) where T : Control
        {
            if (cont.InvokeRequired)
            {
                cont.Invoke(new Action<T, Action<T>>(InvokeControlAction), new object[] { cont, action });
            }
            else
            {
                action(cont);
            }
        }
    }
}
