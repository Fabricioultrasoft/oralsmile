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

            datagrid(aux);
        }


        private void soNumeros(KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8) //verifica se a tecla pressionada é um algarismo ou tecla backspace
                e.Handled = true;
        }


        private void datagrid(Cliente[] aux)
        {
            //Preencher Datagrid
            DataTable tabela = new DataTable("Cli");
            tabela.Columns.Add("idCliente");
            tabela.Columns.Add("n_cliente");
            tabela.Columns.Add("nome");
            tabela.Columns.Add("apelidos");
            tabela.Columns.Add("morada");
            tabela.Columns.Add("localidade");
            tabela.Columns.Add("telefone");
            tabela.Columns.Add("telemovel");

            DataRow row;
            DataView view;

            if (aux != null)
            {
                // Create new DataRow objects and add to DataTable.    
                for (int i = 0; i < aux.Length; i++)
                {
                    row = tabela.NewRow();
                    row["idCliente"] = aux[i].IdCliente.ToString();

                    if (aux[i].NumCliente != 0)
                        row["n_cliente"] = aux[i].NumCliente.ToString();

                    row["nome"] = aux[i].Nome;
                    row["apelidos"] = aux[i].Apelidos;
                    row["morada"] = aux[i].Morada;
                    row["localidade"] = aux[i].Localidade;
                    row["telefone"] = aux[i].Telefone.ToString();
                    row["telemovel"] = aux[i].Telemovel.ToString();
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
            dgClientes.Columns["n_cliente"].Width = 54;
            dgClientes.Columns["n_cliente"].ReadOnly = true;
            dgClientes.Columns["n_cliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgClientes.Columns["nome"].HeaderText = "Nome";
            dgClientes.Columns["nome"].Width = 160;
            dgClientes.Columns["nome"].ReadOnly = true;

            dgClientes.Columns["apelidos"].HeaderText = "Apelidos";
            dgClientes.Columns["apelidos"].Width = 156;
            dgClientes.Columns["apelidos"].ReadOnly = true;

            dgClientes.Columns["morada"].HeaderText = "Morada";
            dgClientes.Columns["morada"].Width = 225;
            dgClientes.Columns["morada"].ReadOnly = true;

            dgClientes.Columns["localidade"].HeaderText = "Localidade";
            dgClientes.Columns["localidade"].Width = 100;
            dgClientes.Columns["localidade"].ReadOnly = true;

            dgClientes.Columns["telefone"].HeaderText = "Telefone";
            dgClientes.Columns["telefone"].Width = 70;
            dgClientes.Columns["telefone"].ReadOnly = true;
            dgClientes.Columns["telefone"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgClientes.Columns["telemovel"].HeaderText = "Telemovel";
            dgClientes.Columns["telemovel"].Width = 70;
            dgClientes.Columns["telemovel"].ReadOnly = true;
            dgClientes.Columns["telemovel"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!txtProcesso.Text.Equals(string.Empty))
            {
                //carregar datagrid dado o num processo
                Cliente cli = new Cliente();
                Cliente[] aux = cli.pesquisarProcesso(Int32.Parse(txtProcesso.Text));
                datagrid(aux);
            }
            else
            {
                carregarclientes();
            }
        }

        private void txtProcesso_KeyPress(object sender, KeyPressEventArgs e)
        {
            soNumeros(e);
        }
    }
}
