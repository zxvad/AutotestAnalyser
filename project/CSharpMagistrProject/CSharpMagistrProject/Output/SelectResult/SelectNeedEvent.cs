

using System.Windows.Forms;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Output.SelectResult
{
    public class SelectNeedEvent
    {
        private readonly DataBase _dataBase;
        private readonly string _sourceEventTable;
        private readonly string _sourceNeedEventTable;

        public SelectNeedEvent(DataBase sourceDataBase, string sourceEventTable, string sourceNeedEventTable)
        {
            _dataBase = sourceDataBase;
            _sourceEventTable = sourceEventTable;
            _sourceNeedEventTable = sourceNeedEventTable;
        }


        //Показ всех необходимых событий
        public void Show(DataGridView receiverGridView)
        {
            string queryText = "SELECT NeedEvent.id, Event.name " +
                               "FROM (" + _sourceNeedEventTable + " NeedEvent " +
                               "LEFT JOIN " + _sourceEventTable + " Event " +
                               "ON NeedEvent.idEvent = Event.id)";
            receiverGridView.DataSource = _dataBase.DoSelectQuery(queryText);
        }
    }
}
