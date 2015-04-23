

using System.Collections.Generic;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Check.CheckSystem
{
    public class CheckNeedEvent
    {
        private readonly DataBase _dataBase;
        private readonly string _sourceNeedEventTable;

        public CheckNeedEvent(DataBase sourceDataBase, string sourceNeedEventTable)
        {
            _dataBase = sourceDataBase;
            _sourceNeedEventTable = sourceNeedEventTable;
        }



        public void CheckForCorrect(){}


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
