#pragma once

//Перевод числа в строку
string IntToStr(int num);

//Выполнение запроса к БД
void DoQuery(string queryText);

void ShowError(string err);