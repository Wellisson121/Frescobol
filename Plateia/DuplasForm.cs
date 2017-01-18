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
    public partial class DuplasForm : Form
    {
        private int SelectedEventoId = -1;
        private int SelectedDuplaId = -1;

        public DuplasForm(int idEvento)
        {
            InitializeComponent();
            this.SelectedEventoId = idEvento;
        }

        private void DuplasForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'frescobol_system_dbDataSet.duplasevento' table. You can move, or remove it, as needed.
            this.duplaseventoTableAdapter.GetDuplasByEventoId(this.frescobol_system_dbDataSet.duplasevento, this.SelectedEventoId);

            this.comboBox1.SelectedItem = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!");
                return;
            }

            this.SelectedDuplaId = (int)this.comboBox1.SelectedValue;

            this.Dispose();
        }

        public int getSelectedDuplaId ()
        {
            return this.SelectedDuplaId;
        }

        public int getSelectedDuplaEventoId ()
        {
            if (this.SelectedDuplaId > 0)
                return Int32.Parse(this.duplaseventoTableAdapter.GetDuplaById(this.SelectedDuplaId).Rows[0]["idduplasevento"].ToString());
            else return -1;
        }
    }
}
