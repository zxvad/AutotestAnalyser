using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.DB
{
    /// <summary>
    /// Класс для работы с базой данных
    /// </summary>
    public class DataBase
    {
        /// <summary>
        /// Подключение к БД
        /// </summary>
        private OleDbConnection _connection;

        /// <summary>
        /// Есть ли соединение с БД
        /// </summary>
        private bool IsConnected { get; set; }

        /// <summary>
        /// Имя таблицы со списком событий
        /// </summary>
        public string EventTable { get; private set; }

        /// <summary>
        /// Имя таблицы с необходимыми событиями
        /// </summary>
        public string NeedEventTable { get; private set; }

        /// <summary>
        /// Имя таблицы с совершенными событиями
        /// </summary>
        public string DoneEventTable { get; private set; }

        /// <summary>
        /// Имя таблицы с результатами
        /// </summary>
        public string ResultTable { get; private set; }

        /// <summary>
        /// Главный конструктор
        /// </summary>
        public DataBase()
        {
            EventTable = ConfigurationManager.AppSettings["EventTable"];
            NeedEventTable = ConfigurationManager.AppSettings["NeedEventTable"];
            DoneEventTable = ConfigurationManager.AppSettings["DoneEventTable"];
            ResultTable = ConfigurationManager.AppSettings["ResultTable"];
            IsConnected = false;
        }

        
        /// <summary>
        /// Соединение с БД
        /// </summary>
        public void Connect()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MS_ACCESS"].ConnectionString;
            if (IsConnected == false)
            {
                // открываем соединение
                _connection = new OleDbConnection(connectionString);
                _connection.Open();
                IsConnected = true;
            }

        }

        /// <summary>
        /// Закрытие соединения с БД
        /// </summary>
        public void Close()
        {
            //закрытие соединения
            if (IsConnected)
            {
                _connection.Close();
                IsConnected = false;
            }
        }
        
        /// <summary>
        /// Выполнение SQL запроса (INSERT, UPDATE, DELETE)
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <param name="parametrsDictionary">Список параметров запроса</param>
        /// <returns>Количество измененных строк</returns>
        public int DoQuery(string query, Dictionary<string, object> parametrsDictionary = null)
        {
            if (IsConnected)
            {
                //Если в запросе есть insert/update/delete
                if (query.IndexOf("insert", StringComparison.OrdinalIgnoreCase) > (int) KeysEnum.NotExist ||
                    query.IndexOf("update", StringComparison.OrdinalIgnoreCase) > (int) KeysEnum.NotExist ||
                    query.IndexOf("delete", StringComparison.OrdinalIgnoreCase) > (int) KeysEnum.NotExist)
                {
                    OleDbCommand command = new OleDbCommand(query, _connection);
                    // добавляем параметры в запрос
                    if (parametrsDictionary != null)
                    {
                        foreach (KeyValuePair<string, object> keyValuePair in parametrsDictionary)
                        {
                            command.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
                        }
                    }
                    return command.ExecuteNonQuery();
                }
                Controller.ShowMsg("Неверный запрос");
            }
            else
            {
                Controller.ShowMsg("Нет соединения с БД");
            }
            return 0;
        }
        
        /// <summary>
        /// Выполнение SQL запроса (SELECT)
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <param name="parametrsDictionary">Список параметров запроса</param>
        /// <returns>Таблица с результатами запроса</returns>
        public DataTable GetTableByQuery(string query, Dictionary<string, object> parametrsDictionary = null)
        {
            if (IsConnected)
            {
                // Если в запросе есть SELECT
                if (query.IndexOf("select", StringComparison.OrdinalIgnoreCase) > (int) KeysEnum.NotExist)
                {
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, _connection);
                    // добавляем параметры в запрос
                    if (parametrsDictionary != null)
                    {
                        foreach (KeyValuePair<string, object> keyValuePair in parametrsDictionary)
                        {
                            dataAdapter.SelectCommand.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
                        }
                    }

                    DataTable resultQueryTable = new DataTable();
                    dataAdapter.Fill(resultQueryTable);
                    return resultQueryTable;
                }
                Controller.ShowMsg("Неверный SELECT запрос");
            }
            else
            {
                Controller.ShowMsg("Нет соединения с БД");
            }
            return null;
        }
        
        /// <summary>
        /// Выполнение скалярного SQL запроса
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <param name="parametrsDictionary">Список параметров запроса</param>
        /// <returns>Результат выполнения скалярного SQL запроса</returns>
        public int DoScalarQuery(string query, Dictionary<string, object> parametrsDictionary = null)
        {
            if (IsConnected)
            {
                // Если в запросе есть SELECT
                if (query.IndexOf("select", StringComparison.OrdinalIgnoreCase) > (int) KeysEnum.NotExist)
                {
                    OleDbCommand command = new OleDbCommand(query, _connection);
                    // добавляем параметры в запрос
                    if (parametrsDictionary != null)
                    {
                        foreach (KeyValuePair<string, object> keyValuePair in parametrsDictionary)
                        {
                            command.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
                        }
                    }
                    object resultQuery = command.ExecuteScalar();
                    int result;
                    if (resultQuery!=null && Int32.TryParse(resultQuery.ToString(), out result))
                    {
                        return result;
                    }
                }
                Controller.ShowMsg("Неверный запрос");
            }
            else
            {
                Controller.ShowMsg("Нет соединения с БД");
            }
            return (int) KeysEnum.Error;
        }

        /// <summary>
        /// Очистка всех записей указанной таблицы
        /// </summary>
        /// <param name="tableToClear">Имя таблицы для очистки</param>
        public void Clear(string tableToClear)
        {
            string queryText = "DELETE FROM " + tableToClear;
            DoQuery(queryText);
        }
    }
}