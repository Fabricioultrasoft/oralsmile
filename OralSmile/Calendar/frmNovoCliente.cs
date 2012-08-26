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
    public partial class frmNovoCliente : Form
    {
        private Cliente cli;
        private int linha;

        public frmNovoCliente()
        {
            InitializeComponent();
            cli = new Cliente();
        }

        public Cliente Cliente
        {
            set
            {
                this.cli = value;
            }
            get
            {
                return this.cli;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                cli.Nome = txtNome.Text;
                cli.Apelidos = txtApelidos.Text;
                cli.Morada = txtMorada.Text;
                cli.Localidade = txtLocalidade.Text;

                if (!txtCodPostal.Text.Equals(string.Empty))
                    cli.CodigoPostal = Int32.Parse(txtCodPostal.Text);
                else
                    cli.CodigoPostal = 0;


                if (!txtCodPostal_1.Text.Equals(string.Empty))
                    cli.CodigoPostal_3Digitos = Int32.Parse(txtCodPostal_1.Text);
                else
                    cli.CodigoPostal_3Digitos = 0;


                if (!txtTelefone.Text.Equals(string.Empty))
                    cli.Telefone = Int32.Parse(txtTelefone.Text);
                else
                    cli.Telefone = 0;


                if (!txtTelemovel.Text.Equals(string.Empty))
                    cli.Telemovel = Int32.Parse(txtTelemovel.Text);
                else
                    cli.Telemovel = 0;


                if (!txtBI.Text.Equals(string.Empty))
                    cli.BI = long.Parse(txtBI.Text);
                else
                    cli.BI = 0;


                if (!txtContribuinte.Text.Equals(string.Empty))
                    cli.NumContribuiente = long.Parse(txtContribuinte.Text);
                else
                    cli.NumContribuiente = 0;


                if (!txtNumUtente.Text.Equals(string.Empty))
                    cli.NumUtente = long.Parse(txtNumUtente.Text);
                else
                    cli.NumUtente = 0;


                cli.Seguro = txtSeguro.Text;
                cli.Profissao = txtProfissao.Text;


                if (!txtProcesso.Text.Equals(string.Empty))
                    cli.NumCliente = long.Parse(txtProcesso.Text);
                else
                    cli.NumCliente = 0;

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
                {
                    cli.editarCliente();
                    MessageBox.Show("Dados actualizados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
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

        private void txtCodPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            soNumeros(e);
        }


        private void soNumeros(KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8) //verifica se a tecla pressionada é um algarismo ou tecla backspace
                e.Handled = true;
        }

        private void txtCodPostal_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            soNumeros(e);
        }

        private void txtTelemovel_KeyPress(object sender, KeyPressEventArgs e)
        {
            soNumeros(e);
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            soNumeros(e);
        }

        private void txtBI_KeyPress(object sender, KeyPressEventArgs e)
        {
            soNumeros(e);
        }

        private void txtContribuinte_KeyPress(object sender, KeyPressEventArgs e)
        {
            soNumeros(e);
        }

        private void frmNovoCliente_Load(object sender, EventArgs e)
        {
            this.Height = 295;
            linha = -1;

            if (cli.IdCliente != -1)
            {
                //carregar dados
                int idAntigo = cli.IdCliente;
                cli = cli.pesquisaCliente(cli.IdCliente);

                cli.IdCliente = idAntigo;
                txtNome.Text = cli.Nome;
                txtApelidos.Text = cli.Apelidos;
                txtMorada.Text = cli.Morada;
                txtLocalidade.Text = cli.Localidade;

                if(cli.CodigoPostal != 0)
                    txtCodPostal.Text = cli.CodigoPostal.ToString();

                if(cli.CodigoPostal_3Digitos != 0)
                    txtCodPostal_1.Text = cli.CodigoPostal_3Digitos.ToString();

                if(cli.Telefone != 0)
                    txtTelefone.Text = cli.Telefone.ToString();

                if(cli.Telemovel != 0)
                    txtTelemovel.Text = cli.Telemovel.ToString();

                if(cli.BI != 0)
                    txtBI.Text = cli.BI.ToString();

                if(cli.NumContribuiente != 0)
                    txtContribuinte.Text = cli.NumContribuiente.ToString();
                
                if(cli.NumUtente != 0)
                    txtNumUtente.Text = cli.NumUtente.ToString();

                txtSeguro.Text = cli.Seguro;

                if(cli.NumCliente != 0)
                    txtProcesso.Text = cli.NumCliente.ToString();

                txtProfissao.Text = cli.Profissao;
            }
            else
                limparCampos();
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            if (this.Height == 295)
            {
                if (cli.IdCliente != -1)
                {
                    //Carregar Datagrid
                    carregarHistorico();
                    dgClientes.ClearSelection();
                    this.Height = 532;
                }
            }
            else
                this.Height = 295;
        }


        private void carregarHistorico()
        {
            //Carregar Marcações
            Marcacao[] aux;
            Marcacao marca = new Marcacao();
            aux = marca.saberMarcacaoCliente(cli.IdCliente);

            //Preencher Datagrid
            DataTable tabela = new DataTable("Cli");
            tabela.Columns.Add("idMarcacao");
            tabela.Columns.Add("datahora_inicio");
            tabela.Columns.Add("datahora_fim");
            tabela.Columns.Add("tipoTratamento");
            tabela.Columns.Add("Observacoes");

            DataRow row;
            DataView view;

            if (aux != null)
            {
                // Create new DataRow objects and add to DataTable.    
                for (int i = 0; i < aux.Length; i++)
                {
                    row = tabela.NewRow();
                    row["idMarcacao"] = aux[i].IdMarcacao.ToString();
                    row["datahora_inicio"] = aux[i].DataHoraInicio.ToShortDateString();
                    row["datahora_fim"] = aux[i].DataHoraFim;

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

            dgClientes.Columns["datahora_fim"].Visible = false;
            dgClientes.Columns["datahora_fim"].HeaderText = "Data Fim";
            dgClientes.Columns["datahora_fim"].Width = 70;
            dgClientes.Columns["datahora_fim"].ReadOnly = true;

            dgClientes.Columns["tipoTratamento"].HeaderText = "Tipo Tratamento";
            dgClientes.Columns["tipoTratamento"].Width = 80;
            dgClientes.Columns["tipoTratamento"].ReadOnly = true;

            dgClientes.Columns["observacoes"].HeaderText = "Observações";
            dgClientes.Columns["observacoes"].Width = 300;
            dgClientes.Columns["observacoes"].ReadOnly = true;

            dgClientes.MultiSelect = false;
        }


        private void dgClientes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            linha = e.RowIndex;
            if (dgClientes.SelectedRows.Count > 0 && linha > -1)
            {
                //Ir a Marcação
                frmMarcacao marca = new frmMarcacao();
                marca.Leitura = true;
                marca.Appointment.IdMarcacao = Int32.Parse(dgClientes.Rows[e.RowIndex].Cells[0].Value.ToString());
                marca.Appointment.IdCliente = cli.IdCliente;

                TipoTratamento tipo = new TipoTratamento();
                tipo = tipo.pesquisarTipo(dgClientes.Rows[e.RowIndex].Cells[3].Value.ToString());
                marca.Appointment.IdTipoTratamento = tipo.IdTipoTratamento;

                Marcacao aux = new Marcacao();
                aux = aux.saberMarcacao(Int32.Parse(dgClientes.Rows[e.RowIndex].Cells[0].Value.ToString()));

                marca.Appointment.DataHoraInicio = aux.DataHoraInicio;
                marca.Appointment.DataHoraFim = DateTime.Parse(dgClientes.Rows[e.RowIndex].Cells[2].Value.ToString());
                marca.Appointment.Observacoes = dgClientes.Rows[e.RowIndex].Cells[4].Value.ToString();
                marca.ShowDialog();
                
                dgClientes.ClearSelection();
            }
        }
    }
}
