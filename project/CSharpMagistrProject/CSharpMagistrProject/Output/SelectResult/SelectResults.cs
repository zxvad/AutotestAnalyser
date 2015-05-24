using System.Data;
using System.Windows.Forms;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Output.SelectResult
{
    class SelectResults
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
        /// Имя таблицы с совершенными событиями
        /// </summary>
        private readonly string _sourceDoneEventTable;

        /// <summary>
        /// Имя таблицы с результатами
        /// </summary>
        private readonly string _sourceResultTable;

        /// <summary>
        /// Конструктор по БД и именам таблиц
        /// </summary>
        /// <param name="sourceDataBase">База данных</param>
        /// <param name="sourceEventTable">Имя таблицы со списком событий</param>
        /// <param name="sourceNeedEventTable">Имя таблицы с необходимыми событиями</param>
        /// <param name="sourceDoneEventTable">Имя таблицы с совершенными событиями</param>
        /// <param name="sourceResultTable">Имя таблицы с результатами</param>
        public SelectResults(DataBase sourceDataBase,string sourceEventTable, string sourceNeedEventTable, string sourceDoneEventTable, string sourceResultTable)
        {
            _dataBase = sourceDataBase;
            _sourceEventTable = sourceEventTable;
            _sourceNeedEventTable = sourceNeedEventTable;
            _sourceDoneEventTable = sourceDoneEventTable;
            _sourceResultTable = sourceResultTable;
        }

        /// <summary>
        /// Вывод результирующей таблицы
        /// </summary>
        /// <param name="receiverGridView">DataGridView для вывода результатов</param>
        public void Show(DataGridView receiverGridView)
        {
            
            ProcessResultTable();
            string queryText = "SELECT Result.id, Event.name , Result.isDone as Выполнено " +
                   "FROM (" + _sourceResultTable + " Result " +
                   "LEFT JOIN " + _sourceEventTable + " Event " +
                   "ON Result.idEvent = Event.id)";
            receiverGridView.DataSource = _dataBase.GetTableByQuery(queryText);
        }

        /// <summary>
        /// Формирование результирующей таблицы
        /// </summary>
        private void ProcessResultTable()
        {
            // Очистка таблицы
            _dataBase.Clear(_sourceResultTable);

            // Копирование записей с необходимыми событиями в результирующую таблицу
            string queryText = "INSERT INTO " + _sourceResultTable + "(id, idEvent) " +
                               "SELECT id, idEvent FROM " + _sourceNeedEventTable;
            _dataBase.DoQuery(queryText);

            // Вычисление результатов выполнения каждого события
            queryText = "UPDATE " + _sourceResultTable +
                        " SET isDone=true " +
                        "WHERE id in " +
                        "(SELECT Result.id " +
                        "FROM " + _sourceResultTable + " as Result, " + _sourceDoneEventTable + " as Done " +
                        "WHERE Result.idEvent = Done.idEvent)";
            _dataBase.DoQuery(queryText);
        }
    }
}
