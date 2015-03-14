using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Input.Event
{
    //Список событий
    class Event
    {
        private int idEvent;
        private string name;
        private string sourceTable;
        private string queryText;

        private DataBase dataBase;

        public Event(DataBase sourceDataBase, string sourceTable)
        {
            dataBase = sourceDataBase;
            dataBase.Connect();
            this.sourceTable = sourceTable;
        }

		//Возврщает новый id для вставки записи в БД
        public int NewID()
        {
            if (dataBase.isConnected==true)
            {
                queryText = "SELECT MAX(idEvent) FROM " + sourceTable;
                int result = dataBase.DoScalarQuery(queryText);
                return ++result; 
            }
            else
            {
                return -1;
            }

        }

		//Добавление события
        public void Add(string name)
        {
            string queryText;
            queryText = "INSERT INTO " + sourceTable;
            queryText += "(idEvent, name) ";
            queryText +="VALUES (";
            queryText += NewID().ToString();
            queryText += ",";
            queryText += name;
            queryText += ")";
            //DataBase.DoQuery(queryText);
        }

		//Удаление необходимого события по id
        public void Del(int id)
        {
            string queryText;
            queryText = "DELETE FROM " + sourceTable;
            queryText += " WHERE idEvent = ";
            queryText += id.ToString();
            //DataBase.DoQuery(queryText);
        }

		//Изменение записи о событии
        public void Update(int id, string newName)
        {
            string queryText;
            queryText = "UPDATE " + sourceTable;
            queryText += " SET name = ";
            queryText += newName;
            queryText += " WHERE idEvent = ";
            queryText += id.ToString();
            //DataBase.DoQuery(queryText);
        }

		//Вывод списка событий
        public void Show()
        {
            string queryText;
            queryText = "SELECT * FROM " + sourceTable;
            //DataBase.DoQuery(queryText);
        }
    }
}
