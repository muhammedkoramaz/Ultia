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

        public SqlProvider(string YapilamakIstenenQuery, string ConnectionText = "server=.;Database=Ultia;uid=sa;pwd=123")// todo appconfigden çekilecek 
        {
            conn = new SqlConnection(ConnectionText);
            cmd = new SqlCommand(YapilamakIstenenQuery, conn);
        }
        public SqlCommand CommandGetir()
        {
            return cmd;
        }

        void Ac()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();

            }

        }
        void Kapat()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();

            }
        }
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

        public void ParametreEkle(SqlParameter[] sqlParameters)
        {
            //foreach (SqlParameter item in sqlParameters)
            //{
            //    cmd.Parameters.Add(item);
            //}
            cmd.Parameters.AddRange(sqlParameters);
        }

        //öyle bir metod yazılmalı ki transaction yapacak.
        public void TransactionFoksiyonu(SqlCommand[] cmdArray)
        {
            SqlTransaction transaction = null;

            try
            {
                Ac();
                transaction = conn.BeginTransaction();
                foreach (SqlCommand command in cmdArray)
                {
                    Console.WriteLine("transacion girdi");
                    Console.WriteLine(command);
                    command.Connection = conn;
                    command.Transaction = transaction;
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
