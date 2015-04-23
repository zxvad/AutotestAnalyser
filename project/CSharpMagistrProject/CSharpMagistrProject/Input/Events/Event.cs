using System.Collections.Generic;
using CSharpMagistrProject.Check.CheckSystem;
using CSharpMagistrProject.DB;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Input.Events
{
    //Список событий
    class Event
    {
        private readonly CheckEvent _check;
        private string SourceEventTable { get; set; }
        public DataBase DataBase { get; set; }

        public Event(DataBase sourceDataBase, string sourceEventTable)
        {
            DataBase = sourceDataBase;
            DataBase.Connect();
            SourceEventTable = sourceEventTable;
            _check = new CheckEvent(DataBase, sourceEventTable);
        }

        //Возврщает новый id для вставки записи в БД
        public int NewId(string sourceTable)
        {
            string queryText = "SELECT MAX(id) FROM " + sourceTable;

            int result = DataBase.DoScalarQuery(queryText);
            if (result != (int) Keys.Error)
            {
                return ++result;
            }

            return (int)Keys.Error;
        }

        //Добавление события
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

        //Удаление необходимого события по id
        public void Del(int id)
        {
            string queryText= "DELETE FROM " + SourceEventTable +
                              " WHERE id = ?";

            Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
            parametrsDictionary.Add("id", id);
            
            DataBase.DoQuery(queryText,parametrsDictionary);
        }

		//Изменение записи о событии
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
        
        //Удаление всех событий из БД
        public void Clear()
        {
            DataBase.Clear(SourceEventTable);
        }
    }
}
