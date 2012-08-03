namespace Calendar
{
    partial class frmPesquisaCliente
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
            this.txtProcesso = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtApelidos = new System.Windows.Forms.TextBox();
            this.dgClientes = new System.Windows.Forms.DataGridView();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbWhere = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkBoxProcesso = new System.Windows.Forms.CheckBox();
            this.chkBoxNome = new System.Windows.Forms.CheckBox();
            this.chkBoxApelidos = new System.Windows.Forms.CheckBox();
            this.idCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.n_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apelidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProcesso
            // 
            this.txtProcesso.Location = new System.Drawing.Point(68, 12);
            this.txtProcesso.Name = "txtProcesso";
            this.txtProcesso.Size = new System.Drawing.Size(51, 20);
            this.txtProcesso.TabIndex = 0;
            this.txtProcesso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(68, 38);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(170, 20);
            this.txtNome.TabIndex = 1;
            // 
            // txtApelidos
            // 
            this.txtApelidos.Location = new System.Drawing.Point(68, 64);
            this.txtApelidos.Name = "txtApelidos";
            this.txtApelidos.Size = new System.Drawing.Size(170, 20);
            this.txtApelidos.TabIndex = 2;
            // 
            // dgClientes
            // 
            this.dgClientes.AllowUserToAddRows = false;
            this.dgClientes.AllowUserToDeleteRows = false;
            this.dgClientes.AllowUserToResizeColumns = false;
            this.dgClientes.AllowUserToResizeRows = false;
            this.dgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCliente,
            this.n_cliente,
            this.nome,
            this.apelidos});
            this.dgClientes.Location = new System.Drawing.Point(12, 167);
            this.dgClientes.Name = "dgClientes";
            this.dgClientes.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgClientes.Size = new System.Drawing.Size(366, 243);
            this.dgClientes.TabIndex = 4;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(303, 12);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 5;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(303, 41);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbWhere
            // 
            this.cmbWhere.FormattingEnabled = true;
            this.cmbWhere.Items.AddRange(new object[] {
            "E",
            "OU"});
            this.cmbWhere.Location = new System.Drawing.Point(68, 90);
            this.cmbWhere.Name = "cmbWhere";
            this.cmbWhere.Size = new System.Drawing.Size(49, 21);
            this.cmbWhere.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Processo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Apelidos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nome:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Condição:";
            // 
            // chkBoxProcesso
            // 
            this.chkBoxProcesso.AutoSize = true;
            this.chkBoxProcesso.Location = new System.Drawing.Point(125, 14);
            this.chkBoxProcesso.Name = "chkBoxProcesso";
            this.chkBoxProcesso.Size = new System.Drawing.Size(15, 14);
            this.chkBoxProcesso.TabIndex = 12;
            this.chkBoxProcesso.UseVisualStyleBackColor = true;
            // 
            // chkBoxNome
            // 
            this.chkBoxNome.AutoSize = true;
            this.chkBoxNome.Location = new System.Drawing.Point(244, 40);
            this.chkBoxNome.Name = "chkBoxNome";
            this.chkBoxNome.Size = new System.Drawing.Size(15, 14);
            this.chkBoxNome.TabIndex = 13;
            this.chkBoxNome.UseVisualStyleBackColor = true;
            // 
            // chkBoxApelidos
            // 
            this.chkBoxApelidos.AutoSize = true;
            this.chkBoxApelidos.Location = new System.Drawing.Point(244, 66);
            this.chkBoxApelidos.Name = "chkBoxApelidos";
            this.chkBoxApelidos.Size = new System.Drawing.Size(15, 14);
            this.chkBoxApelidos.TabIndex = 14;
            this.chkBoxApelidos.UseVisualStyleBackColor = true;
            // 
            // idCliente
            // 
            this.idCliente.HeaderText = "ID Cliente";
            this.idCliente.Name = "idCliente";
            this.idCliente.ReadOnly = true;
            this.idCliente.Visible = false;
            // 
            // n_cliente
            // 
            this.n_cliente.HeaderText = "Proc.";
            this.n_cliente.Name = "n_cliente";
            this.n_cliente.ReadOnly = true;
            this.n_cliente.Width = 50;
            // 
            // nome
            // 
            this.nome.HeaderText = "Nome";
            this.nome.Name = "nome";
            this.nome.ReadOnly = true;
            this.nome.Width = 125;
            // 
            // apelidos
            // 
            this.apelidos.HeaderText = "Apelidos";
            this.apelidos.Name = "apelidos";
            this.apelidos.ReadOnly = true;
            this.apelidos.Width = 145;
            // 
            // frmPesquisaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 422);
            this.ControlBox = false;
            this.Controls.Add(this.chkBoxApelidos);
            this.Controls.Add(this.chkBoxNome);
            this.Controls.Add(this.chkBoxProcesso);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbWhere);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.dgClientes);
            this.Controls.Add(this.txtApelidos);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtProcesso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPesquisaCliente";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Clientes";
            this.Load += new System.EventHandler(this.frmPesquisaCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProcesso;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtApelidos;
        private System.Windows.Forms.DataGridView dgClientes;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbWhere;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkBoxProcesso;
        private System.Windows.Forms.CheckBox chkBoxNome;
        private System.Windows.Forms.CheckBox chkBoxApelidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn n_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn apelidos;
    }
}