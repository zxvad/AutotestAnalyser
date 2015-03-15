using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;


namespace CSharpMagistrProject.DB
{
	class DataBase
	{
	    private string userName;
        private string password;
        private string server;
        private string DBName;

	    private OleDbConnection connection;

	    private bool IsConnected;
        public bool isConnected
	    {
	        get { return IsConnected; }
	    }


	    public DataBase(string server, string DBName, string userName, string password)
	    {
            this.server = server;
            this.DBName = DBName;
            this.userName = userName;
            this.password = password;

            IsConnected = false;
	    }
        
        //Соединение с БД
	    public void Connect()
	    {
	        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;";
	        connectionString += "Data Source=|DataDirectory|\\MagistrDB.accdb";

	        if (IsConnected == false)
	        {
                // открываем соединение
                connection = new OleDbConnection(connectionString);
                connection.Open();
                IsConnected = true;
	        }
            
        }

        //Закрытие соединения с БД
	    public void Close()
	    {
            //закрытие соединения
            if (IsConnected)
            {
                connection.Close();
                IsConnected = false;
            }
	    }

        //выполнение SQL запроса (INSERT, UPDATE, DELETE)
	    public void DoQuery(string queryText)
	    { 
            if (IsConnected)
            {
                //Если в запросе есть insert/update/delete
                if (queryText.IndexOf("insert", StringComparison.OrdinalIgnoreCase) > -1 ||
                    queryText.IndexOf("update", StringComparison.OrdinalIgnoreCase) > -1 ||
                    queryText.IndexOf("delete", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    // выполнение запроса 
                    OleDbCommand command = new OleDbCommand(queryText, connection);
                    command.ExecuteNonQuery();
                }
                else
                {
                    CommonMethods.ShowMsg("Неверный запрос");
                }
            }
            else
            {
                CommonMethods.ShowMsg("Нет соединения с БД");
            }
	    }

        //выполнение SQL запроса (SELECT) и занесение результатов в DataGridView
	    public void DoQuery(string selectQueryText, DataGridView receiverGridView)
	    {
            if (IsConnected)
	        {
                // Если в запросе есть SELECT
                if (selectQueryText.IndexOf("select", StringComparison.OrdinalIgnoreCase) > -1)
	            {
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectQueryText, connection);
                    DataTable resultQueryTable = new DataTable();
                    dataAdapter.Fill(resultQueryTable);
                    receiverGridView.DataSource = resultQueryTable;
                }
	            else
	            {
                    CommonMethods.ShowMsg("Неверный SELECT запрос");
	            }
                
	        }
            else
            {
                CommonMethods.ShowMsg("Нет соединения с БД");
            }
	    }

        // Выполнение скалярного SQL запроса
	    public int DoScalarQuery(string scalarQuery)
	    {
            if (IsConnected)
            {
                // Если в запросе есть SELECT
                if (scalarQuery.IndexOf("select", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    OleDbCommand command = new OleDbCommand(scalarQuery, connection);
                    var resultQuery = command.ExecuteScalar();
                    return Convert.ToInt32(resultQuery);
                }
                else
                {
                    CommonMethods.ShowMsg("Неверный запрос");
                    return -1;
                }
            }
            else
            {
                CommonMethods.ShowMsg("Нет соединения с БД");
                return -1;
            }
	    }
	}
}