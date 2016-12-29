namespace Gerenciador
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAtleta = new System.Windows.Forms.TabPage();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.frescobol_system_dbDataSet = new Gerenciador.frescobol_system_dbDataSet();
            this.dataGridViewAtleta = new System.Windows.Forms.DataGridView();
            this.atletaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atletaTableAdapter = new Gerenciador.frescobol_system_dbDataSetTableAdapters.atletaTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.idatletaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apelidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomearquivofotoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabAtleta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frescobol_system_dbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtleta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atletaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAtleta);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 560);
            this.tabControl1.TabIndex = 0;
            // 
            // tabAtleta
            // 
            this.tabAtleta.Controls.Add(this.button1);
            this.tabAtleta.Controls.Add(this.textBox3);
            this.tabAtleta.Controls.Add(this.label3);
            this.tabAtleta.Controls.Add(this.textBox2);
            this.tabAtleta.Controls.Add(this.label2);
            this.tabAtleta.Controls.Add(this.textBox1);
            this.tabAtleta.Controls.Add(this.label1);
            this.tabAtleta.Controls.Add(this.pictureBox1);
            this.tabAtleta.Controls.Add(this.dataGridViewAtleta);
            this.tabAtleta.Location = new System.Drawing.Point(4, 22);
            this.tabAtleta.Name = "tabAtleta";
            this.tabAtleta.Padding = new System.Windows.Forms.Padding(3);
            this.tabAtleta.Size = new System.Drawing.Size(776, 534);
            this.tabAtleta.TabIndex = 1;
            this.tabAtleta.Text = "Atleta";
            this.tabAtleta.UseVisualStyleBackColor = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.frescobol_system_dbDataSet;
            this.bindingSource1.Position = 0;
            // 
            // frescobol_system_dbDataSet
            // 
            this.frescobol_system_dbDataSet.DataSetName = "frescobol_system_dbDataSet";
            this.frescobol_system_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewAtleta
            // 
            this.dataGridViewAtleta.AllowUserToAddRows = false;
            this.dataGridViewAtleta.AutoGenerateColumns = false;
            this.dataGridViewAtleta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAtleta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idatletaDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn,
            this.apelidoDataGridViewTextBoxColumn,
            this.nomearquivofotoDataGridViewTextBoxColumn});
            this.dataGridViewAtleta.DataSource = this.atletaBindingSource;
            this.dataGridViewAtleta.Location = new System.Drawing.Point(49, 250);
            this.dataGridViewAtleta.Name = "dataGridViewAtleta";
            this.dataGridViewAtleta.Size = new System.Drawing.Size(676, 276);
            this.dataGridViewAtleta.TabIndex = 0;
            // 
            // atletaBindingSource
            // 
            this.atletaBindingSource.DataMember = "atleta";
            this.atletaBindingSource.DataSource = this.bindingSource1;
            // 
            // atletaTableAdapter
            // 
            this.atletaTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gerenciador.Properties.Resources.no_image;
            this.pictureBox1.Location = new System.Drawing.Point(575, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(370, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Apelido";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(49, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(370, 20);
            this.textBox2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Arquivo de imagem";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(49, 137);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(370, 20);
            this.textBox3.TabIndex = 7;
            // 
            // idatletaDataGridViewTextBoxColumn
            // 
            this.idatletaDataGridViewTextBoxColumn.DataPropertyName = "idatleta";
            this.idatletaDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idatletaDataGridViewTextBoxColumn.Name = "idatletaDataGridViewTextBoxColumn";
            this.idatletaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idatletaDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.idatletaDataGridViewTextBoxColumn.Width = 76;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.Width = 257;
            // 
            // apelidoDataGridViewTextBoxColumn
            // 
            this.apelidoDataGridViewTextBoxColumn.DataPropertyName = "apelido";
            this.apelidoDataGridViewTextBoxColumn.HeaderText = "Apelido";
            this.apelidoDataGridViewTextBoxColumn.Name = "apelidoDataGridViewTextBoxColumn";
            this.apelidoDataGridViewTextBoxColumn.Width = 150;
            // 
            // nomearquivofotoDataGridViewTextBoxColumn
            // 
            this.nomearquivofotoDataGridViewTextBoxColumn.DataPropertyName = "nome_arquivo_foto";
            this.nomearquivofotoDataGridViewTextBoxColumn.HeaderText = "Arquivo de Foto";
            this.nomearquivofotoDataGridViewTextBoxColumn.Name = "nomearquivofotoDataGridViewTextBoxColumn";
            this.nomearquivofotoDataGridViewTextBoxColumn.Width = 150;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(428, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 22);
            this.button1.TabIndex = 8;
            this.button1.Text = "Selecionar foto...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Frescobol - Interface de Gerenciamento";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabAtleta.ResumeLayout(false);
            this.tabAtleta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frescobol_system_dbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtleta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atletaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAtleta;
        private System.Windows.Forms.BindingSource bindingSource1;
        private frescobol_system_dbDataSet frescobol_system_dbDataSet;
        private System.Windows.Forms.DataGridView dataGridViewAtleta;
        private System.Windows.Forms.BindingSource atletaBindingSource;
        private frescobol_system_dbDataSetTableAdapters.atletaTableAdapter atletaTableAdapter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idatletaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apelidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomearquivofotoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.BindingSource bindingSource2;
    }
}

