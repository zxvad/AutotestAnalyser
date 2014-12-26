#include "Classes.h"





	void ShowError(string err)
	{
		printf("\n Ошибка: %s",err);
	};

	//Выполнение запроса к БД
	void DoQuery(string queryText)
	{
		// .... выполнить запрос 
		cout << queryText << endl;
	};



		//Перевод числа в строку
		string IntToStr(int num)
		{
			char str[10];
			itoa(num,str,10);
			return str;
		};

