

using System.Windows.Forms;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Output.SelectResult
{
    public class SelectNeedEvent
    {
        private DataBase dataBase;
        private string sourceEventTable;
        private string sourceNeedEventTable;

        public SelectNeedEvent(DataBase sourceDataBase, string sourceEventTable, string sourceNeedEventTable)
        {
            dataBase = sourceDataBase;
            this.sourceEventTable = sourceEventTable;
            this.sourceNeedEventTable = sourceNeedEventTable;
        }


        //Показ всех необходимых событий
        public void Show(DataGridView receiverGridView)
        {
            string queryText = "SELECT NeedEvent.id, Event.name " +
                               "FROM (" + sourceNeedEventTable + " NeedEvent " +
                               "LEFT JOIN " + sourceEventTable + " Event " +
                               "ON NeedEvent.idEvent = Event.id)";
            receiverGridView.DataSource = dataBase.DoSelectQuery(queryText);
        }
    }
}
