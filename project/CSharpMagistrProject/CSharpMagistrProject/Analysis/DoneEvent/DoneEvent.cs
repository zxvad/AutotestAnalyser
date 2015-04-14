using System.Collections.Generic;
using CSharpMagistrProject.DB;
using CSharpMagistrProject.Reading.InputSignal;

namespace CSharpMagistrProject.Analysis.DoneEvent
{
    //Совершенные события
    class DoneEvent
    {
        private DataBase dataBase;
        private string sourceDoneEventTable;

        public DoneEvent(DataBase dataBase, string sourceDoneEventTable)
        {
            this.dataBase = dataBase;
            this.sourceDoneEventTable = sourceDoneEventTable;
        }

        //Очистка всех произошедших событий в БД
        public void Clear()
        {
            string queryText = "DELETE FROM " + sourceDoneEventTable;
            dataBase.DoQuery(queryText);
        }

        public void Add(InputSignal inputSignal)
        {
            string queryText = "INSERT INTO " + sourceDoneEventTable + 
                                "(id, idEvent, ID_SIGNALS_TO_AUTOMATISATION, SIGNAL_SWITCH_TYPE, CHANGE_DATE) " +
                                "VALUES (?,?,?,?,?)";
            Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
            parametrsDictionary.Add("id", inputSignal.Id);
            parametrsDictionary.Add("idEvent", inputSignal.IdEvent);
            parametrsDictionary.Add("ID_SIGNALS_TO_AUTOMATISATION", inputSignal.IdSignalsToAutomatisation);
            parametrsDictionary.Add("SIGNAL_SWITCH_TYPE", inputSignal.SignalSwitchType);
            parametrsDictionary.Add("CHANGE_DATE", inputSignal.ChangeDate);
            
            dataBase.DoQuery(queryText,parametrsDictionary);
        }
    }
}
