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
            // TODO: This line of code loads data into the 'frescobol_system_dbDataSet.atleta' table. You can move, or remove it, as needed.
            this.atletaTableAdapter.Fill(this.frescobol_system_dbDataSet.atleta);

        }
    }
}
