using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Calendar.Cls
{

    class Conector
    {
        private SqlConnection connection;
        //private string coneccao = "server=RECEPCAO\\SQLEXPRESS;Persist Security Info=False;Integrated Security=false;Initial Catalog=OralSmile;User ID=user1; Password=dino";
        
        /* Para ligar no cliente:
         * IP: 192.168.1.66
         */

        private string coneccao ="Data Source=192.168.2.100\\SQLEXPRESS;Initial Catalog=OralSmile;user ID=user1;password=dino";

		public Conector()
		{
			this.connection = new SqlConnection();
            this.connection.ConnectionString = coneccao;
		}


		/// <summary>
		/// Construtor com paramentro de entrada
		/// </summary>
		/// <param name="conn">conecção à BD</param>
        public Conector(string conn)
		{
			this.connection = new SqlConnection(conn);
            this.connection.ConnectionString = coneccao;
		}


		/// <summary>
		/// Propriedade de leitura da conecção
		/// </summary>
		public SqlConnection Connection
		{
			get
			{
				return this.connection;
			}
		}


		/// <summary>
		/// Propriedade da string de conecção
		/// </summary>
		public string ConnectionString
		{
			get
			{
				return this.connection.ConnectionString;
			}
			set
			{
				this.connection.ConnectionString = value;
			}
		}


		/// <summary>
		/// Abre a conecção à base de dados
		/// </summary>
		public void openConnection()
		{
			this.connection.Open();
		}


		/// <summary>
		/// Fecha a conecção à base de dados
		/// </summary>
		public void closeConnection()
		{
			this.connection.Close();
		}


		/// <summary>
		/// Liberta o conector da memória
		/// </summary>
		public void disposeConnection()
		{
			this.connection.Dispose();
		}


        /// <summary>
        /// Inicia uma SQl Transaction
        /// </summary>
        public SqlTransaction beginTransaction()
        {
            return this.connection.BeginTransaction();
        }
	}
}

