using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using CSharpMagistrProject.MVC;


namespace CSharpMagistrProject.DB
{
    public class DataBase
	{
	    private OleDbConnection connection;

	    private bool IsConnected;
        public bool isConnected
	    {
	        get { return IsConnected; }
	    }


	    public DataBase()
	    {
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
                    Controller.ShowMsg("Неверный запрос");
                }
            }
            else
            {
                Controller.ShowMsg("Нет соединения с БД");
            }
	    }

        //выполнение SQL запроса (SELECT) и занесение результатов в DataGridView
	    public DataTable DoSelectQuery(string selectQueryText)
	    {
            if (IsConnected)
	        {
                // Если в запросе есть SELECT
                if (selectQueryText.IndexOf("select", StringComparison.OrdinalIgnoreCase) > -1)
	            {
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectQueryText, connection);
                    DataTable resultQueryTable = new DataTable();
                    dataAdapter.Fill(resultQueryTable);
	                return resultQueryTable;
	            }
	            else
	            {
                    Controller.ShowMsg("Неверный SELECT запрос");
	                return null;
	            }
                
	        }
            else
            {
                Controller.ShowMsg("Нет соединения с БД");
                return null;
            }
	    }

        // Выполнение скалярного SQL запроса
	    public int DoScalarQuery(string scalarQueryText)
	    {
            if (IsConnected)
            {
                // Если в запросе есть SELECT
                if (scalarQueryText.IndexOf("select", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    OleDbCommand command = new OleDbCommand(scalarQueryText, connection);
                    var resultQuery = command.ExecuteScalar();
                    return Convert.ToInt32(resultQuery);
                }
                else
                {
                    Controller.ShowMsg("Неверный запрос");
                    return -1;
                }
            }
            else
            {
                Controller.ShowMsg("Нет соединения с БД");
                return -1;
            }
	    }
	}
}