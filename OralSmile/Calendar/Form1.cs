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

                Cliente cli = new Cliente();
                cli = cli.pesquisaCliente(aux[i].IdCliente);

                TipoTratamento tipo = new TipoTratamento();
                tipo = tipo.pesquisarTipo(aux[i].IdTipoTratamento);

                if (aux[i].Observacoes.Equals(string.Empty))
                    app.Title = cli.Nome + " " + cli.Apelidos + " - " + tipo.Descricao;
                else
                    app.Title = cli.Nome + " " + cli.Apelidos + " - " + tipo.Descricao + "\n\rObs: " + aux[i].Observacoes;

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
            /*Appointment m_App = new Appointment();
            m_App.StartDate = dayView1.SelectionStart;
            m_App.EndDate = dayView1.SelectionEnd;
            m_App.BorderColor = Color.Red;

            m_Appointments.Add(m_App);*/

            frmMarcacao form = new frmMarcacao();            
            form.ShowDialog();
            Marcacao marca = form.Appointment;

            Appointment app = new Appointment();
            app.StartDate = marca.DataHoraInicio;
            app.EndDate = marca.DataHoraFim;
            app.IdMarcacao = marca.IdMarcacao;
            app.Obervacoes = marca.Observacoes;

            Cliente cli = new Cliente();
            cli = cli.pesquisaCliente(marca.IdCliente);

            TipoTratamento tipo = new TipoTratamento();
            tipo = tipo.pesquisarTipo(marca.IdTipoTratamento);

            if (marca.Observacoes.Equals(string.Empty))
                app.Title = cli.Nome + " " + cli.Apelidos + " - " + tipo.Descricao;
            else
                app.Title = cli.Nome + " " + cli.Apelidos + " - " + tipo.Descricao + "\n\rObs: " + marca.Observacoes;

            m_Appointments.Add(app);

            dayView1.Invalidate();
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
    }
}