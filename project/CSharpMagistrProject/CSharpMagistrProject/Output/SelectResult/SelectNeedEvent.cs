using System.Windows.Forms;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Output.SelectResult
{
    /// <summary>
    /// Выборка необходимых событий
    /// </summary>
    public class SelectNeedEvent
    {
        /// <summary>
        /// База данных
        /// </summary>
        private readonly DataBase _dataBase;

        /// <summary>
        /// Имя таблицы со списком событий
        /// </summary>
        private readonly string _sourceEventTable;

        /// <summary>
        /// Имя таблицы с необходимыми событиями
        /// </summary>
        private readonly string _sourceNeedEventTable;

        /// <summary>
        /// Конструктор по БД и именам таблиц
        /// </summary>
        /// <param name="sourceDataBase">База данных</param>
        /// <param name="sourceEventTable">Имя таблицы со списком событий</param>
        /// <param name="sourceNeedEventTable">Имя таблицы с необходимыми событиями</param>
        public SelectNeedEvent(DataBase sourceDataBase, string sourceEventTable, string sourceNeedEventTable)
        {
            _dataBase = sourceDataBase;
            _sourceEventTable = sourceEventTable;
            _sourceNeedEventTable = sourceNeedEventTable;
        }
        
        /// <summary>
        /// Вывод всех необходимых событий
        /// </summary>
        /// <param name="receiverGridView">DataGridView для отображения результатов</param>
        public void Show(DataGridView receiverGridView)
        {
            string queryText = "SELECT NeedEvent.id, Event.name " +
                               "FROM (" + _sourceNeedEventTable + " NeedEvent " +
                               "LEFT JOIN " + _sourceEventTable + " Event " +
                               "ON NeedEvent.idEvent = Event.id)";
            receiverGridView.DataSource = _dataBase.GetTableByQuery(queryText);
        }
    }
}
