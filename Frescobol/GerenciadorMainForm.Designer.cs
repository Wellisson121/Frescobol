namespace Frescobol
{
    partial class GerenciadorMainForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.AtletaTab = new System.Windows.Forms.TabPage();
            this.DuplaTab = new System.Windows.Forms.TabPage();
            this.EventoTab = new System.Windows.Forms.TabPage();
            this.CategoriaTab = new System.Windows.Forms.TabPage();
            this.ConfiguracoesTab = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.AtletaTab);
            this.tabControl.Controls.Add(this.DuplaTab);
            this.tabControl.Controls.Add(this.EventoTab);
            this.tabControl.Controls.Add(this.CategoriaTab);
            this.tabControl.Controls.Add(this.ConfiguracoesTab);
            this.tabControl.Location = new System.Drawing.Point(2, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(780, 556);
            this.tabControl.TabIndex = 0;
            // 
            // AtletaTab
            // 
            this.AtletaTab.Location = new System.Drawing.Point(4, 22);
            this.AtletaTab.Name = "AtletaTab";
            this.AtletaTab.Padding = new System.Windows.Forms.Padding(3);
            this.AtletaTab.Size = new System.Drawing.Size(772, 530);
            this.AtletaTab.TabIndex = 0;
            this.AtletaTab.Text = "Atleta";
            this.AtletaTab.UseVisualStyleBackColor = true;
            // 
            // DuplaTab
            // 
            this.DuplaTab.Location = new System.Drawing.Point(4, 22);
            this.DuplaTab.Name = "DuplaTab";
            this.DuplaTab.Padding = new System.Windows.Forms.Padding(3);
            this.DuplaTab.Size = new System.Drawing.Size(772, 530);
            this.DuplaTab.TabIndex = 1;
            this.DuplaTab.Text = "Dupla";
            this.DuplaTab.UseVisualStyleBackColor = true;
            // 
            // EventoTab
            // 
            this.EventoTab.Location = new System.Drawing.Point(4, 22);
            this.EventoTab.Name = "EventoTab";
            this.EventoTab.Padding = new System.Windows.Forms.Padding(3);
            this.EventoTab.Size = new System.Drawing.Size(772, 530);
            this.EventoTab.TabIndex = 2;
            this.EventoTab.Text = "Evento";
            this.EventoTab.UseVisualStyleBackColor = true;
            // 
            // CategoriaTab
            // 
            this.CategoriaTab.Location = new System.Drawing.Point(4, 22);
            this.CategoriaTab.Name = "CategoriaTab";
            this.CategoriaTab.Size = new System.Drawing.Size(772, 530);
            this.CategoriaTab.TabIndex = 3;
            this.CategoriaTab.Text = "Categoria";
            this.CategoriaTab.UseVisualStyleBackColor = true;
            // 
            // ConfiguracoesTab
            // 
            this.ConfiguracoesTab.Location = new System.Drawing.Point(4, 22);
            this.ConfiguracoesTab.Name = "ConfiguracoesTab";
            this.ConfiguracoesTab.Size = new System.Drawing.Size(772, 530);
            this.ConfiguracoesTab.TabIndex = 4;
            this.ConfiguracoesTab.Text = "Configurações";
            this.ConfiguracoesTab.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 556);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(772, 530);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Atleta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(772, 530);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dupla";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(772, 530);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Evento";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(772, 530);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Categoria";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(772, 530);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Configurações";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(103, 203);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(562, 299);
            this.dataGridView1.TabIndex = 0;
            // 
            // GerenciadorMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tabControl);
            this.Name = "GerenciadorMainForm";
            this.Text = "Frescobol - Interface de Gerenciamento";
            this.Load += new System.EventHandler(this.GerenciadorMainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage AtletaTab;
        private System.Windows.Forms.TabPage DuplaTab;
        private System.Windows.Forms.TabPage EventoTab;
        private System.Windows.Forms.TabPage CategoriaTab;
        private System.Windows.Forms.TabPage ConfiguracoesTab;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

