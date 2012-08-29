using System;
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
    public partial class frmMarcacao : Form
    {
        private Marcacao marcacao;
        private bool leitura;

        public frmMarcacao()
        {
            //Inicialização do objecto Marcação
            this.marcacao = new Marcacao();
            this.leitura = false;

            InitializeComponent();
        }

        public bool Leitura
        {
            set
            {
                this.leitura = value;
            }
            get
            {
                return this.leitura;
            }
        }

        public Marcacao Appointment
        {
            set
            {
                this.marcacao = value;
            }
            get
            {
                return this.marcacao;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                marcacao.Observacoes = txtObs.Text;
                marcacao.DataHoraInicio = Convert.ToDateTime(txtDataInicio.Text + " " + txtHoraInicio.Text);
                marcacao.DataHoraFim = Convert.ToDateTime(txtDataFinal.Text + " " + txtHoraFinal.Text);
                marcacao.IdTipoTratamento = (cmbIdTipoTratamento.SelectedItem as Item).ID;
                marcacao.IdCliente = (cmbCliente.SelectedItem as Item).ID;


                if(cmbCliente.SelectedIndex > 0 && cmbIdTipoTratamento.SelectedIndex > 0)
                    this.Close();
                else
                    MessageBox.Show("Campos Cliente e/ou Tipo de Tratamento Incorrecto(s)", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception)
            {
                MessageBox.Show("Datas Incorrectas", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmMarcacao_Load(object sender, EventArgs e)
        {
            this.Height = 250;

            if (!marcacao.DataHoraInicio.ToShortDateString().Equals("01-01-0001"))
            {
                txtDataInicio.Text = marcacao.DataHoraInicio.ToShortDateString();
                txtHoraInicio.Text = marcacao.DataHoraInicio.ToShortTimeString();
                txtDataFinal.Text = marcacao.DataHoraFim.ToShortDateString();
                txtHoraFinal.Text = marcacao.DataHoraFim.ToShortTimeString();
            }

            //Carregar ComboBox Clientes
            carregarClientes();


            //Carregar ComboBox Tipos de Tratamento
            carregarTiposTratamento();

            if (marcacao.IdMarcacao != -1)
            {
                txtObs.Text = marcacao.Observacoes;

                for (int i = 0; i < cmbCliente.Items.Count; i++)
                {
                    if (marcacao.IdCliente == (cmbCliente.Items[i] as Item).ID)
                    {
                        cmbCliente.SelectedIndex = i;
                        break;
                    }
                }

                for (int j = 0; j < cmbIdTipoTratamento.Items.Count; j++)
                {
                    if (marcacao.IdTipoTratamento == (cmbIdTipoTratamento.Items[j] as Item).ID)
                    {
                        cmbIdTipoTratamento.SelectedIndex = j;
                        break;
                    }
                }
            }

            if (this.leitura)
            {
                btnOK.Visible = false;
                btnHistorico.Visible = false;
                txtObs.ReadOnly = true;
                txtDataFinal.ReadOnly = true;
                txtDataInicio.ReadOnly = true;
                txtHoraInicio.ReadOnly = true;
                txtHoraFinal.ReadOnly = true;
                cmbCliente.Enabled = false;
                cmbIdTipoTratamento.Enabled = false;
                btnPesquisa.Visible = false;

                txtObs.BackColor = Color.White;
                txtDataFinal.BackColor = Color.White;
                txtDataInicio.BackColor = Color.White;
                txtHoraFinal.BackColor = Color.White;
                txtHoraInicio.BackColor = Color.White;
            }
            else
            {
                btnOK.Visible = true;
                btnHistorico.Visible = true;
                txtObs.ReadOnly = false;
                txtDataFinal.ReadOnly = false;
                txtDataInicio.ReadOnly = false;
                txtHoraInicio.ReadOnly = false;
                txtHoraFinal.ReadOnly = false;
                cmbCliente.Enabled = true;
                cmbIdTipoTratamento.Enabled = true;
                btnPesquisa.Visible = true;
            }
        }


        private void carregarTiposTratamento()
        {
            TipoTratamento aux = new TipoTratamento();
            TipoTratamento[] tipos = aux.todosTipos();

            cmbIdTipoTratamento.Items.Clear();
            cmbIdTipoTratamento.DisplayMember = "Texto";
            cmbIdTipoTratamento.ValueMember = "ID";

            cmbIdTipoTratamento.Items.Add(new Item("Seleccione...", 0));
            cmbIdTipoTratamento.SelectedIndex = 0;

            for (int i = 0; i < tipos.Length; i++)
            {
                cmbIdTipoTratamento.Items.Add(new Item(tipos[i].Descricao, tipos[i].IdTipoTratamento));
            }
        }


        private void carregarClientes()
        {
            Cliente cli = new Cliente();
            Cliente[] lista = cli.todosClientes();

            cmbCliente.Items.Clear();
            cmbCliente.DisplayMember = "Texto";
            cmbCliente.ValueMember = "ID";

            cmbCliente.Items.Add(new Item("Seleccione...", 0));
            cmbCliente.SelectedIndex = 0;

            for (int i = 0; i < lista.Length; i++)
            {
                cmbCliente.Items.Add(new Item(lista[i].Nome + " " + lista[i].Apelidos, lista[i].IdCliente));
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.marcacao = new Marcacao();
            this.Close();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            frmPesquisaCliente form = new frmPesquisaCliente();
            form.ShowDialog();

            Cliente cli = form.Cliente;

            if (cli.IdCliente != -1)
            {
                for (int i = 0; i < cmbCliente.Items.Count; i++)
                {
                    if (((Item)cmbCliente.Items[i]).ID == cli.IdCliente)
                    {
                        cmbCliente.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
                cmbCliente.SelectedIndex = 0;
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            if (this.Height == 250)
            {
                if (cmbCliente.SelectedIndex > 0)
                {
                    //Carregar Marcações
                    Marcacao[] marca;
                    Marcacao aux = new Marcacao();
                    marca = aux.saberMarcacaoCliente(((Item)cmbCliente.Items[cmbCliente.SelectedIndex]).ID);

                    //Carregar Datagrid
                    carregarHistorico(marca);

                    this.Height = 500;
                }
            }
            else
                this.Height = 250;

        }

        private void carregarHistorico(Marcacao[] aux)
        {
            //Preencher Datagrid
            DataTable tabela = new DataTable("Cli");
            tabela.Columns.Add("idMarcacao");
            tabela.Columns.Add("datahora_inicio");
            //tabela.Columns.Add("datahora_fim");
            tabela.Columns.Add("tipoTratamento");
            tabela.Columns.Add("Observacoes");

            DataRow row;
            DataView view;

            if (aux[0] != null)
            {
                // Create new DataRow objects and add to DataTable.    
                for (int i = 0; i < aux.Length; i++)
                {
                    row = tabela.NewRow();
                    row["idMarcacao"] = aux[i].IdMarcacao.ToString();
                    row["datahora_inicio"] = aux[i].DataHoraInicio.ToShortDateString();
                    //row["datahora_fim"] = aux[i].DataHoraFim.ToShortDateString();

                    //Descrição idTipoTratamento
                    TipoTratamento tipo = new TipoTratamento();
                    tipo = tipo.pesquisarTipo(aux[i].IdTipoTratamento);
                    row["tipoTratamento"] = tipo.Descricao;
                    row["observacoes"] = aux[i].Observacoes;
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

            dgClientes.Columns["idMarcacao"].Visible = false;

            dgClientes.Columns["idMarcacao"].HeaderText = "idMarcacao";
            dgClientes.Columns["idMarcacao"].Width = 40;
            dgClientes.Columns["idMarcacao"].ReadOnly = true;

            dgClientes.Columns["datahora_inicio"].HeaderText = "Data";
            dgClientes.Columns["datahora_inicio"].Width = 70;
            dgClientes.Columns["datahora_inicio"].ReadOnly = true;

            //dgClientes.Columns["datahora_fim"].HeaderText = "Data Fim";
            //dgClientes.Columns["datahora_fim"].Width = 225;
            //dgClientes.Columns["datahora_fim"].ReadOnly = true;

            dgClientes.Columns["tipoTratamento"].HeaderText = "Tipo Tratamento";
            dgClientes.Columns["tipoTratamento"].Width = 100;
            dgClientes.Columns["tipoTratamento"].ReadOnly = true;

            dgClientes.Columns["observacoes"].HeaderText = "Observações";
            dgClientes.Columns["observacoes"].Width = 400;
            dgClientes.Columns["observacoes"].ReadOnly = true;

            dgClientes.MultiSelect = false;
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Height = 250;
        }
    }
}
