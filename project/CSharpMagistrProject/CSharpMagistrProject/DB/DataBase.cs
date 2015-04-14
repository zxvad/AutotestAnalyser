using System;
using System.Collections.Generic;
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
	    public void DoQuery(string query, Dictionary<string,object> parametrsDictionary )
	    {
	        if (IsConnected)
            {
                //Если в запросе есть insert/update/delete
                if (query.IndexOf("insert", StringComparison.OrdinalIgnoreCase) > (int)Keys.NotExist ||
                    query.IndexOf("update", StringComparison.OrdinalIgnoreCase) > (int)Keys.NotExist ||
                    query.IndexOf("delete", StringComparison.OrdinalIgnoreCase) > (int)Keys.NotExist)
                {
                    OleDbCommand command = new OleDbCommand(query, connection);
                    // добавляем параметры в запрос
                    if (parametrsDictionary != null)
                    {
                        foreach (KeyValuePair<string, object> keyValuePair in parametrsDictionary)
                        {
                            command.Parameters.AddWithValue(keyValuePair.Key,keyValuePair.Value);
                        }
                    }
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

        public void DoQuery(string query)
        {
            DoQuery(query, null);
        }

        //выполнение SQL запроса (SELECT) и занесение результатов в DataTable
        public DataTable DoSelectQuery(string query, Dictionary<string, object> parametrsDictionary)
	    {
	        if (IsConnected)
	        {
                // Если в запросе есть SELECT
                if (query.IndexOf("select", StringComparison.OrdinalIgnoreCase) > (int) Keys.NotExist)
                {
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query,connection);
                    // добавляем параметры в запрос
                    if (parametrsDictionary != null)
                    {
                        foreach (KeyValuePair<string, object> keyValuePair in parametrsDictionary)
                        {
                            dataAdapter.SelectCommand.Parameters.AddWithValue(keyValuePair.Key,keyValuePair.Value);
                        }
                    }
                    
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

        public DataTable DoSelectQuery(string query)
        {
            return DoSelectQuery(query, null);
        }

        // Выполнение скалярного SQL запроса
        public int DoScalarQuery(string query, Dictionary<string, object> parametrsDictionary)
	    {
	        if (IsConnected)
            {
                // Если в запросе есть SELECT
                if (query.IndexOf("select", StringComparison.OrdinalIgnoreCase) > (int) Keys.NotExist)
                {
                    OleDbCommand command = new OleDbCommand(query, connection);
                    // добавляем параметры в запрос
                    if (parametrsDictionary != null)
                    {
                        foreach (KeyValuePair<string, object> keyValuePair in parametrsDictionary)
                        {
                            command.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
                        }
                    }
                    var resultQuery = command.ExecuteScalar();
                    return Convert.ToInt32(resultQuery);
                }
                Controller.ShowMsg("Неверный запрос");
                return (int) Keys.Error;
            }
	        Controller.ShowMsg("Нет соединения с БД");
            return (int)Keys.Error;
	    }

        public int DoScalarQuery(string query)
        {
            return DoScalarQuery(query, null);
        }
	}
}