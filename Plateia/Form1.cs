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

namespace Plateia
{
    public partial class Form1 : Form
    {
        private Stopwatch cronometro;
        private Timer cronTimer;

        public Form1()
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
             /*
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            // Draw the text
            gfx.DrawString("Hello, World!", font, XBrushes.Black,
              new XRect(0, 0, page.Width, page.Height),
              XStringFormats.Center);

            // Save the document...
            string filename = "HelloWorld.pdf";
            document.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
            */
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
    }
}
