
using System.Data.OleDb;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Check.CheckSystem
{
    class CheckEvent
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

            OleDbCommand command = new OleDbCommand(queryText);
            command.Parameters.Add("nameEvent", OleDbType.VarChar);
            command.Parameters["nameEvent"].Value = nameEvent;
            if (dataBase.DoScalarQuery(command) > 0)
                return false;
            return true;

        }


    }
}
