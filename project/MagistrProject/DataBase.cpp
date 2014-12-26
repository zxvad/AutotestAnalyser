#include "Classes.h"

using namespace std;
using namespace DB;




CDataBase::CDataBase(string server, string DBName, string userName, string password)
	{
		this->server = server;
		this->DBName = DBName;
		this->userName =userName;
		this->password = password;

		isConnected=false;

		Connect();
	};


void CDataBase::Connect()
	{
		string ConnectionString="Provider=SQLNCLI10; Persist Security Info=True";
		ConnectionString+="; Data Source=" + this->server;
		ConnectionString+="; Password=" + this->password;
		ConnectionString+="; User ID=" + this->userName;
		ConnectionString+="; Initial Catalog=" + this->DBName;

		try 
		{
			// ... ���������� � �� ����� ���������

			this->isConnected=true;
		}
		catch(...)
		{
			ShowError("������ ���������� � ��");
		};

	};

void CDataBase:: Close()
	{
		try
		{
			// .....�������� ����������

			isConnected=false;
		}
		catch (...)
		{
			ShowError("������ �������� ��");
		}

	};

void CDataBase:: DoQuery(string queryText)
	{
		if (isConnected)
		{
			// ... ���������� ������� 
		} 
		else
		{
			ShowError("��� ���������� � ��");
		};

	};