/* Developed by Ertan Tike (ertan.tike@moreum.com) 
   Updated by Gonçalo Martins */

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Calendar
{
    public class Appointment
    {
        private DateTime m_StartDate;
        private DateTime m_EndDate;
        private bool m_Locked = false;
        private Color color = Color.White;
        private Color textColor = Color.Black;
        private Color m_BorderColor = Color.Blue;
        private string m_Title = "";
        internal int m_ConflictCount;
        private int idMarcacao;
        private string obs;


        public Appointment()
        {
            color = Color.White;
            m_BorderColor = Color.Blue;
            m_Title = "New Appointment";
            m_Locked = true;
            idMarcacao = -1;
            obs = string.Empty;
        }


        public Appointment(string appointment)
        {
            color = Color.White;
            m_BorderColor = Color.Blue;
            m_Title = appointment;
            m_Locked = true;
            idMarcacao = -1;
            obs = string.Empty;
        }


        public int IdMarcacao
        {
            set
            {
                this.idMarcacao = value;
            }
            get
            {
                return this.idMarcacao;
            }
        }


        public string Obervacoes
        {
            set
            {
                this.obs = value;
            }
            get
            {
                return this.obs;
            }
        }


        public DateTime StartDate
        {
            get
            {
                return m_StartDate;
            }
            set
            {
                m_StartDate = value;
                OnStartDateChanged();

            }
        }
        protected virtual void OnStartDateChanged()
        {
        }


        public DateTime EndDate
        {
            get
            {
                return m_EndDate;
            }
            set
            {
                m_EndDate = value;
                OnEndDateChanged();
            }
        }
        protected virtual void OnEndDateChanged()
        {
        }

        [System.ComponentModel.DefaultValue(false)]
        public bool Locked
        {
            get { return m_Locked; }
            set
            {
                m_Locked = value;
                OnLockedChanged();
            }
        }

        protected virtual void OnLockedChanged()
        {
        }


        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }


        public Color TextColor
        {
            get 
            { 
                return textColor;
            }
            set 
            { 
                textColor = value; 
            }
        }


        public Color BorderColor
        {
            get
            {
                return m_BorderColor;
            }
            set
            {
                m_BorderColor = value;
            }
        }


        [System.ComponentModel.DefaultValue("")]
        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
                OnTitleChanged();
            }
        }

        protected virtual void OnTitleChanged()
        {
        }
    }
}
