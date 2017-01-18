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
        private int selectedEventId = -1;

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

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!");
                return;
            }

            this.selectedEventId = (int)this.comboBox1.SelectedValue;

            this.Dispose();
        }

        public int GetSelectedEventId ()
        {
            return this.selectedEventId;
        }
    }
}
