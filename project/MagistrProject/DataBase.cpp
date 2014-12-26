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
			// ... соединение с БД через компонент

			this->isConnected=true;
		}
		catch(...)
		{
			ShowError("Ошибка соединения с БД");
		};

	};

void CDataBase:: Close()
	{
		try
		{
			// .....закрытие соединения

			isConnected=false;
		}
		catch (...)
		{
			ShowError("Ошибка закрытия БД");
		}

	};

void CDataBase:: DoQuery(string queryText)
	{
		if (isConnected)
		{
			// ... выполнение запроса 
		} 
		else
		{
			ShowError("Нет соединения с БД");
		};

	};