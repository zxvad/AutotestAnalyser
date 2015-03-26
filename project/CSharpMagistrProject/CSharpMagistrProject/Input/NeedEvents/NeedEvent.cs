using System.Windows.Forms;
using CSharpMagistrProject.DB;
using CSharpMagistrProject.Input.Events;

namespace CSharpMagistrProject.Input.NeedEvents
{
    //Необходимые события
    class NeedEvent
    {
        private Event listEvent;
        private string sourceNeedEventTable;

        public NeedEvent(DataBase sourceDataBase, string sourceEventTable, string sourceNeedEventTable)
        {
            listEvent=new Event(sourceDataBase,sourceEventTable);
            this.sourceNeedEventTable = sourceNeedEventTable;
        }
        
        //Добавление необходимого события
        public void Add(int idEvent)
        {
            string queryText;
            queryText = "INSERT INTO " + sourceNeedEventTable + "(id, idEvent) ";
            queryText += "VALUES (" + listEvent.NewID(sourceNeedEventTable) + "," + idEvent + ")";
            listEvent.DataBase.DoQuery(queryText);
        }

		//Удаление необходимого события по id
        public void Del(int id)
        {
            string queryText;
            queryText = "DELETE FROM " + sourceNeedEventTable;
            queryText += " WHERE id = " + id;
            listEvent.DataBase.DoQuery(queryText);
        }

        //Изменение записи о событии
        public void Update(int id, int newIdEvent)
        {
            string queryText;
            queryText = "UPDATE " + sourceNeedEventTable;
            queryText += " SET idEvent = " + newIdEvent;
            queryText += " WHERE id = " + id;
            listEvent.DataBase.DoQuery(queryText);
        }

        //Показ всех необходимых событий
        public void Show(DataGridView receiverGridView)
        {
            string queryText;
            queryText = @"SELECT NeedEvent.id, Event.name ";
            queryText += @"FROM (" + sourceNeedEventTable + @" NeedEvent ";
            queryText += @"LEFT JOIN " + listEvent.SourceEventTable + " Event ";
            queryText += @"ON NeedEvent.idEvent = Event.id)";
            receiverGridView.DataSource = listEvent.DataBase.DoSelectQuery(queryText);
        }
    }
}
