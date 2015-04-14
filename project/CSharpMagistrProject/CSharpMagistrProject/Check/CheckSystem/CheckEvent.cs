
using System.Collections.Generic;
using System.Data.OleDb;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Check.CheckSystem
{
    internal class CheckEvent
    {
        private DataBase dataBase;
        private string sourceEventTable;

        public CheckEvent(DataBase dataBase, string sourceEventTable)
        {
            this.dataBase = dataBase;
            this.sourceEventTable = sourceEventTable;
        }

        public void CheckForCorrect()
        {

        }

        public bool CheckForUnique(string nameEvent)
        {
            string queryText = "SELECT COUNT(*) " +
                               "FROM " + sourceEventTable +
                               " WHERE UCASE(name)=UCASE(?)";

            Dictionary<string, object> parametrsDictionary = new Dictionary<string, object>();
            parametrsDictionary.Add("nameEvent", nameEvent);

            if (dataBase.DoScalarQuery(queryText, parametrsDictionary) > 0)
                return false;
            return true;
        }
    }
}
