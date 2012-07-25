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
            marcacao.Observacoes = txtObs.Text;
            marcacao.DataHoraInicio = Convert.ToDateTime(txtDataInicio.Text + " " + txtHoraInicio.Text);
            marcacao.DataHoraFim = Convert.ToDateTime(txtDataFinal.Text + " " + txtHoraFinal.Text);
            //marcacao.IdTipoTratamento =
            //marcacao.IdCliente =             
        }

        private void cmbIdTipoTratamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string rrr = cmbIdTipoTratamento.SelectedItem.ToString();
            //string hhh = cmbIdTipoTratamento.SelectedValue.ToString();
            //Item ee = (Item)cmbIdTipoTratamento.Items[1];

            //string qwe = ee.Texto;
            //string hop = ee.ID.ToString();
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void frmMarcacao_Load(object sender, EventArgs e)
        {
            //Inicialização do objecto Marcação
            this.marcacao = new Marcacao();

            //Carregar ComboBox Clientes


            //Carregar ComboBox Tipos de Tratamento
            TipoTratamento aux = new TipoTratamento();
            TipoTratamento[] tipos = aux.todosTipos();

            cmbIdTipoTratamento.Items.Clear();
            cmbIdTipoTratamento.DisplayMember = "Texto";
            cmbIdTipoTratamento.ValueMember = "ID";

            cmbIdTipoTratamento.Items.Add(new Item("Seleccione...", 0));
            cmbIdTipoTratamento.SelectedIndex = 0;

            for(int i = 0; i < tipos.Length; i++)
            {
                cmbIdTipoTratamento.Items.Add(new Item(tipos[i].Descricao, tipos[i].IdTipoTratamento));
            }
        }
    }

}
