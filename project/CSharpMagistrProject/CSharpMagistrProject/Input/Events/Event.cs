using System.Data.OleDb;
using System.Windows.Forms;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Input.Events
{
    //Список событий
    class Event
    {
        private string sourceEventTable;
        public string SourceEventTable
        {
            get { return sourceEventTable; }
        }

        private DataBase dataBase;
        public DataBase DataBase
        {
            get { return dataBase; }
        }

        public Event(DataBase sourceDataBase, string sourceEventTable)
        {
            dataBase = sourceDataBase;
            dataBase.Connect();
            this.sourceEventTable = sourceEventTable;
        }

        //Возврщает новый id для вставки записи в БД
        public int NewId(string sourceTable)
        {
            string queryText = "SELECT MAX(id) FROM " + sourceTable;
            OleDbCommand command = new OleDbCommand(queryText);

            int result = dataBase.DoScalarQuery(command);
            if (result != -1)
            {
                return ++result;
            }

            return -1;
        }

        //Добавление события
        public void Add(string nameEvent)
        {
            string queryText="INSERT INTO "+sourceEventTable+" (id, name) "+
                             "VALUES (?, ?)";

            OleDbCommand command = new OleDbCommand(queryText);

            command.Parameters.Add("newId", OleDbType.Integer);
            command.Parameters.Add("nameEvent", OleDbType.VarChar);

            command.Parameters["newId"].Value = NewId(sourceEventTable);
            command.Parameters["nameEvent"].Value = nameEvent;

            dataBase.DoQuery(command);


        }

        //Удаление необходимого события по id
        public void Del(int id)
        {
            string queryText= "DELETE FROM " + sourceEventTable +
                              " WHERE id = ?";
            OleDbCommand command = new OleDbCommand(queryText);

            command.Parameters.Add("id", OleDbType.Integer);
            command.Parameters["id"].Value = id;
            
            dataBase.DoQuery(command);
        }

		//Изменение записи о событии
        public void Update(int id, string newName)
        {
            string queryText = "UPDATE " + sourceEventTable +
                               " SET name = ?" +
                               " WHERE id = ?";
            OleDbCommand command = new OleDbCommand(queryText);

            command.Parameters.Add("newName", OleDbType.VarChar);
            command.Parameters.Add("id", OleDbType.Integer);

            command.Parameters["newName"].Value = newName;
            command.Parameters["id"].Value = id;

            dataBase.DoQuery(command);
        }

		//Вывод списка событий
        public  void Show(DataGridView receiverGridView)
        {
            string queryText = "SELECT * FROM " + sourceEventTable;
            OleDbCommand command = new OleDbCommand(queryText);
            receiverGridView.DataSource = dataBase.DoSelectQuery(command);
        }
    }
}
