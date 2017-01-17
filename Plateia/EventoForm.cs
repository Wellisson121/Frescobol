using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plateia
{
    public partial class EventoForm : Form
    {
        public EventoForm()
        {
            InitializeComponent();
        }

        private void EventoForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'frescobol_system_dbDataSet.evento' table. You can move, or remove it, as needed.
            this.eventoTableAdapter.GetNotFinalizedEvents(this.frescobol_system_dbDataSet.evento);

            this.comboBox1.SelectedItem = null;
        }

        private void getNotFinalizedEventsToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.eventoTableAdapter.GetNotFinalizedEvents(this.frescobol_system_dbDataSet.evento);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
