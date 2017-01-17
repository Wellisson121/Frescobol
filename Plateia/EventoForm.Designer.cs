namespace Plateia
{
    partial class EventoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.eventoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.frescobol_system_dbDataSet = new Plateia.frescobol_system_dbDataSet();
            this.atletaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atletaTableAdapter = new Plateia.frescobol_system_dbDataSetTableAdapters.atletaTableAdapter();
            this.eventoTableAdapter = new Plateia.frescobol_system_dbDataSetTableAdapters.eventoTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frescobol_system_dbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atletaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.eventoBindingSource;
            this.comboBox1.DisplayMember = "nome";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(294, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "idevento";
            // 
            // eventoBindingSource
            // 
            this.eventoBindingSource.DataMember = "evento";
            this.eventoBindingSource.DataSource = this.frescobol_system_dbDataSet;
            // 
            // frescobol_system_dbDataSet
            // 
            this.frescobol_system_dbDataSet.DataSetName = "frescobol_system_dbDataSet";
            this.frescobol_system_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // atletaBindingSource
            // 
            this.atletaBindingSource.DataMember = "atleta";
            this.atletaBindingSource.DataSource = this.frescobol_system_dbDataSet;
            // 
            // atletaTableAdapter
            // 
            this.atletaTableAdapter.ClearBeforeFill = true;
            // 
            // eventoTableAdapter
            // 
            this.eventoTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Evento";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Selecionar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // EventoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 89);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(329, 128);
            this.MinimumSize = new System.Drawing.Size(329, 128);
            this.Name = "EventoForm";
            this.Text = "EventoForm";
            this.Load += new System.EventHandler(this.EventoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frescobol_system_dbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atletaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private frescobol_system_dbDataSet frescobol_system_dbDataSet;
        private System.Windows.Forms.BindingSource atletaBindingSource;
        private frescobol_system_dbDataSetTableAdapters.atletaTableAdapter atletaTableAdapter;
        private System.Windows.Forms.BindingSource eventoBindingSource;
        private frescobol_system_dbDataSetTableAdapters.eventoTableAdapter eventoTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}