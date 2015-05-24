using System.Collections.Generic;
using CSharpMagistrProject.DB;
using CSharpMagistrProject.Reading.InputSignal;

namespace CSharpMagistrProject.Analysis.DoneEvent
{
   
    /// <summary>
    /// Совершенные события
    /// </summary>
    public class DoneEvent
    {
        /// <summary>
        /// База данных
        /// </summary>
        private readonly DataBase _dataBase;

        /// <summary>
        /// Имя таблицы совершенных событий
        /// </summary>
        private readonly string _sourceDoneEventTable;

        /// <summary>
        /// Конструктор по БД и имени таблицы
        /// </summary>
        /// <param name="dataBase">База данных</param>
        /// <param name="sourceDoneEventTable">Имя таблицы совершенных событий</param>
        public DoneEvent(DataBase dataBase, string sourceDoneEventTable)
        {
            _dataBase = dataBase;
            _sourceDoneEventTable = sourceDoneEventTable;
        }

        /// <summary>
        /// Добавление совершенного события в БД
        /// </summary>
        /// <param name="inputSignal">Исходный сигнал</param>
        public void Add(InputSignal inputSignal)
        {
            string queryText = "INSERT INTO " + _sourceDoneEventTable + 
                                "(id, idEvent, ID_SIGNALS_TO_AUTOMATISATION, SIGNAL_SWITCH_TYPE, CHANGE_DATE) " +
                                "VALUES (?,?,?,?,?)";
            Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
            parametrsDictionary.Add("id", inputSignal.Id);
            parametrsDictionary.Add("idEvent", inputSignal.IdEvent);
            parametrsDictionary.Add("ID_SIGNALS_TO_AUTOMATISATION", inputSignal.IdSignalsToAutomatisation);
            parametrsDictionary.Add("SIGNAL_SWITCH_TYPE", inputSignal.SignalSwitchType);
            parametrsDictionary.Add("CHANGE_DATE", inputSignal.ChangeDate);
            
            _dataBase.DoQuery(queryText,parametrsDictionary);
        }

        /// <summary>
        /// Удаление всех произошедших событий в БД
        /// </summary>
        public void Clear()
        {
            _dataBase.Clear(_sourceDoneEventTable);
        }
    }
}
