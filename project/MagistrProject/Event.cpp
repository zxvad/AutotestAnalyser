#include "classes.h"
using namespace Input;
using namespace Input::Event;

//Список событий

CEvent::CEvent()
	{
		sourceTable = "Event";
	};


//Возврщает новый id для вставки записи в БД
int CEvent::NewID()
	{
		int result;
		string queryText;
		queryText="SELECT MAX(idEvent) FROM "+sourceTable;
		DoQuery(queryText);

		result=25;// для примера
		return ++result; 
	};


//Добавление события
void CEvent::Add(string name)
	{
		string queryText;
		queryText="INSERT INTO "+sourceTable;
		queryText.append("(idEvent, name) ");
		queryText.append("VALUES (");
		queryText.append(IntToStr(NewID()));
		queryText.append(",");
		queryText.append(name);
		queryText.append(")");
		DoQuery(queryText);
	};

//Удаление необходимого события по id
void CEvent::Del(int id)
	{
		string queryText;
		queryText="DELETE FROM "+sourceTable;
		queryText.append(" WHERE idEvent = ");
		queryText.append(IntToStr(id));
		DoQuery(queryText);
	};

//Изменение записи о событии
void CEvent::Update(int id, string newName)
	{
		string queryText;
		queryText="UPDATE "+sourceTable;
		queryText.append(" SET name = ");
		queryText.append(newName);
		queryText.append(" WHERE idEvent = ");
		queryText.append(IntToStr(id));
		DoQuery(queryText);
	};

//Вывод списка событий
void CEvent::Show()
	{
		string queryText;
		queryText="SELECT * FROM "+sourceTable;
		DoQuery(queryText);
	};
