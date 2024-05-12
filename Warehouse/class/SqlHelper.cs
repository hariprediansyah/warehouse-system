using MySql.Data.MySqlClient;
using System.Data;

namespace Warehouse.Class
{
    public class SqlHelper : IDisposable
    {
        const string connectionString = "Server=localhost;Database=Tugas;Uid=sa;Pwd=qwertyuiop;";
        private MySqlConnection connection = null;
        MySqlCommand cmd = null;
        MySqlDataAdapter adapter = null;

		public string commandText = "";
        public CommandType commandType = CommandType.Text;
        private bool disposedValue;

        public SqlHelper()
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)                                   
                .AddJsonFile("appsettings.json",optional:true)
                .Build();
                connection = new MySqlConnection(configuration.GetConnectionString("Warehouse"));
                connection.Open();
                cmd = connection.CreateCommand();
            }

        public DataTable ExecuteDataTable()
        {
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public DataRow ExecuteDataRow()
        {
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt.Rows[0];
        }

		public DataSet ExecuteDataSet()
		{
			cmd.CommandText = commandText;
			cmd.CommandType = commandType;
			adapter = new MySqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);
            return ds;
		}

		public string ExecuteScalar()
		{
			cmd.CommandText = commandText;
			cmd.CommandType = commandType;
			adapter = new MySqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapter.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                return "0";
            }
			return dt.Rows[0][0].ToString();
		}

		public void ExecuteNonQuery()
        {
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            cmd.ExecuteNonQuery();
        }

        public void AddParameter(string parameterName, object value, MySqlDbType mySqlDbType)
        {
            var param = new MySqlParameter
            {
                ParameterName = parameterName,
                Value = value,
                MySqlDbType = mySqlDbType
            };
            cmd.Parameters.Add(param);
        }

        public void ClearParameters()
        {
            cmd.Parameters.Clear();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    connection.Close();
                    connection.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MySqlHelper()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
