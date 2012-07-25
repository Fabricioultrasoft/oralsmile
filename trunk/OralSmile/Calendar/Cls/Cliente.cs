using System;
using System.Data.SqlClient;
using System.Data;

namespace Calendar.Cls
{
    class Cliente
    {
        private int idCliente, codigo_postal, codigo_postal_1, telefone, telemovel;
        private long bi, n_contribuinte, n_utente, n_cliente;
        private string nome, apelidos, morada, localidade, profissao, seguro;

        public Cliente()
        {
            this.idCliente = -1;
        }


        public Cliente(int idCliente, int bi, string nome, string apelidos, string morada, string localidade)
        {
            this.idCliente = idCliente;
            this.bi = bi;
            this.nome = nome;
            this.apelidos = apelidos;
            this.morada = morada;
            this.localidade = localidade;
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


        public long BI
        {
            set
            {
                this.bi = value;
            }
            get
            {
                return this.bi;
            }
        }


        public string Nome
        {
            set
            {
                this.nome = value;
            }
            get
            {
                return this.nome;
            }
        }


        public string Apelidos
        {
            set
            {
                this.apelidos = value;
            }
            get
            {
                return this.apelidos;
            }
        }


        public string Localidade
        {
            set
            {
                this.localidade = value;
            }
            get
            {
                return this.localidade;
            }
        }


        public string Morada
        {
            set
            {
                this.morada = value;
            }
            get
            {
                return this.morada;
            }
        }


        public string Profissao
        {
            set
            {
                this.profissao = value;
            }
            get
            {
                return this.profissao;
            }
        }


        public string Seguro
        {
            set
            {
                this.seguro = value;
            }
            get
            {
                return this.seguro;
            }
        }


        public long NumContribuiente
        {
            set
            {
                this.n_contribuinte = value;
            }
            get
            {
                return this.n_contribuinte;
            }
        }


        public long NumCliente
        {
            set
            {
                this.n_cliente = value;
            }
            get
            {
                return this.n_cliente;
            }
        }


        public long NumUtente
        {
            set
            {
                this.n_utente = value;
            }
            get
            {
                return this.n_utente;
            }
        }


        public int Telefone
        {
            set
            {
                this.telefone = value;
            }
            get
            {
                return this.telefone;
            }
        }


        public int Telemovel
        {
            set
            {
                this.telemovel = value;
            }
            get
            {
                return this.telemovel;
            }
        }


        public int CodigoPostal
        {
            set
            {
                this.codigo_postal = value;
            }
            get
            {
                return this.codigo_postal;
            }
        }


        public int CodigoPostal_3Digitos
        {
            set
            {
                this.codigo_postal_1 = value;
            }
            get
            {
                return this.codigo_postal_1;
            }
        }


        public bool novoCliente(string nome, string apelidos, string morada, int codigo_postal, int codigo_postal_1, string localidade, int telefone, int telemovel, string profissao, int seguro, long bi, long n_utente, long n_contribuinte, long n_cliente)
        {
            SqlParameter[] p = new SqlParameter[14];

            for (int i = 0; i < p.Length; i++)
            {
                p[i] = new SqlParameter();
                p[i].Direction = System.Data.ParameterDirection.Input;
            }

            p[0].ParameterName = "@nome";
            p[0].Value = nome;

            p[1].ParameterName = "@apelidos";
            p[1].Value = apelidos;

            p[2].ParameterName = "@morada";
            p[2].Value = morada;

            p[3].ParameterName = "@codigo_postal";
            p[3].Value = codigo_postal;

            p[4].ParameterName = "@codigo_postal_1";
            p[4].Value = codigo_postal_1;

            p[5].ParameterName = "@localidade";
            p[5].Value = localidade;

            p[6].ParameterName = "@telefone";
            p[6].Value = telefone;

            p[7].ParameterName = "@telemovel";
            p[7].Value = telemovel;

            p[8].ParameterName = "@profissao";
            p[8].Value = profissao;

            p[9].ParameterName = "@seguro";
            p[9].Value = seguro;

            p[10].ParameterName = "@n_utente";
            p[10].Value = n_utente;

            p[11].ParameterName = "@n_contribuinte";
            p[11].Value = n_contribuinte;

            p[12].ParameterName = "@bi";
            p[12].Value = bi;

            p[13].ParameterName = "@n_cliente";
            p[13].Value = n_cliente;


            DataBase bd = new DataBase();
            bd.executaSQLTrasact("criarCliente2", p, false, out p);

            if (p[0] != null)
                return false;
            else
                return true;
        }


        public bool editarCliente(int idCliente, string nome, string apelidos, string morada, int codigo_postal, int codigo_postal_1, string localidade, int telefone, int telemovel, string profissao, int seguro, long bi, long n_utente, long n_contribuinte, long n_cliente)
        {
            SqlParameter[] p = new SqlParameter[15];

            for (int i = 0; i < p.Length; i++)
            {
                p[i] = new SqlParameter();
                p[i].Direction = System.Data.ParameterDirection.Input;
            }

            p[0].ParameterName = "@nome";
            p[0].Value = nome;

            p[1].ParameterName = "@apelidos";
            p[1].Value = apelidos;

            p[2].ParameterName = "@morada";
            p[2].Value = morada;

            p[3].ParameterName = "@codigo_postal";
            p[3].Value = codigo_postal;

            p[4].ParameterName = "@codigo_postal_1";
            p[4].Value = codigo_postal_1;

            p[5].ParameterName = "@localidade";
            p[5].Value = localidade;

            p[6].ParameterName = "@telefone";
            p[6].Value = telefone;

            p[7].ParameterName = "@telemovel";
            p[7].Value = telemovel;

            p[8].ParameterName = "@profissao";
            p[8].Value = profissao;

            p[9].ParameterName = "@seguro";
            p[9].Value = seguro;

            p[10].ParameterName = "@n_utente";
            p[10].Value = n_utente;

            p[11].ParameterName = "@n_contribuinte";
            p[11].Value = n_contribuinte;

            p[12].ParameterName = "@bi";
            p[12].Value = bi;

            p[13].ParameterName = "@n_cliente";
            p[13].Value = n_cliente;

            p[14].ParameterName = "@idCliente";
            p[14].Value = idCliente;


            DataBase bd = new DataBase();
            bd.executaSQLTrasact("editarCliente", p, false, out p);

            if (p[0] != null)
                return false;
            else
                return true;
        }


        public Cliente pesquisaCliente(int idCliente)
        {
            DataBase db = new DataBase();
            SqlParameter[] p = new SqlParameter[15];

            p[0] = new SqlParameter("@idCliente", idCliente);

            for (int i = 1; i < p.Length; i++)
            {
                p[i] = new SqlParameter();
                p[i].Direction = System.Data.ParameterDirection.Output;
            }

            p[1].ParameterName = "@nome";
            p[2].ParameterName = "@morada";
            p[3].ParameterName = "@telefone";
            p[4].ParameterName = "@telemovel";
            p[5].ParameterName = "@cod_postal";
            p[6].ParameterName = "@cod_postal_1";
            p[7].ParameterName = "@localidade";
            p[8].ParameterName = "@n_utente";
            p[9].ParameterName = "@n_cliente";
            p[10].ParameterName = "@n_contribuinte";
            p[11].ParameterName = "@profissao";
            p[12].ParameterName = "@seguro";
            p[13].ParameterName = "@bi";
            p[14].ParameterName = "@apelidos";


            db.executaSQLTrasact("selectCliente", p, true, out p);

            Cliente cli = new Cliente();
            cli.Nome = p[0].Value.ToString();
            cli.Apelidos = p[13].Value.ToString();
            cli.Morada = p[1].Value.ToString();
            cli.Telefone = Int32.Parse(p[2].Value.ToString());
            cli.Telemovel = Int32.Parse(p[3].Value.ToString());
            cli.CodigoPostal = Int32.Parse(p[4].Value.ToString());
            cli.CodigoPostal_3Digitos = Int32.Parse(p[5].Value.ToString());
            cli.Localidade = p[6].Value.ToString();
            cli.NumUtente = long.Parse(p[7].Value.ToString());
            cli.NumCliente = long.Parse(p[8].Value.ToString());
            cli.NumContribuiente = long.Parse(p[9].Value.ToString());
            cli.Profissao = p[10].Value.ToString();
            cli.Seguro = p[11].Value.ToString();
            cli.BI = long.Parse(p[12].Value.ToString());

            return cli;
        }


        public Cliente[] todosClientes()
        {
            Cliente[] cliente = new Cliente[contarClientes()];
            DataBase db = new DataBase();

            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter();

            SqlDataReader dr = db.executaSQLParams("Select idCliente, nome, apelidos from Clientes;", p, false);


            if (dr.HasRows)
            {
                int x = 0;
                while (dr.Read())
                {
                    cliente[x] = new Cliente();
                    cliente[x].IdCliente = Int32.Parse(dr[0].ToString());
                    cliente[x].Nome = dr[1].ToString();
                    cliente[x].Apelidos = dr[2].ToString();
                    x++;
                }
            }

            return cliente;
        }


        private int contarClientes()
        {
            DataBase db = new DataBase();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter();

            SqlDataReader dr = db.executaSQLParams("select count(*) from Clientes;", p, false);

            if (dr.HasRows)
            {
                dr.Read();
                return Int32.Parse(dr[0].ToString());
            }
            return -1;
        }
    }
}
