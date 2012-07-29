﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Calendar.Cls;

namespace Calendar
{
    public partial class frmNovoCliente : Form
    {
        public frmNovoCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();
            cli.Nome = txtNome.Text;
            cli.Apelidos = txtApelidos.Text;
            cli.Morada = txtMorada.Text;
            cli.Localidade = txtLocalidade.Text;
            cli.CodigoPostal = Int32.Parse(txtCodPostal.Text);
            cli.CodigoPostal_3Digitos = Int32.Parse(txtCodPostal_1.Text);
            cli.Telefone = Int32.Parse(txtTelefone.Text);
            cli.Telefone = Int32.Parse(txtTelemovel.Text);
            cli.BI = long.Parse(txtBI.Text);
            cli.NumContribuiente = long.Parse(txtContribuinte.Text);
            cli.NumUtente = long.Parse(txtNumUtente.Text);
            cli.Seguro = txtSeguro.Text;
            cli.Profissao = txtProcesso.Text;

            try
            {
                if (cli.IdCliente == -1)
                {
                    cli.novoCliente();
                    DialogResult resposta = MessageBox.Show("Novo cliente " + cli.Nome + " " + cli.Apelidos + " registado correctamente.", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (resposta == System.Windows.Forms.DialogResult.Yes)
                    {
                        limparCampos();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                    cli.editarCliente();
            }
            catch (Exception)
            {
                MessageBox.Show("Campos obrigatórios em falta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void limparCampos()
        {
            txtApelidos.Text = string.Empty;
            txtBI.Text = string.Empty;
            txtCodPostal.Text = string.Empty;
            txtCodPostal_1.Text = string.Empty;
            txtContribuinte.Text = string.Empty;
            txtLocalidade.Text = string.Empty;
            txtMorada.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtNumUtente.Text = string.Empty;
            txtProcesso.Text = string.Empty;
            txtProfissao.Text = string.Empty;
            txtSeguro.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtTelemovel.Text = string.Empty;
            txtNumUtente.Focus();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
