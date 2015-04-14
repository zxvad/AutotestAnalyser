using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using CSharpMagistrProject.Check.CheckSystem;
using CSharpMagistrProject.DB;
using CSharpMagistrProject.Input.Events;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Input.NeedEvents
{
    //Необходимые события
    class NeedEvent
    {
        private Event listEvent;
        private CheckNeedEvent check;
        private string sourceNeedEventTable;

        public NeedEvent(DataBase sourceDataBase, string sourceEventTable, string sourceNeedEventTable)
        {
            listEvent=new Event(sourceDataBase,sourceEventTable);
            this.sourceNeedEventTable = sourceNeedEventTable;
            check=new CheckNeedEvent(sourceDataBase,sourceNeedEventTable);
        }
        
        //Добавление необходимого события
        public void Add(int idEvent)
        {
            if (check.CheckForUnique(idEvent))
            {
                string queryText = "INSERT INTO " + sourceNeedEventTable + "(id, idEvent) " +
                                   "VALUES (?,?)";

                Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
                parametrsDictionary.Add("id", listEvent.NewId(sourceNeedEventTable));
                parametrsDictionary.Add("idEvent", idEvent);

                listEvent.DataBase.DoQuery(queryText, parametrsDictionary);
            }
            else
            {
                Controller.ShowMsg("Такое необходимое событие уже существует");
            }
        }

		//Удаление необходимого события по id
        public void Del(int id)
        {
            string queryText = "DELETE FROM " + sourceNeedEventTable +
                               " WHERE id = ?";
            Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
            parametrsDictionary.Add("id", id);

            listEvent.DataBase.DoQuery(queryText,parametrsDictionary);
        }

        //Изменение записи о событии
        public void Update(int id, int newIdEvent)
        {
            string queryText = "UPDATE " + sourceNeedEventTable +
                               " SET idEvent = ?" +
                               " WHERE id = ?";
            Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
            parametrsDictionary.Add("idEvent", newIdEvent);
            parametrsDictionary.Add("id", id);

            listEvent.DataBase.DoQuery(queryText,parametrsDictionary);
        }

        //Удаление всех необходимых событий из БД
        public void Clear()
        {
            listEvent.DataBase.Clear(sourceNeedEventTable);
        }
    }
}
