using System.Windows.Forms;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Output.SelectResult
{
    /// <summary>
    /// выборка событий
    /// </summary>
    public class SelectEvent
    {
        /// <summary>
        /// Имя таблицы со списком событий
        /// </summary>
        private string SourceEventTable { get; set; }

        /// <summary>
        /// База данных
        /// </summary>
        private DataBase DataBase { get; set; }

        /// <summary>
        /// Конструктор по БД и имене таблицы
        /// </summary>
        /// <param name="sourceDataBase">База данных</param>
        /// <param name="sourceEventTable">Имя таблицы со списком событий</param>
        public SelectEvent(DataBase sourceDataBase, string sourceEventTable)
        {
            SourceEventTable = sourceEventTable;
            DataBase = sourceDataBase;
            DataBase.Connect();
        }
        
        /// <summary>
        /// Вывод списка событий
        /// </summary>
        /// <param name="receiverGridView">DataGridView для отображения результатов</param>
        public void Show(DataGridView receiverGridView)
        {
            string queryText = "SELECT * FROM " + SourceEventTable;
            receiverGridView.DataSource = DataBase.GetTableByQuery(queryText);
        }
    }
}
