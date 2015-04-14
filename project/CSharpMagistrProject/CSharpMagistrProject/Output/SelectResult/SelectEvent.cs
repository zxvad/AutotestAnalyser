

using System.Windows.Forms;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Output.SelectResult
{
    public class SelectEvent
    {
        private string sourceEventTable;
        public string SourceEventTable
        {
            get { return sourceEventTable; }
        }

        private DataBase dataBase;
        public DataBase DataBase
        {
            get { return dataBase; }
        }

        public SelectEvent(DataBase sourceDataBase, string sourceEventTable)
        {
            this.sourceEventTable = sourceEventTable;
            dataBase = sourceDataBase;
            dataBase.Connect();
        }

        //Вывод списка событий
        public void Show(DataGridView receiverGridView)
        {
            string queryText = "SELECT * FROM " + sourceEventTable;
            receiverGridView.DataSource = dataBase.DoSelectQuery(queryText);
        }
    }
}
