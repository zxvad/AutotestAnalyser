using System.Collections.Generic;
using CSharpMagistrProject.Check.CheckSystem;
using CSharpMagistrProject.DB;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Input.Events
{
    /// <summary>
    /// Список событий
    /// </summary>
    class Event
    {
        /// <summary>
        /// Проверка событий на корректность
        /// </summary>
        private readonly CheckEvent _check;

        /// <summary>
        /// Имя таблицы со списком событий
        /// </summary>
        private string SourceEventTable { get; set; }

        /// <summary>
        /// База данных
        /// </summary>
        public DataBase DataBase { get; set; }

        /// <summary>
        /// Конструктор по БД и имени таблицы
        /// </summary>
        /// <param name="sourceDataBase">База данных</param>
        /// <param name="sourceEventTable">Имя таблицы со списком событий</param>
        public Event(DataBase sourceDataBase, string sourceEventTable)
        {
            DataBase = sourceDataBase;
            DataBase.Connect();
            SourceEventTable = sourceEventTable;
            _check = new CheckEvent(DataBase, sourceEventTable);
        }
        
        /// <summary>
        /// Получение нового id для вставки записи в БД
        /// </summary>
        /// <param name="sourceTable">Имя таблицы</param>
        /// <returns>Новый id из таблицы</returns>
        public int NewId(string sourceTable)
        {
            string queryText = "SELECT MAX(id) FROM " + sourceTable;

            int result = DataBase.DoScalarQuery(queryText);
            if (result != (int) KeysEnum.Error)
            {
                return ++result;
            }

            return (int)KeysEnum.Error;
        }

        
        /// <summary>
        /// Добавление события в списко событий
        /// </summary>
        /// <param name="nameEvent">Наименование новго события</param>
        public void Add(string nameEvent)
        {
            if (_check.CheckForUnique(nameEvent))
            {
                string queryText = "INSERT INTO " + SourceEventTable + " (id, name) " +
                                   "VALUES (?, ?)";
                Dictionary<string,object> parametrsDictionary=new Dictionary<string, object>();
                parametrsDictionary.Add("newId", NewId(SourceEventTable));
                parametrsDictionary.Add("nameEvent", nameEvent);

                DataBase.DoQuery(queryText, parametrsDictionary);
            }
            else
            {
                Controller.ShowMsg("Такое событие уже существует");
            }

        }

        
        /// <summary>
        /// Удаление необходимого события по id
        /// </summary>
        /// <param name="id">id события, которое необходимо удалить</param>
        public void Del(int id)
        {
            string queryText= "DELETE FROM " + SourceEventTable +
                              " WHERE id = ?";

            Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
            parametrsDictionary.Add("id", id);
            
            DataBase.DoQuery(queryText,parametrsDictionary);
        }

		/// <summary>
        /// Изменение записи о событии
        /// </summary>
        /// <param name="id">id события, которое необходимо изменить</param>
        /// <param name="newName">Новое наименование события</param>
        public void Update(int id, string newName)
        {
            string queryText = "UPDATE " + SourceEventTable +
                               " SET name = ?" +
                               " WHERE id = ?";
            Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
            parametrsDictionary.Add("newName", newName);
            parametrsDictionary.Add("id", id);

            DataBase.DoQuery(queryText, parametrsDictionary);
        }
        
        /// <summary>
        /// Удаление всех событий из БД
        /// </summary>
        public void Clear()
        {
            DataBase.Clear(SourceEventTable);
        }
    }
}
