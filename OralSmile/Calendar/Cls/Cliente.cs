using System;
using System.Data.SqlClient;
using System.Data;

namespace Calendar.Cls
{
    public class Cliente
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


        public bool novoCliente()
        {
            SqlParameter[] p = new SqlParameter[14];

            for (int i = 0; i < p.Length; i++)
            {
                p[i] = new SqlParameter();
                p[i].Direction = System.Data.ParameterDirection.Input;
            }

            p[0].ParameterName = "@nome";
            p[0].Value = this.nome;

            p[1].ParameterName = "@apelidos";
            p[1].Value = this.apelidos;

            p[2].ParameterName = "@morada";
            p[2].Value = this.morada;

            p[3].ParameterName = "@codigo_postal";
            p[3].Value = this.codigo_postal;

            p[4].ParameterName = "@codigo_postal_1";
            p[4].Value = this.codigo_postal_1;

            p[5].ParameterName = "@localidade";
            p[5].Value = this.localidade;

            p[6].ParameterName = "@telefone";
            p[6].Value = this.telefone;

            p[7].ParameterName = "@telemovel";
            p[7].Value = this.telemovel;

            p[8].ParameterName = "@profissao";
            p[8].Value = this.profissao;

            p[9].ParameterName = "@seguro";
            p[9].Value = this.seguro;

            p[10].ParameterName = "@n_utente";
            p[10].Value = this.n_utente;

            p[11].ParameterName = "@n_contribuinte";
            p[11].Value = this.n_contribuinte;

            p[12].ParameterName = "@bi";
            p[12].Value = this.bi;

            p[13].ParameterName = "@n_cliente";
            p[13].Value = this.n_cliente;


            DataBase bd = new DataBase();
            bd.executaSQLTrasact("criarCliente2", p, false, out p);

            if (p[0] != null)
                return false;
            else
                return true;
        }


        public bool editarCliente()
        {
            SqlParameter[] p = new SqlParameter[15];

            for (int i = 0; i < p.Length; i++)
            {
                p[i] = new SqlParameter();
                p[i].Direction = System.Data.ParameterDirection.Input;
            }

            p[0].ParameterName = "@nome";
            p[0].Value = this.nome;

            p[1].ParameterName = "@apelidos";
            p[1].Value = this.apelidos;

            p[2].ParameterName = "@morada";
            p[2].Value = this.morada;

            p[3].ParameterName = "@codigo_postal";
            p[3].Value = this.codigo_postal;

            p[4].ParameterName = "@codigo_postal_1";
            p[4].Value = this.codigo_postal_1;

            p[5].ParameterName = "@localidade";
            p[5].Value = this.localidade;

            p[6].ParameterName = "@telefone";
            p[6].Value = this.telefone;

            p[7].ParameterName = "@telemovel";
            p[7].Value = this.telemovel;

            p[8].ParameterName = "@profissao";
            p[8].Value = this.profissao;

            p[9].ParameterName = "@seguro";
            p[9].Value = this.seguro;

            p[10].ParameterName = "@n_utente";
            p[10].Value = this.n_utente;

            p[11].ParameterName = "@n_contribuinte";
            p[11].Value = this.n_contribuinte;

            p[12].ParameterName = "@bi";
            p[12].Value = this.bi;

            p[13].ParameterName = "@n_cliente";
            p[13].Value = this.n_cliente;

            p[14].ParameterName = "@idCliente";
            p[14].Value = this.idCliente;


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

            SqlDataReader dr = db.executaSQLParams("Select idCliente, nome, apelidos, n_cliente, localidade, morada from Clientes order by 4, 2, 3;", p, false);


            if (dr.HasRows)
            {
                int x = 0;
                while (dr.Read())
                {
                    cliente[x] = new Cliente();
                    cliente[x].IdCliente = Int32.Parse(dr[0].ToString());
                    cliente[x].Nome = dr[1].ToString();
                    cliente[x].Apelidos = dr[2].ToString();
                    cliente[x].NumCliente = Int32.Parse(dr[3].ToString());
                    cliente[x].Localidade = dr[4].ToString();
                    cliente[x].Morada = dr[5].ToString();
                    x++;
                }
            }

            return cliente;
        }


