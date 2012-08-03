using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Calendar.Cls;
using System.Data.SqlClient;

namespace Calendar
{
    public partial class frmPesquisaCliente : Form
    {
        private Cliente cliente;

        public frmPesquisaCliente()
        {
            this.cliente = new Cliente();
            InitializeComponent();
        }


        public Cliente Cliente
        {
            set
            {
                this.cliente = value;
            }
            get
            {
                return this.cliente;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.cliente = new Cliente();
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();
            Cliente[] aux = cli.pesquisarClientes(chkBoxProcesso.Checked, chkBoxNome.Checked, chkBoxApelidos.Checked, cmbWhere.SelectedItem.ToString(), txtProcesso.Text, txtNome.Text, txtApelidos.Text);
        }

        private void frmPesquisaCliente_Load(object sender, EventArgs e)
        {
            cmbWhere.SelectedIndex = 0;
        }
    }
}
