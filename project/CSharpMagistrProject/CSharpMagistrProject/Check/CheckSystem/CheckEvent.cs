
using System.Collections.Generic;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Check.CheckSystem
{
    /// <summary>
    /// Класс, отвечаюищий за проверку событий на корректность
    /// </summary>
    public class CheckEvent
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
        /// Конструктор по БД и имени таблицы
        /// </summary>
        /// <param name="dataBase">База данных</param>
        /// <param name="sourceEventTable">Имя таблицы со списком событий</param>
        public CheckEvent(DataBase dataBase, string sourceEventTable)
        {
            _dataBase = dataBase;
            _sourceEventTable = sourceEventTable;
        }

        /// <summary>
        /// Проверка на корректность
        /// </summary>
        public void CheckForCorrect()
        {

        }

        /// <summary>
        /// Проверка на уникальность
        /// </summary>
        /// <param name="nameEvent">Имя события</param>
        /// <returns>Уникальна ли запись</returns>
        public bool CheckForUnique(string nameEvent)
        {
            string queryText = "SELECT COUNT(*) " +
                               "FROM " + _sourceEventTable +
                               " WHERE UCASE(name)=UCASE(?)";

            Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
            parametrsDictionary.Add("nameEvent", nameEvent);

            if (_dataBase.DoScalarQuery(queryText, parametrsDictionary) > 0)
                return false;
            return true;
        }
    }
}
