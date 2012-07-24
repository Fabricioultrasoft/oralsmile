using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Calendar.Cls
{
    class DataBase:Conector
    {
        /// <summary>
        /// Constructor padrão
        /// </summary>
        public DataBase():base()
        {
        }


        /// <summary>
        /// Método que executa uma sequencia SQL usando parâmetros
        /// </summary>
        /// <param name="sqlQuery">sequencia a executar</param>
        /// <param name="parametros">array de parametros SQLParameter</param>
        /// <returns>SqlDataReader</returns>
        /// <remarks>Não esquecer fechar a ligação do outro lado.</remarks>
        public SqlDataReader executaSQLParams(string sqlQuery, SqlParameter[] parametros, bool existeParamentros)
        {
            try
            {
                //verificar conecção
                if (base.Connection.State == ConnectionState.Closed)
                    base.openConnection();

                SqlCommand cmd = new SqlCommand(sqlQuery, base.Connection);

                if (existeParamentros)
                {
                    foreach (SqlParameter p in parametros)
                    {
                        cmd.Parameters.Add(new SqlParameter(p.ParameterName, p.Value));
                    }
                }

                SqlDataReader dt = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Método que executa uma uma trasancção SQL com parametros
        /// </summary>
        /// <param name="sqlProcedure">Nome do StoredProcedure</param>
        /// <param name="parametros">Paramtos SQL</param>
        /// <param name="input_output">varial que determina se o SP tem parametros de saida</param>
        /// <param name="psaida">Parametro de saida caso seja um SP de outuput</param>
        /// <returns>true/false</returns>
        public void executaSQLTrasact(string sqlProcedure, SqlParameter[] parametros, bool input_output, out SqlParameter[] psaida)
        {
            SqlTransaction tn = null;
            psaida = new SqlParameter[1];
            int count = 0;
            
            if (base.Connection.State == ConnectionState.Closed)
                base.openConnection();

            tn = base.beginTransaction();
            
            SqlCommand cmd = new SqlCommand(sqlProcedure, base.Connection, tn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                foreach (SqlParameter p in parametros)
                {
                    SqlParameter aux = new SqlParameter(p.ParameterName, p.Value);
                    aux.Direction = p.Direction;
                    aux.Size = 150;
                    cmd.Parameters.Add(aux);

                    if (p.Direction == ParameterDirection.Output)
                        count++;
                }
                cmd.ExecuteNonQuery();

                tn.Commit();
            }
            catch (Exception ex)
            {
                tn.Rollback();
                psaida[0] = new SqlParameter("Rollback", ex.Message);
            }
            finally
            {
                base.closeConnection();
            }

            try
            {
                if (input_output)
                {
                    psaida = new SqlParameter[count];
                    int i = 0, j=0;
                    foreach (SqlParameter p1 in parametros)
                    {
                        if (p1.Direction == ParameterDirection.Output)
                        {
                            psaida[i] = new SqlParameter(cmd.Parameters[j].ParameterName, cmd.Parameters[j].Value);
                            psaida[i].Direction = cmd.Parameters[j].Direction;
                            psaida[i].DbType = cmd.Parameters[j].DbType;
                            i++;
                        }
                        j++;
                    }
                }
            }
            catch (Exception ex)
            {
                psaida[0] = new SqlParameter("error", ex.Message);
            }
        }


        /// <summary>
        /// Método que executa uma Scalar-Function
        /// </summary>
        /// <param name="sqlScalar">nome da função</param>
        /// <returns>string com resultado</returns>
        public object executaScalar(string sqlScalar)
        {
            try
            {
                if (base.Connection.State == ConnectionState.Closed)
                    base.openConnection();

                SqlCommand cmd = new SqlCommand(sqlScalar, base.Connection);
                
                object result = null;
                result = cmd.ExecuteScalar();

                return result;
            }
            catch (Exception e)
            {
                string teste = e.Message;
                return null;
            }
            finally
            {
                base.closeConnection();
            }
        }


        /// <summary>
        /// Método que executa uma Scalar-Function com parametros
        /// </summary>
        /// <param name="sqlScalar">nome da função</param>
        /// <param name="parametros">Parametros SQL</param>
        /// <returns>int</returns>
        public object executaScalar(string sqlScalar, SqlParameter[] parametros)
        {
            try
            {
                if (base.Connection.State == ConnectionState.Closed)
                    base.openConnection();

                SqlCommand cmd = new SqlCommand(sqlScalar, base.Connection);

                foreach (SqlParameter p in parametros)
                {
                    cmd.Parameters.Add(new SqlParameter(p.ParameterName, p.Value));
                }

                object result = null;
                result = cmd.ExecuteScalar();

                return result;
            }
            catch (Exception e)
            {
                string teste = e.Message;
                return null;
            }
            finally
            {
                base.closeConnection();
            }
        }
    }
}
