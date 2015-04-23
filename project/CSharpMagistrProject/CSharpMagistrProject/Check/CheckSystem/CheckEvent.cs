
using System.Collections.Generic;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Check.CheckSystem
{
    internal class CheckEvent
    {
        private readonly DataBase _dataBase;
        private readonly string _sourceEventTable;

        public CheckEvent(DataBase dataBase, string sourceEventTable)
        {
            _dataBase = dataBase;
            _sourceEventTable = sourceEventTable;
        }

        public void CheckForCorrect()
        {

        }

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
