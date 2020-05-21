using System;
using System.Data;
using System.Data.SqlClient;
using ApiDapper.Shared;

namespace ApiDapper.Infra.DataContexts
{
    public class ApiDapperDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        // Classe para criar a conexão, herda de IDisposable, para fechar
        // a conexão com o metodo Dispose
        public ApiDapperDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}