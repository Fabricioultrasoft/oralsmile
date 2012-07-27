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

        public frmMarcacao()
        {
            //Inicialização do objecto Marcação
            this.marcacao = new Marcacao();

            InitializeComponent();
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

            for (int i = 0; i < cmbCliente.Items.Count; i++)
            {
                if (((Item)cmbCliente.Items[i]).ID == cli.IdCliente)
                {
                    cmbCliente.SelectedIndex = i;
                    break;
                }
            }
        }
    }

}
