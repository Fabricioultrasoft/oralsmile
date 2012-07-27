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
    }
}