        public Cliente[] pesquisarClientes(string combo, string txt1, string txt2, string txt3)
        {
            Cliente[] cliente = new Cliente[1];
            SqlParameter[] p = new SqlParameter[1];

            string sql = string.Empty;
            if (!txt1.Equals("") && txt2.Equals("") && txt3.Equals(""))
            {
                p = new SqlParameter[1];
                p[0] = new SqlParameter("@n_cliente", Int32.Parse(txt1));
                sql = "select idCliente, nome, apelidos, n_cliente from Clientes where n_cliente=@n_cliente order by 4";
            }
            else if (!txt1.Equals("") && !txt2.Equals("") && txt3.Equals(""))
            {
                p = new SqlParameter[2];
                p[0] = new SqlParameter("@n_cliente", Int32.Parse(txt1));
                p[1] = new SqlParameter("@nome", txt2);
                if (combo.Equals("E"))
                    sql = "select idCliente, nome, apelidos, n_cliente from Clientes where n_cliente=@n_cliente and nome like '%' + @nome + '%' order by 4";
                else
                    sql = "select idCliente, nome, apelidos, n_cliente from Clientes where n_cliente=@n_cliente or nome like '%' + @nome + '%' order by 4";
            }
            else if (!txt1.Equals("") && !txt2.Equals("") && !txt3.Equals(""))
            {
                p = new SqlParameter[3];
                p[0] = new SqlParameter("@n_cliente", Int32.Parse(txt1));
                p[1] = new SqlParameter("@nome", txt2);
                p[2] = new SqlParameter("@apelidos", txt3);
                if (combo.Equals("E"))
                    sql = "select idCliente, nome, apelidos, n_cliente from Clientes where n_cliente=@n_cliente and nome like '%' + @nome + '%' and apelidos like '%' + @apelidos + '%' order by 4";
                else
                    sql = "select idCliente, nome, apelidos, n_cliente from Clientes where n_cliente=@n_cliente or nome like '%' + @nome + '%' or apelidos like '%' + @apelidos + '%' order by 4";
            }
            else if (!txt1.Equals("") && txt2.Equals("") && !txt3.Equals(""))
            {
                p = new SqlParameter[2];
                p[0] = new SqlParameter("@n_cliente", Int32.Parse(txt1));
                p[1] = new SqlParameter("@apelidos", txt3);
                if (combo.Equals("E"))
                    sql = "select idCliente, nome, apelidos, n_cliente from Clientes where n_cliente=@n_cliente and apelidos like '%' + @apelidos + '%' order by 4";
                else
                    sql = "select idCliente, nome, apelidos, n_cliente from Clientes where n_cliente=@n_cliente or apelidos like '%' + @apelidos + '%' order by 4";
            }
            else if (txt1.Equals("") && !txt2.Equals("") && !txt3.Equals(""))
            {
                p = new SqlParameter[2];
                p[0] = new SqlParameter("@nome", txt2);
                p[1] = new SqlParameter("@apelidos", txt3);
                if (combo.Equals("E"))
                    sql = "select idCliente, nome, apelidos, n_cliente from Clientes where nome like '%' + @nome + '%' and apelidos like '%' + @apelidos + '%' order by 4";
                else
                    sql = "select idCliente, nome, apelidos, n_cliente from Clientes where nome like '%' + @nome + '%' or apelidos like '%' + @apelidos + '%' order by 4";
            }
            else if (txt1.Equals("") && !txt2.Equals("") && txt3.Equals(""))
            {
                p = new SqlParameter[1];
                p[0] = new SqlParameter("@nome", txt2);
                sql = "select idCliente, nome, apelidos, n_cliente from Clientes where nome like '%' + @nome + '%' order by 4";
            }
            else if (txt1.Equals("") && txt2.Equals("") && !txt3.Equals(""))
            {
                p = new SqlParameter[1];
                p[0] = new SqlParameter("@apelidos", txt3);
                sql = "select idCliente, nome, apelidos, n_cliente from Clientes where apelidos like '%' + @apelidos + '%' order by 4";
            }

            if (!sql.Equals(string.Empty))
            {
                DataBase db = new DataBase();
                SqlDataReader dr = db.executaSQLParams(sql, p, true);

                int contador = 0;
                if (dr.HasRows)
                {
                    while (dr.Read())
                        contador++;
                }
                dr.Close();

                dr = db.executaSQLParams(sql, p, true);


                if (dr.HasRows)
                {
                    cliente = new Cliente[contador];
                    int i = 0;
                    while (dr.Read())
                    {
                        cliente[i] = new Cliente();
                        cliente[i].IdCliente = Int32.Parse(dr[0].ToString());
                        cliente[i].Nome = dr[1].ToString();
                        cliente[i].Apelidos = dr[2].ToString();
                        cliente[i].NumCliente = Int32.Parse(dr[3].ToString());
                        i++;
                    }
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
