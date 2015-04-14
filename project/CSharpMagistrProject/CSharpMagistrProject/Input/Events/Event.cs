using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using CSharpMagistrProject.Check.CheckSystem;
using CSharpMagistrProject.DB;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Input.Events
{
    //Список событий
    class Event
    {
        private string sourceEventTable;
        public string SourceEventTable
        {
            get { return sourceEventTable; }
        }

        private CheckEvent check;

        private DataBase dataBase;
        public DataBase DataBase
        {
            get { return dataBase; }
        }

        public Event(DataBase sourceDataBase, string sourceEventTable)
        {
            dataBase = sourceDataBase;
            dataBase.Connect();
            this.sourceEventTable = sourceEventTable;
            check = new CheckEvent(dataBase, sourceEventTable);
        }

        //Возврщает новый id для вставки записи в БД
        public int NewId(string sourceTable)
        {
            string queryText = "SELECT MAX(id) FROM " + sourceTable;

            int result = dataBase.DoScalarQuery(queryText);
            if (result != (int) Keys.Error)
            {
                return ++result;
            }

            return (int)Keys.Error;
        }

        //Добавление события
        public void Add(string nameEvent)
        {
            if (check.CheckForUnique(nameEvent))
            {
                string queryText = "INSERT INTO " + sourceEventTable + " (id, name) " +
                                   "VALUES (?, ?)";
                Dictionary<string,object> parametrsDictionary=new Dictionary<string, object>();
                parametrsDictionary.Add("newId", NewId(sourceEventTable));
                parametrsDictionary.Add("nameEvent", nameEvent);

                dataBase.DoQuery(queryText, parametrsDictionary);
            }
            else
            {
                Controller.ShowMsg("Такое событие уже существует");
            }

        }

        //Удаление необходимого события по id
        public void Del(int id)
        {
            string queryText= "DELETE FROM " + sourceEventTable +
                              " WHERE id = ?";

            Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
            parametrsDictionary.Add("id", id);
            
            dataBase.DoQuery(queryText,parametrsDictionary);
        }

		//Изменение записи о событии
        public void Update(int id, string newName)
        {
            string queryText = "UPDATE " + sourceEventTable +
                               " SET name = ?" +
                               " WHERE id = ?";
            Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
            parametrsDictionary.Add("newName", newName);
            parametrsDictionary.Add("id", id);

            dataBase.DoQuery(queryText, parametrsDictionary);
        }
    }
}
