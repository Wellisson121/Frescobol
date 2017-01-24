using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Gerenciador
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
        }

        public void UpdateProgress (int add)
        {
            //progressBar1.Refresh();
            this.progressBar1.Increment(add);
            Thread.Sleep(250);
            //progressBar1.CreateGraphics().DrawString(progressBar1.Value.ToString() + "%", new Font("Arial", (float)10.25, FontStyle.Bold), Brushes.Red, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
        }

        internal Dictionary<string, Image> LoadImagensAtletas()
        {
            BinaryFormatter bf = new BinaryFormatter();
            Dictionary<string, Image> imagens;

            try
            {
                string path = System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString() + "\\images\\images.bin";

                imagens = bf.Deserialize(File.Open(path, FileMode.Open)) as Dictionary<string, Image>;
            }
            catch(Exception)
            {
                MessageBox.Show("Falha ao carregar as imagens dos atletas!", "Erro Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return null;
        }
    }
}
