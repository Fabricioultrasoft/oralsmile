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
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            if (!txtProcesso.Text.Equals("") && txtNome.Text.Equals("") && txtApelidos.Text.Equals(""))
            {
                SqlParameter p = new SqlParameter("@n_cliente", Int32.Parse(txtProcesso.Text));
                sql = "select idCliente, nome, apelidos, n_cliente from Clientes where c_cliente=@n_cliente";
            }
        }
    }
}
