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
        public int NewID(string sourceTable)
        {
            if (dataBase.isConnected==true)
            {
                string queryText;
                queryText = "SELECT MAX(id) FROM " + sourceTable;
                int result = dataBase.DoScalarQuery(queryText);
                if (result!=-1)
                {
                    return ++result; 
                }
            }
            return -1;
        }

		//Добавление события
        public void Add(string nameEvent)
        {
            string queryText;
            queryText = "INSERT INTO " + sourceEventTable + "(id, name) ";
            queryText += "VALUES (" + NewID(sourceEventTable) + "," + @"""" + nameEvent + @""")";
            dataBase.DoQuery(queryText);
        }

        //Удаление необходимого события по id
        public void Del(int id)
        {
            string queryText;
            queryText = "DELETE FROM " + sourceEventTable;
            queryText += " WHERE id = "+ id;
            dataBase.DoQuery(queryText);
        }

		//Изменение записи о событии
        public void Update(int id, string newName)
        {
            string queryText;
            queryText = "UPDATE " + sourceEventTable;
            queryText += @" SET name = """ + newName+ @"""";
            queryText += " WHERE id = " + id;
            dataBase.DoQuery(queryText);
        }

		//Вывод списка событий
        public  void Show(DataGridView receiverGridView)
        {
            string queryText;
            queryText = "SELECT * FROM " + sourceEventTable;
            receiverGridView.DataSource=dataBase.DoSelectQuery(queryText);
        }
    }
}
