using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
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
            OleDbCommand command = new OleDbCommand(queryText);
            dataBase.DoQuery(command);
        }

        public void Add(InputSignal inputSignal)
        {
            string queryText = "INSERT INTO " + sourceDoneEventTable + 
                                "(id, idEvent, ID_SIGNALS_TO_AUTOMATISATION, SIGNAL_SWITCH_TYPE, CHANGE_DATE) " +
                                "VALUES (?,?,?,?,?)";
            OleDbCommand command = new OleDbCommand(queryText);

            command.Parameters.Add("id", OleDbType.Integer);
            command.Parameters.Add("idEvent", OleDbType.Integer);
            command.Parameters.Add("ID_SIGNALS_TO_AUTOMATISATION", OleDbType.Integer);
            command.Parameters.Add("SIGNAL_SWITCH_TYPE", OleDbType.Boolean);
            command.Parameters.Add("CHANGE_DATE", OleDbType.Date);

            command.Parameters["id"].Value = inputSignal.id;
            command.Parameters["idEvent"].Value = inputSignal.idEvent;
            command.Parameters["ID_SIGNALS_TO_AUTOMATISATION"].Value = inputSignal.ID_SIGNALS_TO_AUTOMATISATION;
            command.Parameters["SIGNAL_SWITCH_TYPE"].Value = inputSignal.SIGNAL_SWITCH_TYPE;
            command.Parameters["CHANGE_DATE"].Value = inputSignal.CHANGE_DATE;
            
            dataBase.DoQuery(command);
        }
    }
}
