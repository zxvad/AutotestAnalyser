using System.Collections.Generic;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Check.CheckSystem
{
    /// <summary>
    /// Класс, отвечающий за проверку необходимых событий
    /// </summary>
    public class CheckNeedEvent
    {
        /// <summary>
        /// База данных
        /// </summary>
        private readonly DataBase _dataBase;

        /// <summary>
        /// Имя таблицы необходимых событий
        /// </summary>
        private readonly string _sourceNeedEventTable;

        /// <summary>
        /// Конструктор по БД и имени таблицы
        /// </summary>
        /// <param name="sourceDataBase">База данных</param>
        /// <param name="sourceNeedEventTable">Имя таблицы необходимых событий</param>
        public CheckNeedEvent(DataBase sourceDataBase, string sourceNeedEventTable)
        {
            _dataBase = sourceDataBase;
            _sourceNeedEventTable = sourceNeedEventTable;
        }


        /// <summary>
        /// Првоерка на корректность
        /// </summary>
        public void CheckForCorrect(){}

        /// <summary>
        /// Проверка на уникальность
        /// </summary>
        /// <param name="idEvent">Id события из списка событий</param>
        /// <returns>Уникальна ли запись</returns>
        public bool CheckForUnique(int idEvent)
        {
            string queryText = "SELECT COUNT(*) " +
                               "FROM " + _sourceNeedEventTable +
                               " WHERE idEvent=?";

            Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
            parametrsDictionary.Add("idEvent", idEvent);

            if (_dataBase.DoScalarQuery(queryText, parametrsDictionary) > 0)
                return false;
            return true;
        }
    }
}
