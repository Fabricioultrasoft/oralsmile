namespace Calendar
{
    partial class frmMarcacao
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
            this.txtObs = new System.Windows.Forms.TextBox();
            this.cmbIdTipoTratamento = new System.Windows.Forms.ComboBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtDataInicio = new System.Windows.Forms.MaskedTextBox();
            this.txtDataFinal = new System.Windows.Forms.MaskedTextBox();
            this.txtHoraInicio = new System.Windows.Forms.MaskedTextBox();
            this.txtHoraFinal = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(15, 109);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(632, 70);
            this.txtObs.TabIndex = 6;
            // 
            // cmbIdTipoTratamento
            // 
            this.cmbIdTipoTratamento.FormattingEnabled = true;
            this.cmbIdTipoTratamento.Location = new System.Drawing.Point(138, 64);
            this.cmbIdTipoTratamento.Name = "cmbIdTipoTratamento";
            this.cmbIdTipoTratamento.Size = new System.Drawing.Size(121, 21);
            this.cmbIdTipoTratamento.TabIndex = 4;
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(402, 12);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(245, 21);
            this.cmbCliente.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Data e Hora Iniciais:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Data e Horas Finais:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Observações";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tipo de Tratamento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(346, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cliente:";
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Location = new System.Drawing.Point(543, 36);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(104, 23);
            this.btnPesquisa.TabIndex = 12;
            this.btnPesquisa.Text = "Pesquisar Cliente";
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(15, 184);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(67, 29);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(580, 184);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(67, 29);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.Location = new System.Drawing.Point(138, 12);
            this.txtDataInicio.Mask = "00/00/0000";
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(121, 20);
            this.txtDataInicio.TabIndex = 0;
            this.txtDataInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDataInicio.ValidatingType = typeof(System.DateTime);
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Location = new System.Drawing.Point(138, 38);
            this.txtDataFinal.Mask = "00/00/0000";
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(121, 20);
            this.txtDataFinal.TabIndex = 2;
            this.txtDataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDataFinal.ValidatingType = typeof(System.DateTime);
            // 
            // txtHoraInicio
            // 
            this.txtHoraInicio.Location = new System.Drawing.Point(265, 12);
            this.txtHoraInicio.Mask = "00:00";
            this.txtHoraInicio.Name = "txtHoraInicio";
            this.txtHoraInicio.Size = new System.Drawing.Size(62, 20);
            this.txtHoraInicio.TabIndex = 1;
            this.txtHoraInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHoraInicio.ValidatingType = typeof(System.DateTime);
            // 
            // txtHoraFinal
            // 
            this.txtHoraFinal.Location = new System.Drawing.Point(265, 38);
            this.txtHoraFinal.Mask = "00:00";
            this.txtHoraFinal.Name = "txtHoraFinal";
            this.txtHoraFinal.Size = new System.Drawing.Size(62, 20);
            this.txtHoraFinal.TabIndex = 3;
            this.txtHoraFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHoraFinal.ValidatingType = typeof(System.DateTime);
            // 
            // frmMarcacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 222);
            this.Controls.Add(this.txtHoraFinal);
            this.Controls.Add(this.txtHoraInicio);
            this.Controls.Add(this.txtDataFinal);
            this.Controls.Add(this.txtDataInicio);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnPesquisa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.cmbIdTipoTratamento);
            this.Controls.Add(this.txtObs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(675, 260);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(675, 260);
            this.Name = "frmMarcacao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marcações";
            this.Load += new System.EventHandler(this.frmMarcacao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.ComboBox cmbIdTipoTratamento;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.MaskedTextBox txtDataInicio;
        private System.Windows.Forms.MaskedTextBox txtDataFinal;
        private System.Windows.Forms.MaskedTextBox txtHoraInicio;
        private System.Windows.Forms.MaskedTextBox txtHoraFinal;
    }
}