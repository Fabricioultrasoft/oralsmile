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
    }
}
