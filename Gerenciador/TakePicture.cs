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
    public partial class TakePicture : Form
    {
        private Bitmap takenPicture;
        private AForge.Video.DirectShow.VideoCaptureDevice videoSource;
        private MainForm mainForm;

        public TakePicture(MainForm mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            AForge.Video.DirectShow.FilterInfoCollection videosources = new AForge.Video.DirectShow.FilterInfoCollection(AForge.Video.DirectShow.FilterCategory.VideoInputDevice);

            if (videosources != null)
            {
                //videoSource.GetCameraProperty(AForge.Video.DirectShow.CameraControlProperty.)
                videoSource = new AForge.Video.DirectShow.VideoCaptureDevice(videosources[0].MonikerString);
                videoSource.NewFrame += (s, e) => {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        takenPicture.Dispose();
                    }

                    pictureBox1.Image = (Bitmap)e.Frame.Clone();
                    takenPicture = (Bitmap)e.Frame.Clone();
                };
                videoSource.Start();
            }
        }

        private void TakePicture_Load(object sender, EventArgs e)
        {
            
        }

        public Bitmap getTakenPicture ()
        {
            return takenPicture;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // pictureBox1.Image.Save("snapshot.png", System.Drawing.Imaging.ImageFormat.Png);
            //pictureBox1.Image.Clone();
            //this.takenPicture = pictureBox1.Image as Bitmap;
            mainForm.copyTakenPicture();
        }

        private void TakePicture_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.OnClosed(e);

            if (videoSource != null && videoSource.IsRunning)
            {
                this.takenPicture.Dispose();
                this.pictureBox1.Image.Dispose();
                videoSource.SignalToStop();
                videoSource = null;
            }
        }
    }
}
