#include "Classes.h"





	void ShowError(string err)
	{
		printf("\n ������: %s",err);
	};

	//���������� ������� � ��
	void DoQuery(string queryText)
	{
		// .... ��������� ������ 
		cout << queryText << endl;
	};



		//������� ����� � ������
		string IntToStr(int num)
		{
			char str[10];
			itoa(num,str,10);
			return str;
		};

