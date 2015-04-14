

using System.Collections.Generic;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Check.CheckSystem
{
    public class CheckNeedEvent
    {
        private DataBase dataBase;
        private string sourceNeedEventTable;

        public CheckNeedEvent(DataBase sourceDataBase, string sourceNeedEventTable)
        {
            dataBase = sourceDataBase;
            this.sourceNeedEventTable = sourceNeedEventTable;
        }



        public void CheckForCorrect(){}


        public bool CheckForUnique(int idEvent)
        {
            string queryText = "SELECT COUNT(*) " +
                               "FROM " + sourceNeedEventTable +
                               " WHERE idEvent=?";

            Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
            parametrsDictionary.Add("idEvent", idEvent);

            if (dataBase.DoScalarQuery(queryText, parametrsDictionary) > 0)
                return false;
            return true;
        }
    }
}
