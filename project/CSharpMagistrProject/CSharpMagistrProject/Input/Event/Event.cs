using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.Input.Event
{
    //Список событий
    class Event
    {
        int idEvent;
		string name;
		string sourceTable;
		string queryText;

        public Event()
        {
            sourceTable = "Event";
        }

		//Возврщает новый id для вставки записи в БД
        public int NewID()
        {
            int result;
		    string queryText;
		    queryText="SELECT MAX(idEvent) FROM "+sourceTable;
            DataBase.DoQuery(queryText);

		    result=25;// для примера
		    return ++result; 
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
            DataBase.DoQuery(queryText);
        }

		//Удаление необходимого события по id
        public void Del(int id)
        {
            string queryText;
            queryText = "DELETE FROM " + sourceTable;
            queryText += " WHERE idEvent = ";
            queryText += id.ToString();
            DataBase.DoQuery(queryText);
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
            DataBase.DoQuery(queryText);
        }

		//Вывод списка событий
        public void Show()
        {
            string queryText;
            queryText = "SELECT * FROM " + sourceTable;
            DataBase.DoQuery(queryText);
        }
    }
}
