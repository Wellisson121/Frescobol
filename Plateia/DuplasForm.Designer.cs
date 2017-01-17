namespace Plateia
{
    partial class DuplasForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.duplaseventoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.frescobol_system_dbDataSet = new Plateia.frescobol_system_dbDataSet();
            this.button1 = new System.Windows.Forms.Button();
            this.duplaseventoTableAdapter = new Plateia.frescobol_system_dbDataSetTableAdapters.duplaseventoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.duplaseventoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frescobol_system_dbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dupla";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.duplaseventoBindingSource;
            this.comboBox1.DisplayMember = "nomedupla";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(289, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.ValueMember = "iddupla";
            // 
            // duplaseventoBindingSource
            // 
            this.duplaseventoBindingSource.DataMember = "duplasevento";
            this.duplaseventoBindingSource.DataSource = this.frescobol_system_dbDataSet;
            // 
            // frescobol_system_dbDataSet
            // 
            this.frescobol_system_dbDataSet.DataSetName = "frescobol_system_dbDataSet";
            this.frescobol_system_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Selecionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // duplaseventoTableAdapter
            // 
            this.duplaseventoTableAdapter.ClearBeforeFill = true;
            // 
            // DuplasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 89);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(329, 128);
            this.MinimumSize = new System.Drawing.Size(329, 128);
            this.Name = "DuplasForm";
            this.Text = "DuplasForm";
            this.Load += new System.EventHandler(this.DuplasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.duplaseventoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frescobol_system_dbDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private frescobol_system_dbDataSet frescobol_system_dbDataSet;
        private System.Windows.Forms.BindingSource duplaseventoBindingSource;
        private frescobol_system_dbDataSetTableAdapters.duplaseventoTableAdapter duplaseventoTableAdapter;
    }
}