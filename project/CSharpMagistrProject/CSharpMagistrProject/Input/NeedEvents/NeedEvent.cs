using System.Collections.Generic;
using CSharpMagistrProject.Check.CheckSystem;
using CSharpMagistrProject.DB;
using CSharpMagistrProject.Input.Events;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Input.NeedEvents
{
    //Необходимые события
    class NeedEvent
    {
        private readonly Event _listEvent;
        private readonly CheckNeedEvent _check;
        private readonly string _sourceNeedEventTable;

        public NeedEvent(DataBase sourceDataBase, string sourceEventTable, string sourceNeedEventTable)
        {
            _listEvent=new Event(sourceDataBase,sourceEventTable);
            _sourceNeedEventTable = sourceNeedEventTable;
            _check=new CheckNeedEvent(sourceDataBase,sourceNeedEventTable);
        }
        
        //Добавление необходимого события
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

		//Удаление необходимого события по id
        public void Del(int id)
        {
            string queryText = "DELETE FROM " + _sourceNeedEventTable +
                               " WHERE id = ?";
            Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
            parametrsDictionary.Add("id", id);

            _listEvent.DataBase.DoQuery(queryText,parametrsDictionary);
        }

        //Изменение записи о событии
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

        //Удаление всех необходимых событий из БД
        public void Clear()
        {
            _listEvent.DataBase.Clear(_sourceNeedEventTable);
        }
    }
}
