using System.Windows.Forms;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Input.Event
{
    //Список событий
    class Event
    {
        private string sourceTable;
        private DataBase dataBase;

        public Event(DataBase sourceDataBase, string sourceTable)
        {
            dataBase = sourceDataBase;
            dataBase.Connect();
            this.sourceTable = sourceTable;
        }

		//Возврщает новый id для вставки записи в БД
        private int NewID()
        {
            if (dataBase.isConnected==true)
            {
                string queryText;
                queryText = "SELECT MAX(idEvent) FROM " + sourceTable;
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
            queryText = "INSERT INTO " + sourceTable + "(idEvent, name) ";
            queryText += "VALUES (" + NewID().ToString() + "," +@"""" +nameEvent + @""")";
            dataBase.DoQuery(queryText);
        }

        //Удаление необходимого события по id
        public void Del(int id)
        {
            string queryText;
            queryText = "DELETE FROM " + sourceTable;
            queryText += " WHERE idEvent = "+ id.ToString();
            dataBase.DoQuery(queryText);
        }

		//Изменение записи о событии
        public void Update(int id, string newName)
        {
            string queryText;
            queryText = "UPDATE " + sourceTable;
            queryText += @" SET name = """ + newName+ @"""";
            queryText += " WHERE idEvent = " + id.ToString();
            dataBase.DoQuery(queryText);
        }

		//Вывод списка событий
        public void Show(DataGridView receiverGridView)
        {
            string queryText;
            queryText = "SELECT * FROM " + sourceTable;
            dataBase.DoQuery(queryText,receiverGridView);
        }
    }
}
