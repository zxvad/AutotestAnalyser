using System.Data;
using System.Windows.Forms;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Output.SelectResult
{
    class SelectResults
    {
        private readonly DataBase dataBase;
        private readonly string sourceEventTable;
        private string sourceNeedEventTable;
        private string sourceDoneEventTable;
        private string sourceResultTable;

        public SelectResults(DataBase sourceDataBase,string sourceEventTable, string sourceNeedEventTable, string sourceDoneEventTable, string sourceResultTable)
        {
            dataBase = sourceDataBase;
            this.sourceEventTable = sourceEventTable;
            this.sourceNeedEventTable = sourceNeedEventTable;
            this.sourceDoneEventTable = sourceDoneEventTable;
            this.sourceResultTable = sourceResultTable;
        }

        //  Вывод результирующей таблицы
        public void Show(DataGridView receiverGridView)
        {
            
            ProcessResultTable();
            string queryText = "SELECT Result.id, Event.name , Result.isDone as Выполнено " +
                   "FROM (" + sourceResultTable + " Result " +
                   "LEFT JOIN " + sourceEventTable + " Event " +
                   "ON Result.idEvent = Event.id)";
            receiverGridView.DataSource = dataBase.DoSelectQuery(queryText);
        }

        // Формирование результирующей таблицы
        private void ProcessResultTable()
        {
            // Очистка таблицы
            dataBase.Clear(sourceResultTable);

            // Копирование записей с необходимыми событиями в результирующую таблицу
            string queryText = "INSERT INTO " + sourceResultTable + "(id, idEvent) " +
                               "SELECT id, idEvent FROM " + sourceNeedEventTable;
            dataBase.DoQuery(queryText);

            // Вычисление результатов выполнения каждого события
            queryText = "UPDATE " + sourceResultTable +
                        " SET isDone=true " +
                        "WHERE id in " +
                        "(SELECT Result.id " +
                        "FROM " + sourceResultTable + " as Result, " + sourceDoneEventTable + " as Done " +
                        "WHERE Result.idEvent = Done.idEvent)";
            dataBase.DoQuery(queryText);
        }
    }
}
