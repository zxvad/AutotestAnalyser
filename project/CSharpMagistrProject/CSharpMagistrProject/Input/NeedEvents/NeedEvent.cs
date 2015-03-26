using System.Data.OleDb;
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
            string queryText = "INSERT INTO " + sourceNeedEventTable + "(id, idEvent) " +
                               "VALUES (?,?)";
            OleDbCommand command=new OleDbCommand(queryText);

            command.Parameters.Add("id", OleDbType.Integer);
            command.Parameters.Add("idEvent", OleDbType.Integer);

            command.Parameters["id"].Value = listEvent.NewId(sourceNeedEventTable);
            command.Parameters["idEvent"].Value = idEvent;

            listEvent.DataBase.DoQuery(command);
        }

		//Удаление необходимого события по id
        public void Del(int id)
        {
            string queryText = "DELETE FROM " + sourceNeedEventTable +
                               " WHERE id = ?";
            OleDbCommand command = new OleDbCommand(queryText);

            command.Parameters.Add("id", OleDbType.Integer);
            command.Parameters["id"].Value = id;

            listEvent.DataBase.DoQuery(command);
        }

        //Изменение записи о событии
        public void Update(int id, int newIdEvent)
        {
            string queryText = "UPDATE " + sourceNeedEventTable +
                               " SET idEvent = ?" +
                               " WHERE id = ?";
            OleDbCommand command = new OleDbCommand(queryText);

            command.Parameters.Add("idEvent", OleDbType.Integer);
            command.Parameters.Add("id", OleDbType.Integer);

            command.Parameters["idEvent"].Value = newIdEvent;
            command.Parameters["id"].Value = id;

            listEvent.DataBase.DoQuery(command);
        }

        //Показ всех необходимых событий
        public void Show(DataGridView receiverGridView)
        {
            string queryText = "SELECT NeedEvent.id, Event.name " +
                               "FROM (" + sourceNeedEventTable + " NeedEvent " +
                               "LEFT JOIN " + listEvent.SourceEventTable + " Event " +
                               "ON NeedEvent.idEvent = Event.id)";
            OleDbCommand command = new OleDbCommand(queryText);
            receiverGridView.DataSource = listEvent.DataBase.DoSelectQuery(command);
        }
    }
}
