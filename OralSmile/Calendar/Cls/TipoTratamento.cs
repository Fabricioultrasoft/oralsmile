using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Calendar.Cls
{
    class TipoTratamento
    {
        private int idTipoTratamento;
        private string descricao;

        public TipoTratamento()
        {
            this.idTipoTratamento = -1;
            this.descricao = string.Empty;
        }


        public TipoTratamento(int idTipoTratamento, string descricao)
        {
            this.idTipoTratamento = idTipoTratamento;
            this.descricao = descricao;
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


        public string Descricao
        {
            set
            {
                this.descricao = value;
            }
            get
            {
                return this.descricao;
            }
        }


        public TipoTratamento pesquisarTipo(int idTipo)
        {
            TipoTratamento aux = new TipoTratamento();

            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@idTipo", idTipo);
            p[1] = new SqlParameter();
            p[1].ParameterName = "@descricao";
            p[1].Direction = System.Data.ParameterDirection.Output;

            DataBase db = new DataBase();

            db.executaSQLTrasact("selectTipoTratamento", p, true, out p);

            aux.Descricao = p[0].Value.ToString();

            return aux;
        }


        public TipoTratamento pesquisarTipo(string descricao)
        {
            TipoTratamento aux = new TipoTratamento();

            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@descricao", descricao);
            p[1] = new SqlParameter();
            p[1].ParameterName = "@idTipo";
            p[1].Direction = System.Data.ParameterDirection.Output;

            DataBase db = new DataBase();

            db.executaSQLTrasact("selectTipoDescricao", p, true, out p);

            aux.IdTipoTratamento = Int32.Parse(p[0].Value.ToString());

            return aux;
        }


        public TipoTratamento[] todosTipos()
        {
            TipoTratamento[] tipos = new TipoTratamento[contarTipos()];

            DataBase db = new DataBase();

            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter();

            SqlDataReader dr = db.executaSQLParams("Select idTipoTratamento, descricao from TiposTratamento;", p, false);


            if (dr.HasRows)
            {
                int x = 0;
                while (dr.Read())
                {
                    tipos[x] = new TipoTratamento(Int32.Parse(dr[0].ToString()), dr[1].ToString());
                    x++;
                }
            }

            return tipos;
        }

        private int contarTipos()
        {
            DataBase db = new DataBase();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter();

            SqlDataReader dr = db.executaSQLParams("select count(*) from TiposTratamento;", p, false);

            if (dr.HasRows)
            {
                dr.Read();
                return Int32.Parse(dr[0].ToString());
            }
            return -1;
        }
    }
}
