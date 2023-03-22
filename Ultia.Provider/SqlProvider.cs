using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Configuration;

namespace AdoSample.Provider
{
    public class SqlProvider : IDisposable
    {
        public readonly SqlConnection conn;
        public readonly SqlCommand cmd;
        public SqlCommand[] sqlCommands = new SqlCommand[2];

        /// <summary>
        /// Bir komut alan constructor.
        /// </summary>
        /// <param name="YapilamakIstenenQuery"></param>
        /// <param name="ConnectionText"></param>
        public SqlProvider(string YapilamakIstenenQuery, string ConnectionText = "server=.;Database=Ultia;uid=sa;pwd=123")// todo appconfigden çekilecek 
        {
            conn = new SqlConnection(ConnectionText);
            cmd = new SqlCommand(YapilamakIstenenQuery, conn);
        }

        /// <summary>
        /// Transaction için iki komut gönderilen constructor.
        /// </summary>
        /// <param name="YapilamakIstenenBirinciQuery"></param>
        /// <param name="YapilamakIstenenIkinciQuery"></param>
        /// <param name="ConnectionText"></param>
        public SqlProvider(string YapilamakIstenenBirinciQuery, string YapilamakIstenenIkinciQuery, string ConnectionText = "server=.;Database=Ultia;uid=sa;pwd=123")
        {
            conn = new SqlConnection(ConnectionText);
            sqlCommands[0] = new SqlCommand(YapilamakIstenenBirinciQuery, conn);
            sqlCommands[1] = new SqlCommand(YapilamakIstenenIkinciQuery, conn);
        }

        /// <summary>
        /// Sql bağlantısını açma fonksiyonu.
        /// </summary>
        void Ac()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        /// <summary>
        /// Sql bağlantısını kapatma fonksiyonu.
        /// </summary>
        void Kapat()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();

            }
        }
        /// <summary>
        /// ExecuteNonQuery oluşturma fonksiyonu.
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQueryOlustur()
        {
            int result = 0;

            try
            {
                Ac();
                result = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                result = 0;
            }
            finally
            {
                Kapat();
            }

            return result;
        }

        /// <summary>
        /// Executedatareader oluşturma fonksiyonu.
        /// </summary>
        /// <returns></returns>
        public SqlDataReader ExecuteReaderOlustur()
        {
            SqlDataReader rdr = null;
            try
            {
                Ac();
                rdr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

            }

            return rdr;
        }
        /// <summary>
        /// Executescalar oluşturma fonksiyonu.
        /// </summary>
        /// <returns></returns>
        public object ExecuteScalarOlustur()
        {
            object result = null;
            try
            {
                Ac();
                result = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Kapat();
            }
            return result;
        }
        /// <summary>
        /// Parametre ekleme fonksiyonu.
        /// </summary>
        /// <param name="sqlParameters"></param>
        public void ParametreEkle(SqlParameter[] sqlParameters)
        {
            if (cmd != null)
            {
                cmd.Parameters.AddRange(sqlParameters);
            }
            else
            {
                foreach (SqlCommand sqlCommand in sqlCommands)
                {
                    sqlCommand.Parameters.AddRange(sqlParameters);
                }
            }
        }
        /// <summary>
        /// Gelen komut listesine göre transaction yapan fonksiyon.
        /// </summary>
        public void TransactionFoksiyonu()
        {

            Ac();

            SqlTransaction transaction = conn.BeginTransaction(); ;
            foreach (SqlCommand command in sqlCommands)
            {

                command.Transaction = transaction;
            }
            try
            {

                foreach (SqlCommand command in sqlCommands)
                {
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                Console.WriteLine("Transaction geri alındı." + ex.Message);
            }
            finally
            {
                Kapat();
            }
        }
        public void Dispose()
        {
            conn.Dispose();
            cmd.Dispose();
        }
    }


}
