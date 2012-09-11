using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Calendar.Cls;

namespace Calendar
{
    public partial class Form1 : Form
    {
        List<Appointment> m_Appointments;
        private Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();

            m_Appointments = new List<Appointment>();

            dayView1.StartDate = DateTime.Now;
            dayView1.NewAppointment += new NewAppointmentEventHandler(dayView1_NewAppointment);
            dayView1.SelectionChanged += new EventHandler(dayView1_SelectionChanged);
            dayView1.ResolveAppointments += new Calendar.ResolveAppointmentsEventHandler(this.dayView1_ResolveAppointments);

            dayView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dayView1_MouseMove);

            comboBox1.SelectedIndex = 1;
            dayView1.HalfHourHeight = trackBar1.Value;

            timer.Tick += new EventHandler(timer_Tick); 
            timer.Interval = (1000) * (150);              
            timer.Enabled = true;                       
            timer.Start();                              


            carregarMarcacoes();
        }


        void timer_Tick(object sender, EventArgs e)
        {
            m_Appointments.Clear();
            carregarMarcacoes();
            
            //Comparar numero 
        }


        private void carregarMarcacoes()
        {
            //Carregamento das marcações
            Marcacao marca = new Marcacao();
            Marcacao[] aux = marca.todasMarcacoes();

            Appointment app;
            for (int i = 0; i < aux.Length; i++)
            {
                app = new Appointment();
                app.StartDate = aux[i].DataHoraInicio;
                app.EndDate = aux[i].DataHoraFim;
                app.IdMarcacao = aux[i].IdMarcacao;
                app.Obervacoes = aux[i].Observacoes;
                app.Color = Color.FromArgb(int.Parse(aux[i].Cor.ToString()));

                Cliente cli = new Cliente();
                cli = cli.pesquisaCliente(aux[i].IdCliente);

                TipoTratamento tipo = new TipoTratamento();
                tipo = tipo.pesquisarTipo(aux[i].IdTipoTratamento);

                if (aux[i].Observacoes.Equals(string.Empty))
                    app.Title = "Proc: " + cli.NumCliente + "-" + cli.Nome + " " + cli.Apelidos + " - " + tipo.Descricao;
                else
                    app.Title = "Proc: " + cli.NumCliente + "-" + cli.Nome + " " + cli.Apelidos + " - " + tipo.Descricao + "\n\rObs: " + aux[i].Observacoes;

                m_Appointments.Add(app);
            }
        }

        void dayView1_NewAppointment(object sender, NewAppointmentEventArgs args)
        {
            Appointment m_Appointment = new Appointment();

            m_Appointment.StartDate = args.StartDate;
            m_Appointment.EndDate = args.EndDate;
            m_Appointment.Title = args.Title;

            m_Appointments.Add(m_Appointment);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dayView1.DaysToShow = int.Parse( textBox1.Text );
        }

        private void dayView1_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Text = dayView1.GetTimeAt(e.X, e.Y).ToString();
        }

        private void dayView1_SelectionChanged(object sender, EventArgs e)
        {
            label3.Text = dayView1.SelectionStart.ToString() + ":" + dayView1.SelectionEnd.ToString();
        }

        private void dayView1_ResolveAppointments(object sender, ResolveAppointmentsEventArgs args)
        {
            List<Appointment> m_Apps = new List<Appointment>();

            foreach (Appointment m_App in m_Appointments)
                if ((m_App.StartDate >= args.StartDate) &&
                    (m_App.StartDate <= args.EndDate))
                    m_Apps.Add(m_App);

            args.Appointments = m_Apps;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMarcacao form = new frmMarcacao();

            if (!dayView1.SelectionStart.ToShortDateString().Equals("01-01-0001"))
            {
                form.Appointment.DataHoraInicio = dayView1.SelectionStart;
                form.Appointment.DataHoraFim = dayView1.SelectionEnd;
            }

            form.ShowDialog();
            Marcacao marca = form.Appointment;

            if(marca.IdCliente != -1 )//&& marca.IdCliente > 0 && marca.IdTipoTratamento > 0)
            {
                Appointment app = new Appointment();
                app.StartDate = marca.DataHoraInicio;
                app.EndDate = marca.DataHoraFim;
                app.IdMarcacao = marca.IdMarcacao;
                app.Obervacoes = marca.Observacoes;

                //Registo na base de dados
                marca.criarMarcacao(marca.IdCliente, marca.DataHoraInicio, marca.DataHoraFim, marca.IdTipoTratamento, marca.Observacoes, -1);

                int id = marca.saberID(marca.IdCliente, marca.DataHoraInicio, marca.DataHoraFim, marca.IdTipoTratamento);
                app.IdMarcacao = id;

                Cliente cli = new Cliente();
                cli = cli.pesquisaCliente(marca.IdCliente);

                TipoTratamento tipo = new TipoTratamento();
                tipo = tipo.pesquisarTipo(marca.IdTipoTratamento);

                if (marca.Observacoes.Equals(string.Empty))
                    app.Title = "Proc: " + cli.NumCliente + "-" + cli.Nome + " " + cli.Apelidos + " - " + tipo.Descricao;
                else
                    app.Title = "Proc: " + cli.NumCliente + "-" + cli.Nome + " " + cli.Apelidos + " - " + tipo.Descricao + "\n\rObs: " + marca.Observacoes;

                m_Appointments.Add(app);

                dayView1.Invalidate();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            dayView1.DaysToShow = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dayView1.DaysToShow = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dayView1.DaysToShow = 5;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dayView1.DaysToShow = 7;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Office 11")
            {
                dayView1.Renderer = new Office11Renderer();
            }
            else
            {
                dayView1.Renderer = new Office12Renderer();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dayView1.SelectedAppointment != null)
            {
                colorDialog1.Color = dayView1.SelectedAppointment.Color;

                if (colorDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    dayView1.SelectedAppointment.Color = colorDialog1.Color;

                    Marcacao marca = new Marcacao();
                    marca = marca.saberMarcacao(dayView1.SelectedAppointment.IdMarcacao);
                    marca.Cor = dayView1.SelectedAppointment.Color.ToArgb();
                    marca.editarMarcacao(dayView1.SelectedAppointment.IdMarcacao, marca.IdCliente, marca.DataHoraInicio, marca.DataHoraFim, marca.IdTipoTratamento, marca.Observacoes, marca.Cor);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dayView1.SelectedAppointment != null)
            {
                colorDialog1.Color = dayView1.SelectedAppointment.BorderColor;

                if (colorDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    dayView1.SelectedAppointment.BorderColor = colorDialog1.Color;
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            dayView1.HalfHourHeight = trackBar1.Value;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            dayView1.StartDate = monthCalendar1.SelectionStart;
        }

        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            frmNovoCliente form = new frmNovoCliente();
            form.Novo = true;
            form.ShowDialog();
        }

        private void dayView1_DoubleClick(object sender, EventArgs e)
        {
            if (dayView1.SelectedAppointment != null && dayView1.SelectedAppointment.IdMarcacao != -1)
            {
                frmMarcacao marca = new frmMarcacao();
                marca.Appointment.DataHoraFim = dayView1.SelectedAppointment.EndDate;
                marca.Appointment.DataHoraInicio = dayView1.SelectedAppointment.StartDate;
                marca.Appointment.Observacoes = dayView1.SelectedAppointment.Obervacoes;
                marca.Appointment.IdMarcacao = dayView1.SelectedAppointment.IdMarcacao;

                //Saber idCliente e idTipoTratamento desde Marcação
                Marcacao aux = new Marcacao();
                aux = aux.saberMarcacao(marca.Appointment.IdMarcacao);

                marca.Appointment.IdCliente = aux.IdCliente;
                marca.Appointment.IdTipoTratamento = aux.IdTipoTratamento;
                marca.Appointment.Cor = aux.Cor;

                marca.ShowDialog();

                if (marca.Appointment.IdMarcacao != -1)
                {
                    marca.Appointment.editarMarcacao(marca.Appointment.IdMarcacao, marca.Appointment.IdCliente, marca.Appointment.DataHoraInicio, marca.Appointment.DataHoraFim, marca.Appointment.IdTipoTratamento, marca.Appointment.Observacoes, marca.Appointment.Cor);

                    m_Appointments.Remove(dayView1.SelectedAppointment);

                    Appointment app = new Appointment();
                    app.IdMarcacao = marca.Appointment.IdMarcacao;
                    app.StartDate = marca.Appointment.DataHoraInicio;
                    app.EndDate = marca.Appointment.DataHoraFim;
                    app.Obervacoes = marca.Appointment.Observacoes;
                    app.Color = Color.FromArgb(int.Parse(marca.Appointment.Cor.ToString()));

                    Cliente cli = new Cliente();
                    cli = cli.pesquisaCliente(marca.Appointment.IdCliente);

                    TipoTratamento tipo = new TipoTratamento();
                    tipo = tipo.pesquisarTipo(marca.Appointment.IdTipoTratamento);

                    if (marca.Appointment.Observacoes.Equals(string.Empty))
                        app.Title = "Proc: " + cli.NumCliente + "-" + cli.Nome + " " + cli.Apelidos + " - " + tipo.Descricao;
                    else
                        app.Title = "Proc: " + cli.NumCliente + "-" + cli.Nome + " " + cli.Apelidos + " - " + tipo.Descricao + "\n\rObs: " + marca.Appointment.Observacoes;

                    m_Appointments.Add(app);
                    dayView1.Invalidate();
                }
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes cli = new frmClientes();
            cli.ShowDialog();
        }

        private void mItemAtrasada_Click(object sender, EventArgs e)
        {
            if (dayView1.SelectedAppointment != null)
            {
                escolherCor(sender, dayView1);
            }
        }

        private void mItemChegou_Click(object sender, EventArgs e)
        {
            if (dayView1.SelectedAppointment != null)
            {
                escolherCor(sender, dayView1);
            }
        }

        private void mItemOK_Click(object sender, EventArgs e)
        {
            if (dayView1.SelectedAppointment != null)
            {
                escolherCor(sender, dayView1);
            }
        }


        private void escolherCor(object sender, DayView vista)
        {
            Marcacao marca = new Marcacao();
            marca = marca.saberMarcacao(vista.SelectedAppointment.IdMarcacao);

            if (((ToolStripMenuItem)sender).Name.Equals("mItemAtrasado"))
            {
                marca.Cor = Color.Yellow.ToArgb();
                vista.SelectedAppointment.Color = Color.Yellow;
            }
            else if (((ToolStripMenuItem)sender).Name.Equals("mItemOK"))
            {
                marca.Cor = Color.Green.ToArgb();
                vista.SelectedAppointment.Color = Color.Green;
            }
            else if (((ToolStripMenuItem)sender).Name.Equals("mItemUrgencia"))
            {
                marca.Cor = Color.Red.ToArgb();
                vista.SelectedAppointment.Color = Color.Red;
            }
            else if (((ToolStripMenuItem)sender).Name.Equals("mItemChegou"))
            {
                marca.Cor = Color.Blue.ToArgb();
                vista.SelectedAppointment.Color = Color.Blue;
            }
            else if (((ToolStripMenuItem)sender).Name.Equals("mItemFaltou"))
            {
                marca.Cor = Color.Black.ToArgb();
                vista.SelectedAppointment.Color = Color.Black;
            }
            else
            {
                marca.Cor = Color.White.ToArgb();
                vista.SelectedAppointment.Color = Color.White;
            }
            marca.editarMarcacao(vista.SelectedAppointment.IdMarcacao, marca.IdCliente, marca.DataHoraInicio, marca.DataHoraFim, marca.IdTipoTratamento, marca.Observacoes, marca.Cor);
        }

        private void mItemChegou_Click_1(object sender, EventArgs e)
        {
            if (dayView1.SelectedAppointment != null)
            {
                escolherCor(sender, dayView1);
            }
        }

        private void mItemFaltou_Click(object sender, EventArgs e)
        {
            if (dayView1.SelectedAppointment != null)
            {
                escolherCor(sender, dayView1);
            }
        }

        private void mItemApagar_Click(object sender, EventArgs e)
        {
            if (dayView1.SelectedAppointment != null)
            {
                escolherCor(sender, dayView1);
            }
        }
    }
}