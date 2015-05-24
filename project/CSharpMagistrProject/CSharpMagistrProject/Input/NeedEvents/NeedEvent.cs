using System.Collections.Generic;
using CSharpMagistrProject.Check.CheckSystem;
using CSharpMagistrProject.DB;
using CSharpMagistrProject.Input.Events;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Input.NeedEvents
{
    /// <summary>
    /// Необходимые события
    /// </summary>
    public class NeedEvent
    {
        /// <summary>
        /// Список событий
        /// </summary>
        private readonly Event _listEvent;

        /// <summary>
        /// Проверка необходимых событий
        /// </summary>
        private readonly CheckNeedEvent _check;

        /// <summary>
        /// Имя таблицы необходимых событий
        /// </summary>
        private readonly string _sourceNeedEventTable;

        /// <summary>
        /// Конструктор по БД и именам таблиц
        /// </summary>
        /// <param name="sourceDataBase">База данных</param>
        /// <param name="sourceEventTable">Имя таблицы событий</param>
        /// <param name="sourceNeedEventTable">Имя таблицы необходимых событий</param>
        public NeedEvent(DataBase sourceDataBase, string sourceEventTable, string sourceNeedEventTable)
        {
            _listEvent=new Event(sourceDataBase,sourceEventTable);
            _sourceNeedEventTable = sourceNeedEventTable;
            _check=new CheckNeedEvent(sourceDataBase,sourceNeedEventTable);
        }
        
        /// <summary>
        /// Добавление необходимого события
        /// </summary>
        /// <param name="idEvent">id события из списка событий для добавления</param>
        public void Add(int idEvent)
        {
            if (_check.CheckForUnique(idEvent))
            {
                string queryText = "INSERT INTO " + _sourceNeedEventTable + "(id, idEvent) " +
                                   "VALUES (?,?)";

                Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
                parametrsDictionary.Add("id", _listEvent.NewId(_sourceNeedEventTable));
                parametrsDictionary.Add("idEvent", idEvent);

                _listEvent.DataBase.DoQuery(queryText, parametrsDictionary);
            }
            else
            {
                Controller.ShowMsg("Такое необходимое событие уже существует");
            }
        }

		/// <summary>
        /// Удаление необходимого события по id
        /// </summary>
        /// <param name="id">id необхордимого события для удаления</param>
        public void Del(int id)
        {
            string queryText = "DELETE FROM " + _sourceNeedEventTable +
                               " WHERE id = ?";
            Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
            parametrsDictionary.Add("id", id);

            _listEvent.DataBase.DoQuery(queryText,parametrsDictionary);
        }

        /// <summary>
        /// Изменение записи о событии
        /// </summary>
        /// <param name="id">id события, которое необходимо изменить</param>
        /// <param name="newIdEvent">новое id события из списка событий </param>
        public void Update(int id, int newIdEvent)
        {
            string queryText = "UPDATE " + _sourceNeedEventTable +
                               " SET idEvent = ?" +
                               " WHERE id = ?";
            Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
            parametrsDictionary.Add("idEvent", newIdEvent);
            parametrsDictionary.Add("id", id);

            _listEvent.DataBase.DoQuery(queryText,parametrsDictionary);
        }

        /// <summary>
        /// Удаление всех необходимых событий из БД
        /// </summary>
        public void Clear()
        {
            _listEvent.DataBase.Clear(_sourceNeedEventTable);
        }
    }
}
