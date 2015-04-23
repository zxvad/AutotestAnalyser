using System.Data;
using System.Windows.Forms;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Output.SelectResult
{
    class SelectResults
    {
        private readonly DataBase _dataBase;
        private readonly string _sourceEventTable;
        private readonly string _sourceNeedEventTable;
        private readonly string _sourceDoneEventTable;
        private readonly string _sourceResultTable;

        public SelectResults(DataBase sourceDataBase,string sourceEventTable, string sourceNeedEventTable, string sourceDoneEventTable, string sourceResultTable)
        {
            _dataBase = sourceDataBase;
            _sourceEventTable = sourceEventTable;
            _sourceNeedEventTable = sourceNeedEventTable;
            _sourceDoneEventTable = sourceDoneEventTable;
            _sourceResultTable = sourceResultTable;
        }

        //  Вывод результирующей таблицы
        public void Show(DataGridView receiverGridView)
        {
            
            ProcessResultTable();
            string queryText = "SELECT Result.id, Event.name , Result.isDone as Выполнено " +
                   "FROM (" + _sourceResultTable + " Result " +
                   "LEFT JOIN " + _sourceEventTable + " Event " +
                   "ON Result.idEvent = Event.id)";
            receiverGridView.DataSource = _dataBase.DoSelectQuery(queryText);
        }

        // Формирование результирующей таблицы
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
