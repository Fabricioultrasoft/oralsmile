using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Calendar.Cls
{
    class Marcacao
    {
        private int idMarcacao, idCliente, idTipoTratamento;
        private string observacores;
        private DateTime datahora_inicio, datahora_fim;

        public Marcacao()
        {
            this.idMarcacao = -1;
            this.idCliente = -1;
            this.idTipoTratamento = -1;
            this.observacores = string.Empty;
            this.datahora_fim = new DateTime();
            this.datahora_inicio = new DateTime();
        }


        public Marcacao(int idMarcacao, int idCliente, int idTipoTratamento, DateTime datahora_inicio, DateTime datahora_fim)
        {
            this.idMarcacao = idMarcacao;
            this.idCliente = idCliente;
            this.idTipoTratamento = idTipoTratamento;
            this.observacores = string.Empty;
            this.datahora_fim = datahora_fim;
            this.datahora_inicio = datahora_inicio;
        }


        public Marcacao(int idMarcacao, int idCliente, int idTipoTratamento, DateTime datahora_inicio, DateTime datahora_fim, string obs)
        {
            this.idMarcacao = idMarcacao;
            this.idCliente = idCliente;
            this.idTipoTratamento = idTipoTratamento;
            this.observacores = string.Empty;
            this.datahora_fim = datahora_fim;
            this.datahora_inicio = datahora_inicio;
            this.observacores = obs;
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


        public int IdCliente
        {
            set
            {
                this.idCliente = value;
            }
            get
            {
                return this.idCliente;
            }
        }

        public int IdTipoTratamento
        {
            set
            {
                this.idTipoTratamento = value;
            }
            get
            {
                return this.idTipoTratamento;
            }
        }


        public string Observacoes
        {
            set
            {
                this.observacores = value;
            }
            get
            {
                return this.observacores;
            }
        }


        public DateTime DataHoraInicio
        {
            set
            {
                this.datahora_inicio = value;
            }
            get
            {
                return this.datahora_inicio;
            }
        }


        public DateTime DataHoraFim
        {
            set
            {
                this.datahora_fim = value;
            }
            get
            {
                return this.datahora_fim;
            }
        }


        public bool criarMarcacao(int idCliente, DateTime datahora_inicio, DateTime datahora_fim, int idTipoTrat, string obs)
        {
            SqlParameter[] p = new SqlParameter[5];

            for(int i=0; i < p.Length; i++)
            {
                p[i] = new SqlParameter();
                p[i].Direction = System.Data.ParameterDirection.Input;
            }

            p[0].ParameterName = "@idCliente";
            p[0].Value = idCliente;

            p[1].ParameterName = "@idTipoTratamento";
            p[1].Value = idTipoTrat;

            p[2].ParameterName = "@Observacoes";
            p[2].Value = obs;

            p[3].ParameterName = "@datahora_inicio";
            p[3].Value = datahora_inicio;

            p[4].ParameterName = "@datahora_fim";
            p[4].Value = datahora_fim;

            DataBase db = new DataBase();

            db.executaSQLTrasact("criarMarcacao", p, false, out p);

            if (p[0] == null)
                return true;
            else
                return false;
        }


        public bool editarMarcacao(int idMarcacao, int idCliente, DateTime datahora_inicio, DateTime datahora_fim, int idTipoTrat, string obs)
        {
            SqlParameter[] p = new SqlParameter[6];

            for (int i = 0; i < p.Length; i++)
            {
                p[i] = new SqlParameter();
                p[i].Direction = System.Data.ParameterDirection.Input;
            }

            p[0].ParameterName = "@idCliente";
            p[0].Value = idCliente;

            p[1].ParameterName = "@idTipoTratamento";
            p[1].Value = idTipoTrat;

            p[2].ParameterName = "@Observacoes";
            p[2].Value = obs;

            p[3].ParameterName = "@datahora_inicio";
            p[3].Value = datahora_inicio;

            p[4].ParameterName = "@datahora_fim";
            p[4].Value = datahora_fim;

            p[5].ParameterName = "@idMarcacao";
            p[5].Value = idMarcacao;

            DataBase db = new DataBase();

            db.executaSQLTrasact("editarMarcacao", p, false, out p);

            if (p[0] == null)
                return true;
            else
                return false;
        }


        public bool eliminarMarcacao(int idMarcacao)
        {
            SqlParameter[] p = new SqlParameter[1];

            for (int i = 0; i < p.Length; i++)
            {
                p[i] = new SqlParameter();
                p[i].Direction = System.Data.ParameterDirection.Input;
            }

            p[0].ParameterName = "@idMarcacao";
            p[0].Value = idMarcacao;

            DataBase db = new DataBase();

            db.executaSQLTrasact("eliminarMarcacao", p, false, out p);

            if (p[0] == null)
                return true;
            else
                return false;
        }


        public Marcacao[] todasMarcacoes()
        {
            Marcacao[] marca = new Marcacao[contarMarcacoes()];
            DataBase db = new DataBase();

            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter();

            SqlDataReader dr = db.executaSQLParams("Select idMarcacao, datahora_inicio, datahora_fim, observacoes, idCliente, idTipoTratamento from Marcacoes;", p, false);


            if (dr.HasRows)
            {
                int x = 0;
                while (dr.Read())
                {
                    marca[x] = new Marcacao(Int32.Parse(dr[0].ToString()), Int32.Parse(dr[4].ToString()), Int32.Parse(dr[5].ToString()), DateTime.Parse(dr[1].ToString()), DateTime.Parse(dr[2].ToString()), dr[3].ToString());
                    x++;
                }
            }

            return marca;
        }


        private int contarMarcacoes()
        {
            DataBase db = new DataBase();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter();
            
            SqlDataReader dr = db.executaSQLParams("select count(*) from Marcacoes;", p, false);

            if (dr.HasRows)
            {
                dr.Read();
                return Int32.Parse(dr[0].ToString());
            }
            return -1;
        }
    }
}
