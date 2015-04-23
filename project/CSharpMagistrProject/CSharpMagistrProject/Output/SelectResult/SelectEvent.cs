using System.Windows.Forms;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Output.SelectResult
{
    public class SelectEvent
    {
        private string SourceEventTable { get; set; }
        private DataBase DataBase { get; set; }

        public SelectEvent(DataBase sourceDataBase, string sourceEventTable)
        {
            SourceEventTable = sourceEventTable;
            DataBase = sourceDataBase;
            DataBase.Connect();
        }

        //Вывод списка событий
        public void Show(DataGridView receiverGridView)
        {
            string queryText = "SELECT * FROM " + SourceEventTable;
            receiverGridView.DataSource = DataBase.DoSelectQuery(queryText);
        }
    }
}
