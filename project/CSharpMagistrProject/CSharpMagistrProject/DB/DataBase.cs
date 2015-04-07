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
		//зачем передавать OleDbCommand command? Это нарушение инкапсуляции!
	    public void DoQuery(OleDbCommand command)
	    {
	        if (command == null) throw new ArgumentNullException("command");
	        if (IsConnected)
            {
                //Если в запросе есть insert/update/delete
				//1) почему используешь магические числа???????????
				//2) если команда будет написана не строчными. Тогда алгоритм как сработает?
                if (command.CommandText.IndexOf("insert", StringComparison.OrdinalIgnoreCase) > -1 ||
                    command.CommandText.IndexOf("update", StringComparison.OrdinalIgnoreCase) > -1 ||
                    command.CommandText.IndexOf("delete", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    // выполнение запроса 
                    command.Connection = connection;
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

        //выполнение SQL запроса (SELECT) и занесение результатов в DataTable
		//зачем передавать OleDbCommand command? Это нарушение инкапсуляции!
	    public DataTable DoSelectQuery(OleDbCommand command)
	    {
	        if (command == null) throw new ArgumentNullException("command");
	        if (IsConnected)
	        {
                // Если в запросе есть SELECT
                if (command.CommandText.IndexOf("select", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    command.Connection = connection;
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
                    DataTable resultQueryTable = new DataTable();
                    dataAdapter.Fill(resultQueryTable);
	                return resultQueryTable;
	            }
	            Controller.ShowMsg("Неверный SELECT запрос");
	            return null;
	        }
	        Controller.ShowMsg("Нет соединения с БД");
	        return null;
	    }

        // Выполнение скалярного SQL запроса
		//зачем передавать OleDbCommand command? Это нарушение инкапсуляции!
	    public int DoScalarQuery(OleDbCommand command)
	    {
	        if (command == null) throw new ArgumentNullException("command");
	        if (IsConnected)
            {
                // Если в запросе есть SELECT
                if (command.CommandText.IndexOf("select", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    command.Connection = connection;
                    var resultQuery = command.ExecuteScalar();
                    return Convert.ToInt32(resultQuery);
                }
                Controller.ShowMsg("Неверный запрос");
                return -1;
            }
	        Controller.ShowMsg("Нет соединения с БД");
	        return -1;
	    }
	}
}