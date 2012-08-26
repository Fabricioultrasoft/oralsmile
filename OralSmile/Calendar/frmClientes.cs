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
    public partial class frmClientes : Form
    {
        private Cliente cliente;
        public frmClientes()
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


        private void carregarclientes()
        {
            Cliente cli = new Cliente();
            Cliente[] aux = cli.todosClientes();

            //Preencher Datagrid
            DataTable tabela = new DataTable("Cli");
            tabela.Columns.Add("idCliente");
            tabela.Columns.Add("n_cliente");
            tabela.Columns.Add("nome");
            tabela.Columns.Add("apelidos");
            tabela.Columns.Add("morada");
            tabela.Columns.Add("localidade");

            DataRow row;
            DataView view;

            if (aux[0] != null)
            {
                // Create new DataRow objects and add to DataTable.    
                for (int i = 0; i < aux.Length; i++)
                {
                    row = tabela.NewRow();
                    row["idCliente"] = aux[i].IdCliente.ToString();
                    
                    if(aux[i].NumCliente != 0)
                        row["n_cliente"] = aux[i].NumCliente.ToString();

                    row["nome"] = aux[i].Nome;
                    row["apelidos"] = aux[i].Apelidos;
                    row["morada"] = aux[i].Morada;
                    row["localidade"] = aux[i].Localidade;
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

            dgClientes.Columns["morada"].HeaderText = "Morada";
            dgClientes.Columns["morada"].Width = 225;
            dgClientes.Columns["morada"].ReadOnly = true;

            dgClientes.Columns["localidade"].HeaderText = "Localidade";
            dgClientes.Columns["localidade"].Width = 150;
            dgClientes.Columns["localidade"].ReadOnly = true;

            dgClientes.MultiSelect = false;

            dgClientes.ClearSelection();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            carregarclientes();
        }

        private void dgClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgClientes.SelectedRows.Count > 0 && dgClientes.CurrentRow.Index > 0)
            {
                cliente.IdCliente = Int32.Parse(dgClientes.Rows[dgClientes.CurrentRow.Index].Cells[0].Value.ToString());
                frmNovoCliente cli = new frmNovoCliente();
                cli.Cliente = cliente;
                cli.ShowDialog();

                carregarclientes();
            }
        }
    }
}
