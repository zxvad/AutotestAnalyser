

#include "classes.h"

using namespace std;
using namespace DB;
using namespace Input;
using namespace Input::Event;

//Анализ сигнала от контроллера
void Analiz()
	{
	};




int main ()
	{
		CEvent events;
		CDataBase DB("VAS-PC\sqlexpress", "MagistrDB","testuser","1");

		events.Add("name of event");
		events.Del(15);
		events.Update(10,"New name of event");
		events.Show();
	getch();
	return 0;
	}