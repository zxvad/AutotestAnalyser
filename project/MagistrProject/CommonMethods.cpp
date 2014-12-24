#include "Classes.h"

//Перевод числа в строку
string IntToStr(int num)
{
	char str[10];
	itoa(num,str,10);
	return str;
};

//Выполнение запроса к БД
void DoQuery(string queryText)
{
	// .... выполнить запрос 
	cout << queryText << endl;
};

void ShowError(string err)
{
	printf("\n Ошибка: %s",err);
};