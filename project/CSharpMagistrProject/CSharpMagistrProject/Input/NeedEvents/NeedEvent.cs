using System.Windows.Forms;
using CSharpMagistrProject.DB;
using CSharpMagistrProject.Input.Events;

namespace CSharpMagistrProject.Input.NeedEvents
{
    //Необходимые события
    class NeedEvent:Event
    {
        private string sourceNeedEventTable;

        public NeedEvent(DataBase sourceDataBase, string sourceEventTable, string sourceNeedEventTable):base(sourceDataBase,sourceEventTable)
        {
            dataBase = sourceDataBase;
            this.sourceEventTable = sourceEventTable;
            this.sourceNeedEventTable = sourceNeedEventTable;
        }

        public override void Add(string nameEvent){}
        
        //Добавление необходимого события
        public void Add(int idEvent)
        {
            string queryText;
            queryText = "INSERT INTO " + sourceNeedEventTable + "(id, idEvent) ";
            queryText += "VALUES (" + NewID(sourceNeedEventTable) + "," + idEvent + ")";
            dataBase.DoQuery(queryText);
        }

		//Удаление необходимого события по id
        public override void Del(int id)
        {
            string queryText;
            queryText = "DELETE FROM " + sourceNeedEventTable;
            queryText += " WHERE id = " + id;
            dataBase.DoQuery(queryText);
        }

        public override void Update(int id, string newName){}

        //Изменение записи о событии
        public void Update(int id, int newIdEvent)
        {
            string queryText;
            queryText = "UPDATE " + sourceNeedEventTable;
            queryText += " SET idEvent = " + newIdEvent;
            queryText += " WHERE id = " + id;
            dataBase.DoQuery(queryText);
        }

        public override void Show(DataGridView receiverGridView)
        {
            string queryText;
            queryText = @"SELECT NeedEvent.id, Event.name ";
            queryText += @"FROM (" + sourceNeedEventTable + @" NeedEvent ";
            queryText += @"LEFT JOIN " + sourceEventTable + " Event ";
            queryText += @"ON NeedEvent.idEvent = Event.idEvent)";
            receiverGridView.DataSource=dataBase.DoSelectQuery(queryText);
        }
    }
}
