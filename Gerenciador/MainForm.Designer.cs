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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.atletaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atletaTableAdapter = new Gerenciador.frescobol_system_dbDataSetTableAdapters.atletaTableAdapter();
            this.idatletaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apelidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomearquivofotoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabAtleta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frescobol_system_dbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atletaBindingSource)).BeginInit();
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
            this.tabAtleta.Controls.Add(this.dataGridView1);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idatletaDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn,
            this.apelidoDataGridViewTextBoxColumn,
            this.nomearquivofotoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.atletaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(49, 250);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(676, 276);
            this.dataGridView1.TabIndex = 0;
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
            // idatletaDataGridViewTextBoxColumn
            // 
            this.idatletaDataGridViewTextBoxColumn.DataPropertyName = "idatleta";
            this.idatletaDataGridViewTextBoxColumn.HeaderText = "ID Atleta";
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frescobol_system_dbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atletaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAtleta;
        private System.Windows.Forms.BindingSource bindingSource1;
        private frescobol_system_dbDataSet frescobol_system_dbDataSet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource atletaBindingSource;
        private frescobol_system_dbDataSetTableAdapters.atletaTableAdapter atletaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idatletaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apelidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomearquivofotoDataGridViewTextBoxColumn;
    }
}

