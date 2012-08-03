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
            Cliente[] aux = cli.pesquisarClientes(cmbWhere.SelectedItem.ToString(), txtProcesso.Text, txtNome.Text, txtApelidos.Text);

            //preencher datagrid
            DataTable tabela = new DataTable("Cli");
            tabela.Columns.Add("idCliente");
            tabela.Columns.Add("n_cliente");
            tabela.Columns.Add("nome");
            tabela.Columns.Add("apelidos");

            DataRow row;
            DataView view;

            if (aux[0] != null)
            {
                // Create new DataRow objects and add to DataTable.    
                for (int i = 0; i < aux.Length; i++)
                {
                    row = tabela.NewRow();
                    row["idCliente"] = aux[i].IdCliente.ToString();
                    row["n_cliente"] = aux[i].NumCliente.ToString();
                    row["nome"] = aux[i].Nome;
                    row["apelidos"] = aux[i].Apelidos;
                    tabela.Rows.Add(row);
                }
            }
            // Create a DataView using the DataTable.
            view = new DataView(tabela);

            //BindingSource to sync DataTable and DataGridView
            BindingSource bSource = new BindingSource();

            //set the BindingSource DataSource
            bSource.DataSource = view;

            //set the DataGridView DataSource
            dgClientes.DataSource = bSource;

            dgClientes.Columns["idCliente"].Visible = false;

            dgClientes.Columns["n_cliente"].HeaderText = "Proc.";
            dgClientes.Columns["n_cliente"].Width = 40;
            dgClientes.Columns["n_cliente"].ReadOnly = true;

            dgClientes.Columns["nome"].HeaderText = "Nome";
            dgClientes.Columns["nome"].Width = 190;
            dgClientes.Columns["nome"].ReadOnly = true;

            dgClientes.Columns["apelidos"].HeaderText = "Apelidos";
            dgClientes.Columns["apelidos"].Width = 225;
            dgClientes.Columns["apelidos"].ReadOnly = true;

            dgClientes.MultiSelect = false;
        }

        private void frmPesquisaCliente_Load(object sender, EventArgs e)
        {
            cmbWhere.SelectedIndex = 0;
        }

        private void dgClientes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgClientes.SelectedRows.Count > 0)
            {
                cliente.IdCliente = Int32.Parse(dgClientes.Rows[e.RowIndex].Cells[0].Value.ToString());
                this.Close();
            }
        }
    }
}
