using System;
using System.Data;
using System.Data.OleDb;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.DB
{
    public class DataBase
	{
	    private OleDbConnection connection;

        public bool IsConnected { get; private set; }


        public DataBase()
	    {
            IsConnected = false;
	    }
        
        //Соединение с БД
	    public void Connect()
	    {
	        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
	                                  "Data Source=|DataDirectory|\\MagistrDB.accdb";

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
        //
        //Вопрос:
        //Я специально переделывал, чтобы создавать параметризированные запросы (для исключения SQL-инъекций) и передавать их как команду
        //Переделывать обратно под динамическое создание текста запроса ???
		//как вариант DataTable getTable(string Asql, Dictionary<string,object> Aparams);
		//void executeQuery(string Asql, Dictionary<string,object> Aparams); и никаких OleDbCommand в интерфейсе
	    public void DoQuery(OleDbCommand command)
	    {
	        if (command == null) throw new ArgumentNullException("command");
	        if (IsConnected)
            {
                //Если в запросе есть insert/update/delete
				//1) почему используешь магические числа???????????
				//2) если команда будет написана не строчными. Тогда алгоритм как сработает?
                //--------------------------------------
                //2) все правильно StringComparison.OrdinalIgnoreCase как раз нужен для игнорирования регистра
                
                if (command.CommandText.IndexOf("insert", StringComparison.OrdinalIgnoreCase) > (int) Keys.NotExist ||
                    command.CommandText.IndexOf("update", StringComparison.OrdinalIgnoreCase) > (int) Keys.NotExist ||
                    command.CommandText.IndexOf("delete", StringComparison.OrdinalIgnoreCase) > (int) Keys.NotExist)
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
                if (command.CommandText.IndexOf("select", StringComparison.OrdinalIgnoreCase) > (int) Keys.NotExist)
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
                if (command.CommandText.IndexOf("select", StringComparison.OrdinalIgnoreCase) > (int) Keys.NotExist)
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