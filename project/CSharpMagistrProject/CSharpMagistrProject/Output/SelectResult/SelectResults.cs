using System.Windows.Forms;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Output.SelectResult
{
    class SelectResults
    {
        private readonly DataBase dataBase;
        private readonly string eventTable;
        private string sourceNeedEventTable;
        private string sourceDoneEventTable;

        public SelectResults(DataBase sourceDataBase,string eventTable, string sourceNeedEventTable, string sourceDoneEventTable)
        {
            dataBase = sourceDataBase;
            this.eventTable = eventTable;
            this.sourceNeedEventTable = sourceNeedEventTable;
            this.sourceDoneEventTable = sourceDoneEventTable;
        }

        public void Show(DataGridView receiverGridView)
        {
            string queryText = "SELECT NeedEvent"
        }
    }
}
