#include "Classes.h"

//������� ����� � ������
string IntToStr(int num)
{
	char str[10];
	itoa(num,str,10);
	return str;
};

//���������� ������� � ��
void DoQuery(string queryText)
{
	// .... ��������� ������ 
	cout << queryText << endl;
};

void ShowError(string err)
{
	printf("\n ������: %s",err);
};